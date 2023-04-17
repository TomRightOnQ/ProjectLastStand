using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// All players are a Players object
public class Players : Entities
{
    void Start() {
        gameObject.tag = "Player";
    }
    // Player 1 - 4
    [SerializeField] private int index = 0;
    [SerializeField] private float fortune = 1;

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
}
