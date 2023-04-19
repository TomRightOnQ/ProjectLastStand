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

    // Weapon Indices
    [SerializeField] private int weapon1 = 0;

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

    public int Weapon1
    {
        get { return weapon1; }
        set { weapon1 = value; }
    }

    // Attack!
    public void fire() {
        // Get projectile from pool
        Projectiles proj = GameManager.Instance.dataManager.TakeProjPool();

        if (proj != null)
        {
            // Get a plane for bullets to move along
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.up, transform.position);
            float distanceToPlane;

            if (plane.Raycast(ray, out distanceToPlane))
            {
                // Get the position of mouse
                Vector3 mousePosition = ray.GetPoint(distanceToPlane);
                Vector3 direction = (mousePosition - transform.position).normalized;

                // Config the Projectile
                proj.transform.position = transform.position;
                proj.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
                proj.Damage = 100;
                proj.Owner = 1;
                proj.Life = 10.0f;
                proj.SelfDet = true;
                proj.Player = true;
                direction.y = 0f;
                proj.GetComponent<Rigidbody>().velocity = direction * 10f;
            }
        }
    }
}
