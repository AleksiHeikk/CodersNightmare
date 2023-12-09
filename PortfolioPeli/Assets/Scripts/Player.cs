using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerScore;
    public int health = 3;
    public float moveSpeed = 5.0f;
    private float shootCooldown = 0.5f;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform m_bulletSpawn;
    [SerializeField] private GameObject damageCause;
    
    private Rigidbody2D rb;
    private Animator anim;

    private bool canShoot = true;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
        public void Shoot()
        {
            if (canShoot)
            {
                Instantiate(bullet, m_bulletSpawn.position, m_bulletSpawn.rotation);

                StartCoroutine(ShootCooldown());
                StartCoroutine(ShootAnimation());

                anim.SetBool("Attack", true);
                anim.SetBool("Idle", false);
                anim.SetBool("Walk", false);
        }

        
    }
    private IEnumerator ShootAnimation() {
        yield return new WaitForSeconds(0.25f);
        anim.SetBool("Attack", false);
    }

    IEnumerator ShootCooldown()
        {
            canShoot = false;
            yield return new WaitForSeconds(shootCooldown);
            canShoot = true;
        }

        public void UpdateScore(int enemyPoints)
    {
        playerScore += enemyPoints;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime;
        transform.position += movement;
        if (horizontalInput != 0)
        {
            anim.SetBool("Idle", false);
            // anim.SetBool("Attack", false);
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
            // anim.SetBool("Attack", false);
            anim.SetBool("Idle", true);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

    }

    public void PTakeDamage(int damage)
    {
        health -= damage;
        playerScore -= 150;

        if (health <= 0)
        {
            Die();
        }
    }
    private IEnumerator DieEnumerator()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        Application.Quit();
    }
    void Die()
    {
        anim.SetBool("Death", true);
        StartCoroutine(DieEnumerator());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
     if (other.CompareTag("Border"))
        {
            rb.velocity = Vector2.zero;
        }
    }
}
