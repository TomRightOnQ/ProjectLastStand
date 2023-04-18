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
        // Test Attack
        Players[] players = dataManager.GetPlayers();

        if (Input.GetMouseButtonDown(0))
        {
            players[0].fire();
        }
    }
}
