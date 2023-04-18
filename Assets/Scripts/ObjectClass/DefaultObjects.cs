using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DefaultObjects indicate the base of all game objects

public abstract class DefaultObjects : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
}
