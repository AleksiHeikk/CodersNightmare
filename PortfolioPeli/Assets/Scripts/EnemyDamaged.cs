using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamaged : MonoBehaviour
{
    public int health = 1;
    public GameObject damageCause;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(damageCause, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
