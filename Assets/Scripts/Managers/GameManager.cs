using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Main Game Manager

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private DataManager dataManager;
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
        }
        // Init prefab references
        dataManager = DataManager.Instance;
        dataManager.SetPrefabReference(prefabManager);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
