using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float playerScore;
    public float moveSpeed = 5.0f;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform m_bulletSpawn;


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
}
