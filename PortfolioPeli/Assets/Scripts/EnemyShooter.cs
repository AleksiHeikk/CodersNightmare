using System.Collections;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] GameObject enemyBullet;
    [SerializeField] private Transform enemyBulletSpawn;
    [SerializeField] private float minDuration = 5.0f;
    [SerializeField] private float maxDuration = 10.0f;
    private float durationTimer;

    void Start()
    {
        durationTimer = Random.Range(minDuration, maxDuration);
    }

    void Update()
    {
        EShoot();
    }

    public void EShoot()
    {
        durationTimer -= Time.deltaTime;

        if (durationTimer > 0) return;

        durationTimer = Random.Range(minDuration, maxDuration);

        Instantiate(enemyBullet, enemyBulletSpawn.position, enemyBulletSpawn.rotation);
    }
}
