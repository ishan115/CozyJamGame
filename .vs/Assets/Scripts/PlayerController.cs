using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    public float Speed = 15f;
    public float maxSpeed = 100f;

    private Animator playerAnim;

    // TODO not have this hard coded and get the bounds of the camera
    float cameraMax = 9.3f;
    Vector3 cameraPos;

    void Start()
    {
        // IDk why this is here might remove
        rb = GetComponent<Rigidbody2D>();

        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
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

        // Keeps the player on screen 
        cameraPos = Camera.main.WorldToViewportPoint(rb.position);
        // TODO change the 2 float values depending on sprite
        cameraPos.x = Mathf.Clamp(cameraPos.x, 0.02f, .98f);
        transform.position = Camera.main.ViewportToWorldPoint(cameraPos);

        
        if (Input.GetKey(KeyCode.A))
        {
            playerAnim.SetBool("A_Down", true);
        }
        else
        {
            playerAnim.SetBool("A_Down", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerAnim.SetBool("D_Down", true);
        }
        else
        {
            playerAnim.SetBool("D_Down", false);
        }
        
    }
}