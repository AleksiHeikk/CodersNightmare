using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{

    public float speed = 5f;
    public Rigidbody2D ribo;
    public int damage = 1;

    // public int bulletPoints = 50;

    void Start()
    {
        ribo.velocity = -transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player playerDestroy = hitInfo.GetComponent<Player>();
        if (playerDestroy != null)
        {
            playerDestroy.PTakeDamage(damage);
        }

        Destroy(gameObject);
        Debug.Log("Player hit");
    }

    // tähän tulis viel jos pelaaja tuhoaa vihollisten ammus niin saa 50 pistettä
   /* void PlayerDestroysEBullet()
    {
        if (Player destroyes BulletEnemy){
            player.UpdateScore(bulletPoints);

        }
    } */
}
