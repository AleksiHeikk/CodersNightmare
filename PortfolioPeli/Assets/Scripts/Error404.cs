using System.Collections;
using UnityEngine;

public class Error404 : MonoBehaviour
{
    [SerializeField] GameObject enemyBullet;
    [SerializeField] private Transform enemyBulletSpawn1;
    [SerializeField] private Transform enemyBulletSpawn2;
    [SerializeField] private float minDuration = 5.0f;
    [SerializeField] private float maxDuration = 10.0f;
    private float durationTimer;

    [SerializeField] private AudioSource errorAudio;

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

        Instantiate(enemyBullet, enemyBulletSpawn1.position, enemyBulletSpawn1.rotation);
        Instantiate(enemyBullet, enemyBulletSpawn2.position, enemyBulletSpawn2.rotation);

        errorAudio.Play();
    }
}
