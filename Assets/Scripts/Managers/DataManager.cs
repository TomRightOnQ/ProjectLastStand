using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// All in-game DATA is stored here

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    private PrefabManager PrefabReference;
    // Data sectors
    // All Monsters
    private Monsters[] monsterPool;

    public const int MONSTER_COUNT = 100;

    // Set up a reference sheet of objects
    public void SetPrefabReference(PrefabManager prefabReference)
    {
        PrefabReference = prefabReference;
    }

    void Awake()
    {
        // Initialize monster pool
        monsterPool = new Monsters[MONSTER_COUNT];
        for (int i = 0; i < MONSTER_COUNT; i++)
        {
            GameObject monsterObj = Instantiate(PrefabReference.monsterPrefab, Vector3.zero, Quaternion.identity);
            monsterObj.SetActive(false);
            monsterPool[i] = monsterObj.GetComponent<Monsters>();
        }

    }

    void Start()
    {

    }

    void Update()
    {

    }
}