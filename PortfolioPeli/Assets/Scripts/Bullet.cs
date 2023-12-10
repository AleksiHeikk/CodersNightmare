using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public int damage = 1;

    public Sprite[] bulletSprites;
    public SpriteRenderer sr;

    private float timeBetweenSpriteChanges = 0.5f; 
    private float timer = 0f;

    void Start()
    {
        rb.velocity = transform.up * speed;
        sr = GetComponent<SpriteRenderer>();
        SetRandomSprite();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyDamaged enemyDamageHandler = other.GetComponent<EnemyDamaged>();
            if (enemyDamageHandler != null)
            {
                enemyDamageHandler.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
        Destroy(gameObject);
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenSpriteChanges)
        {
            SetRandomSprite();
            timer = 0f;
        }
    }

    void SetRandomSprite()
    {
        int randomSprite = Random.Range(0, bulletSprites.Length);
        sr.sprite = bulletSprites[randomSprite];
    }
}
