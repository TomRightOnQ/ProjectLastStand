using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player camera and movements
public class PlayerMovement : MonoBehaviour
{
    private Camera _camera;
    private Players player;

    void Start()
    {
        player = GetComponent<Players>();
        _camera = Camera.main;
    }

    void Update()
    {
        float horizontalInput = 0.0f;
        float verticalInput = 0.0f;

        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = 1.0f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1.0f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            verticalInput = -1.0f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1.0f;
        }

        Vector3 direction = new Vector3(horizontalInput, 0.0f, verticalInput);
        direction = Vector3.ClampMagnitude(direction, 1.0f);

        Vector3 movement = direction * player.Speed * Time.deltaTime;
        transform.position += movement;
        _camera.transform.position = new Vector3(transform.position.x, _camera.transform.position.y, transform.position.z - 51.9f);
    }
}
