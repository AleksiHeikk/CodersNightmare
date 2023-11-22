using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float playerScore;
    public int health = 3;
    public float moveSpeed = 5.0f;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform m_bulletSpawn;
    [SerializeField] private GameObject damageCause;


    private Animator anim;

    public void Shoot()
    {
        Instantiate(bullet, m_bulletSpawn.position, m_bulletSpawn.rotation);
    }

    public void UpdateScore(int enemyPoints)
    {
        playerScore += enemyPoints;
    }


    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void PTakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
            Application.Quit();
        }
    }

    void Die()
    {
        Instantiate(damageCause, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
