using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float leftBound = -5.0f;
    public float rightBound = 5.0f;

    private int direction = 1; // 1 for right, -1 for left

    [SerializeField] GameObject enemyBullet;
    [SerializeField] private Transform enemyBulletSpawn;
    public bool isShooter;
    [SerializeField] private float duration = 5f;
    private float durationTimer;

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(direction * moveSpeed * Time.deltaTime, 0, 0);
        transform.Translate(movement, Space.World);

        if (transform.position.x > rightBound || transform.position.x <= leftBound)
        {
            direction *= -1; 
        }

        if (isShooter)
        {
            EShoot();
        }
    }
    public void EShoot() {

        durationTimer -= Time.deltaTime;

        if (durationTimer > 0) return;

        durationTimer = duration;

        Instantiate(enemyBullet, enemyBulletSpawn.position, enemyBulletSpawn.rotation);
    }
}

