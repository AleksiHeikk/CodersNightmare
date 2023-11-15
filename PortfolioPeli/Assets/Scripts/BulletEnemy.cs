using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{


    public float speed = 5f;
    public Rigidbody2D ribo;
    public int damage = 1;

    void Start()
    {
        ribo.velocity = -transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerDamaged enemyDestroy = hitInfo.GetComponent<PlayerDamaged>();
        if (enemyDestroy != null)
        {
            enemyDestroy.PTakeDamage(damage);
        }

        Destroy(gameObject);
        Debug.Log("Enemy hit");
    }

}
