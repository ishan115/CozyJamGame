using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;

    public Camera cam;
    Vector2 mousePosition;

    float angle;
    void Update()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Vector2 lookDirection = (mousePosition - (Vector2) transform.position).normalized;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        transform.RotateAround(playerTransform.up, angle);
        transform.up = lookDirection;

    }
}
