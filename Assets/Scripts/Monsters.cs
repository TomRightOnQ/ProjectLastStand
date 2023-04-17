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
}
