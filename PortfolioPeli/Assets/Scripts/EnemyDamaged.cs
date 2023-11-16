using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamaged : MonoBehaviour
{
    public int health = 1;
    public GameObject damageCause;

    public float enemyPoints = 100f;
    private Player player;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
            GainPoints();
        }
    }

    void Die()
    {
        Instantiate(damageCause, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void GainPoints()
    {
        player = GetComponent<Player>();

        if (player != null)
        {
            player.UpdateScore(enemyPoints);
        }
    }
}
