using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public int damage = 1;

    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyDamaged enemyDestroy = hitInfo.GetComponent<EnemyDamaged>();
        if (enemyDestroy != null)
        {
            enemyDestroy.TakeDamage(damage);
        }

        Destroy(gameObject);
        Debug.Log("Enemy hit");
    }
}

