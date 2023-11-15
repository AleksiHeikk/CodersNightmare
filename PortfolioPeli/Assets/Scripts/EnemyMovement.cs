using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float leftBound = -5.0f;
    public float rightBound = 5.0f;

    private int direction = 1; // 1 for right, -1 for left

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(direction * moveSpeed * Time.deltaTime, 0, 0);
        transform.Translate(movement, Space.World);

        if (transform.position.x > rightBound || transform.position.x <= leftBound)
        {
            direction *= -1;
        }
    }
}

