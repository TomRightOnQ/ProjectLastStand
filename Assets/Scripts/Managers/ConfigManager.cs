using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

// Load configuration files
public class ConfigManager : MonoBehaviour
{
    private MonsterConfig[] MonsterTemplate;
    private WeaponConfig[] WeaponTemplate;
    private string monsterConfigName = "MonsterConfig.json";
    private string weaponConfigName = "WeaponConfig.json";

    private bool loaded;

    // Data Struct Sector
    public struct MonsterConfig
    {
        public string name;
        public int id;
        public int hitPoints;
        public float speed;
        public int defaultAttack;
        public int defaultWeaponAttack;
        public int defaultDenfence;
        public int defaultMagicDefence;
        public int exp;
    }
    public struct WeaponConfig
    {
        public string name;
        public int id;
        public bool isBullet;
        public float attack;
        public float pen;
        public float life;
        public float cd;
        public bool selfDet;
        public float projectileSpeed;
    }

    // Loader
    public static ConfigManager Instance;
    public T LoadConfig<T>(string filename)
    {

        string path = Path.Combine(Application.dataPath, "Config", filename);

        if (!File.Exists(path))
        {
            Debug.LogError($"Failed to load config file {filename}: file does not exist");
            return default;
        }

        string json = File.ReadAllText(path);
        T config = JsonConvert.DeserializeObject<T>(json);
        return config;
    }

    // Load Configurations at start
    public void Load()
    {
        MonsterTemplate = LoadConfig<MonsterConfig[]>(monsterConfigName);
        WeaponTemplate = LoadConfig<WeaponConfig[]>(weaponConfigName);
        loaded = true;
        Debug.Log(WeaponTemplate);
    }

    // Get Weapons
    public WeaponConfig[] getWeapons() {
        return WeaponTemplate;
    }

    // Get Monsters
    public MonsterConfig[] getMonsters()
    {
        return MonsterTemplate;
    }

    public bool ConfigLoaded() {
        return loaded;
    }
}
