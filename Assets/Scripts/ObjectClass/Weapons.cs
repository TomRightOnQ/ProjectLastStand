using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Define Weapons
public class Weapons : DefaultObjects
{
    void Start()
    {
        gameObject.tag = "Weapon";
    }

    // Weapon Stats
    [SerializeField] private string wpName = "DeaultWeapon";
    [SerializeField] private int index = 0;

    [SerializeField] private bool isBullet = true;
    [SerializeField] private float attack = 10;
    [SerializeField] private float pen = 0.1f;
    [SerializeField] private float life = 6.0f;
    [SerializeField] private float cd = 0.5f;
    [SerializeField] private bool selfDet = false;
    [SerializeField] private float projectileSpeed = 10f;

    public string WpName
    {
        get { return wpName; }
        set { wpName = value; }
    }

    public int Index
    {
        get { return index; }
        set { index = value; }
    }

    public bool IsBullet
    {
        get { return isBullet; }
        set { isBullet = value; }
    }

    public float Attack
    {
        get { return attack; }
        set { attack = value; }
    }

    public float Pen
    {
        get { return pen; }
        set { pen = value; }
    }

    public float Life
    {
        get { return life; }
        set { life = value; }
    }

    public float ProjectileSpeed
    {
        get { return projectileSpeed; }
        set { projectileSpeed = value; }
    }

    public float CD
    {
        get { return cd; }
        set { cd = value; }
    }

    public bool SelfDett
    {
        get { return selfDet; }
        set { selfDet = value; }
    }
}
