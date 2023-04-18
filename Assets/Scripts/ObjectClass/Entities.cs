using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Entities are all NPCs and player-controlled units
public abstract class Entities : DefaultObjects
{
    // Player Stats
    [SerializeField] private float hitPoints = 20;
    [SerializeField] private float defaultAttack = 1;
    [SerializeField] private float defaultWeaponAttack = 1;
    [SerializeField] private float defaultDefence = 5;
    [SerializeField] private float defaultmagicDefence = 0;

    // Getters and Setters
    public float HitPoints
    {
        get { return hitPoints; }
        set { hitPoints = value; }
    }

    public float DefaultAttack
    {
        get { return defaultAttack; }
        set { defaultAttack = value; }
    }

    public float DefaultWeaponAttack
    {
        get { return defaultWeaponAttack; }
        set { defaultWeaponAttack = value; }
    }

    public float DefaultDefence
    {
        get { return defaultDefence; }
        set { defaultDefence = value; }
    }

    public float DefaultmagicDefence
    {
        get { return defaultmagicDefence; }
        set { defaultmagicDefence = value; }
    }
}
