using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Main Game Manager

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public DataManager dataManager;
    public PrefabManager prefabManager;

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
            instance = this;
            DontDestroyOnLoad(gameObject);
            GameObject dataManagerObj = new GameObject("DataManager");
            dataManager = dataManagerObj.AddComponent<DataManager>();
            dataManager.initData(prefabManager);
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
        Debug.Log(projPoolA.Length);
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
                        float distance = Vector3.Distance(proj.transform.position, monster.transform.position);
                        if (distance < 1f)
                        {
                            monster.TakeDamage(1f);
                            proj.Deactivate();
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
