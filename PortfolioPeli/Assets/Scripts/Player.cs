using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerScore;
    public int health = 3;
    public float moveSpeed = 5.0f;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform m_bulletSpawn;
    [SerializeField] private GameObject damageCause;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Shoot()
    {
        Instantiate(bullet, m_bulletSpawn.position, m_bulletSpawn.rotation);
        anim.SetBool("Attack", true);
        anim.SetBool("Idle", false);
        anim.SetBool("Walk", false);
    }

    public void UpdateScore(int enemyPoints)
    {
        playerScore += enemyPoints;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        else if (horizontalInput != 0)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Attack", false);
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Attack", false);
            anim.SetBool("Idle", true);
        }
    }

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
        anim.SetTrigger("Die");
        Instantiate(damageCause, transform.position, Quaternion.identity);

        StartCoroutine(QuitGameAfterDelay(2.0f));
    }

    IEnumerator QuitGameAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Application.Quit();
    }
}
