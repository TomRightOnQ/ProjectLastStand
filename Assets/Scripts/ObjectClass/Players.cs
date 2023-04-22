using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ConfigManager;

// All players are a Players object
public class Players : Entities
{
    private PrefabManager prefabReference;
    // Player 1 - 4
    [SerializeField] private int index = 0;
    [SerializeField] private float fortune = 1;
    [SerializeField] private bool armed = false;

    // Weapons
    private int WEAPON_COUNT = 2;
    private Weapons[] weapons;
    void Start()
    {
        gameObject.tag = "Player";
        weapons = new Weapons[WEAPON_COUNT];
        prefabReference = GameManager.Instance.prefabManager;

        for (int i = 0; i < WEAPON_COUNT; i++) {
            GameObject weaponObj = Instantiate(prefabReference.weaponPrefab, new Vector3(0f, 0.1f, 0f), Quaternion.identity);
            weaponObj.SetActive(true);
            weapons[i] = weaponObj.GetComponent<Weapons>();
        }
    }
    public int Index
    {
        get { return index; }
        set { index = value; }
    }

    public float Fortune
    {
        get { return fortune; }
        set { fortune = value; }
    }

    public bool Armed 
    {
        get { return armed; }
        set { armed = value; }
    }

    // Set prefabreference
    public void SetPrefabManager(PrefabManager prefabReference)
    {
        this.prefabReference = prefabReference;
    }
    /* Add a Weapon
    slot: 1 or 2, indicate the current slot
    id: weapon id
    return: add a Weapons type object instance to Weapons[] array */
    public void addWeapon(int slot, int id) {
        WeaponConfig[] weaponData = GameManager.Instance.configManager.getWeapons();
        weapons[slot].SetWeapons(weaponData[id]);
    }

    // Attack!
    public void fire() {
        weapons[0].Fire(transform.position, index);
    }
}
