using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// All Monsters are one class
public class Monsters : Entities
{
    void Start()
    {
        gameObject.tag = "Monster";
    }
    // Monster Stats
    [SerializeField] private float exp = 1;

    public float EXP
    {
        get { return exp; }
        set { exp = value; }
    }
}
