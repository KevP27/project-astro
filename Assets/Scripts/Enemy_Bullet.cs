using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    void Update()
    {
        if (transform.position.x > 100)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        Enemy enemy = hitInfo.GetComponent<Enemy>();

        if (player != null)
        {
            player.TakeDamage(damage);
        }

        if (enemy != null)
        {
            Destroy(gameObject);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }

}
