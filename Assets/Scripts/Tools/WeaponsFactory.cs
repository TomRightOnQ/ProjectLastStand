using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ConfigManager;
// Abstract Factory to Create new Weapons class instances
public class WeaponsFactory
{
    public static Weapons CreateWeapon(WeaponConfig config)
    {
        Weapons weapon = new Weapons();
        weapon.SetWeapons(config);
        return weapon;
    }
}
