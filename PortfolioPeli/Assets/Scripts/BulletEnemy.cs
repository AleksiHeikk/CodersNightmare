using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{

    public float speed = 5f;
    public Rigidbody2D ribo;
    public int damage = 1;

    public int bulletPoints = 50;

    void Start()
    {
        ribo.velocity = -transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player playerDestroy = other.GetComponent<Player>();
            if (playerDestroy != null)
            {
                playerDestroy.PTakeDamage(damage);
            }
        }
        else if (other.CompareTag("Bullet"))
        {
            PlayerDestroysEBullet();
        }

        Destroy(gameObject);
    }


    void PlayerDestroysEBullet()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
            if (player != null)
            {
                player.UpdateScore(bulletPoints);
            }
        }
    }
}
