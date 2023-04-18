using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// All in-game DATA is stored here

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    private PrefabManager PrefabReference;
    // Data sectors
    // Players
    private Players[] playerArray;
    public const int PLAYER_COUNT = 1;
    // Monsters
    private Monsters[] monsterPool;
    public const int MONSTER_COUNT = 1;
    // Projectiles
    private Projectiles[] projPool;
    public const int PROJ_COUNT = 10;

    // Set up a reference sheet of objects
    public void initData(PrefabManager prefabReference)
    {
        PrefabReference = prefabReference;
        initPool();
    }

    // Init pools
    private void initPool()
    {
        if (PrefabReference == null)
        {
            Debug.LogError("Prefab reference is null in DataManager.Awake!");
            return;
        }

        // Place the players in the field
        playerArray = new Players[PLAYER_COUNT];
        for (int i = 0; i < PLAYER_COUNT; i++)
        {
            GameObject playerObj = Instantiate(PrefabReference.playerPrefab, new Vector3(0f, 0.2f, 0f), Quaternion.identity);
            playerObj.SetActive(true);
            playerArray[i] = playerObj.GetComponent<Players>();
        }

        // Initialize monster pool
        monsterPool = new Monsters[MONSTER_COUNT];
        for (int i = 0; i < MONSTER_COUNT; i++)
        {
            GameObject monsterObj = Instantiate(PrefabReference.monsterPrefab, Vector3.zero, Quaternion.identity);
            monsterObj.SetActive(false);
            monsterPool[i] = monsterObj.GetComponent<Monsters>();
        }

        // Initialize projectile pool
        projPool = new Projectiles[PROJ_COUNT];
        for (int i = 0; i < PROJ_COUNT; i++)
        {
            GameObject projObj = Instantiate(PrefabReference.projPrefab, Vector3.zero, Quaternion.identity);
            projObj.SetActive(false);
            projPool[i] = projObj.GetComponent<Projectiles>();
        }
    }

    // Take an object from the pool and push it to the other
    public Projectiles TakeProjPool() {
        for (int i = 0; i < projPool.Length; i++)
        {
            if (!projPool[i].gameObject.activeSelf)
            {
                projPool[i].gameObject.SetActive(true);
                return projPool[i];
            }
        }
        return null;
    }

    // Getters for the pools
    public Players[] GetPlayers()
    {
        return playerArray;
    }

    public Projectiles[] GetProjs()
    {
        return projPool;
    }

    public Monsters[] GetMonsters()
    {
        return monsterPool;
    }

    void Start()
    {

    }

    void Update()
    {

    }
}