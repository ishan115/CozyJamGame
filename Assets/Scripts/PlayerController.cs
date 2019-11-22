﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    public float Speed = 10f;
    public float maxSpeed = 100f;

    // TODO not have this hard coded and get the bounds of the camera
    float cameraMax = 9.3f;
    Vector3 cameraPos;

    void Start()
    {
        // IDk why this is here might remove
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Debug.Log("Position: " + rb.position.x);

        // Moves the player
        if (Input.GetKey("d") && rb.velocity.x < maxSpeed && rb.position.x <= cameraMax)
        {
            rb.AddForce(transform.right * Speed);
        }
        if (Input.GetKey("a") && rb.velocity.x > -maxSpeed && rb.position.x >= -cameraMax)
        {
            rb.AddForce(transform.right * -Speed);
        }

        // Slows the velocity after moving so the player isn't sliding
        if (rb.velocity.x > 0f)
        {
            rb.AddForce(transform.right * -6);
        }
        if (rb.velocity.x < 0f)
        {
            rb.AddForce(transform.right * 6);
        }

        // Keeps the player on screen // TODO change the 2 float values depending on sprite
        cameraPos = Camera.main.WorldToViewportPoint(rb.position);
        cameraPos.x = Mathf.Clamp(cameraPos.x, 0.02f, .98f);
        transform.position = Camera.main.ViewportToWorldPoint(cameraPos);

        Debug.Log("Velocity: " + rb.velocity.x);
    }
}