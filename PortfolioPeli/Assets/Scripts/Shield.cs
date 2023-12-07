using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private int health;

    public Sprite[] states;
    private SpriteRenderer sr;

    void Start()
    {
        health = 4;
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            health--;
            Debug.Log("Shield hit");
            Destroy(collision.gameObject);

            if (health <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                sr.sprite = states[health - 1];
                Debug.Log("New shield state");
            }
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }
    }

}


