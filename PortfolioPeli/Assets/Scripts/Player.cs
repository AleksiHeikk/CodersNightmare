using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform m_bulletSpawn;

    public void Shoot()
    {
        Instantiate(bullet, m_bulletSpawn.position, m_bulletSpawn.rotation);
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
