using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bullets
public class Projectiles : Items
{
    void Start()
    {
        gameObject.tag = "Proj";
    }

    // Projectile stats
    [SerializeField] private float damage = 1;
    [SerializeField] private int owner = 0;
    [SerializeField] private float life = 6.0f;
    [SerializeField] private bool selfDet = false;
    private float creationTime;

    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public int Owner
    {
        get { return owner; }
        set { owner = value; }
    }

    public float Life
    {
        get { return life; }
        set { life = value; }
    }

    public bool SelfDet
    {
        get { return selfDet; }
        set { selfDet = value; }
    }

    // Control the lifespan of a projectile
    private void OnEnable()
    {
        creationTime = Time.time;
        Invoke("Deactivate", life);
    }

    private void OnDisable()
    {
        CancelInvoke("Deactivate");
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}