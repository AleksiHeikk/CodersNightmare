using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour
{
    public int health = 3;

    public GameObject damageCause;

    public void PTakeDamage(int damage)
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

        Application.Quit();
    }
}
