using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public int damage = 1;

    public Sprite[]  bulletSprites;
    public SpriteRenderer sr;

    void Start()
    {
        rb.velocity = transform.up * speed;
        sr = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyDamaged enemyDestroy = other.GetComponent<EnemyDamaged>();
            if (enemyDestroy != null)
            {
                enemyDestroy.TakeDamage(damage);
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }

    // tänne viel että player bulletin img/sprite on random valikoitu vaihtoehdosta
     void Update()
    {
        int randomSprite = Random.Range(0, bulletSprites.Length);
        Sprite selectedSprite = bulletSprites[randomSprite];
    }
}

