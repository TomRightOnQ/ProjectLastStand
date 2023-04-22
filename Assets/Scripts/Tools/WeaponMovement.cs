using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Control the movements of weapon
public class WeaponMovement : MonoBehaviour
{
    void Update()
    {
        // Get the position of the mouse relative to the player
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.y - transform.position.y;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        // Rotate the weapon to point towards the mouse
        Vector3 weaponPos = transform.position;
        Vector3 direction = (mouseWorldPos - weaponPos).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = lookRotation * Quaternion.Euler(0f, 0f, 90f);
    }
}
