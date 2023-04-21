using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Main Game Manager

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public DataManager dataManager;
    public PrefabManager prefabManager;
    public MonsterManager monsterManager;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        // Check repeated instances
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            // init all manager objects
            instance = this;
            DontDestroyOnLoad(gameObject);
            GameObject dataManagerObj = new GameObject("DataManager");
            dataManager = dataManagerObj.AddComponent<DataManager>();
            dataManager.initData(prefabManager);

            GameObject monsterManagerObj = new GameObject("MonsterManager");
            monsterManager = monsterManagerObj.AddComponent<MonsterManager>();
        }
    }

    void Start()
    {

    }

    void Update()
    {
        // Prepare pools
        Projectiles[] projPoolA = GameManager.Instance.dataManager.GetProjs();
        Monsters[] monsterPoolA = GameManager.Instance.dataManager.GetMonsters();
        // Test Attack
        Players[] players = dataManager.GetPlayers();

        if (Input.GetMouseButtonDown(0))
        {
            players[0].fire();
        }

        // Damage Calculation
        foreach (Projectiles proj in projPoolA)
        {
            if (proj != null && proj.gameObject.activeSelf && proj.Player)
            {
                foreach (Monsters monster in monsterPoolA)
                {
                    if (monster != null && monster.gameObject.activeSelf && monster.gameObject.CompareTag("Monster"))
                    {
                        if (proj.GetComponent<Collider>().bounds.Intersects(monster.GetComponent<Collider>().bounds))
                        {
                            Debug.Log("Has taken damage");
                            monster.TakeDamage(10f);
                            proj.Deactivate();
                            GameManager.Instance.monsterManager.despawnCheck(monster);
                            break;
                        }
                    }
                }
            }
            else if (!proj.gameObject.activeSelf)
            {
                GameManager.Instance.dataManager.RemoveDeactivatedProj(proj);
            }
        }
    }

    //
}
