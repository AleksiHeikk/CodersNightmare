using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] GameObject enemyBullet;
    [SerializeField] private Transform enemyBulletSpawn;
    public bool isShooter;
    [SerializeField] private float duration = 5f;
    private float durationTimer;

    void FixedUpdate()
    {
        if (isShooter)
        {
            EShoot();
        }
    }
    public void EShoot()
    {

        durationTimer -= Time.deltaTime;

        if (durationTimer > 0) return;

        durationTimer = duration;

        Instantiate(enemyBullet, enemyBulletSpawn.position, enemyBulletSpawn.rotation);
    }
}
