﻿using UnityEngine;
using System.Collections;

public class CharacterMovementKeyboardControl : CharacterMovementBaseControl
{
    void Start()
    {

    }

    void Update()
    {
        UpdateDirection();
        CheckForJump();
    }

    void CheckForJump() {
        if (Input.GetKeyDown( KeyCode.Space )) {
            Jump(); // miau
        }
    }

    void UpdateDirection()
    {
        Vector3 newDirection = Vector3.zero;

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            newDirection.z += 1;
        }

        if (Input.GetAxisRaw( "Vertical") < 0)
        {
            newDirection.z -= 1;
        }

        if (Input.GetAxisRaw( "Horizontal") > 0)
        {
            newDirection.x += 1;
        }

        if (Input.GetAxisRaw( "Horizontal") < 0)
        {
            newDirection.x -= 1;
        }

        SetDirection(newDirection);
    }
}