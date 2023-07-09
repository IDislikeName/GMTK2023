using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int dmg;
    public int speed;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rb.velocity = transform.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.currentHp -= dmg;
            Destroy(gameObject);
        }
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        if (collision.GetComponent<BoxTrap>())
        {
            if (collision.GetComponent<BoxTrap>().type == 2)
            {
                collision.GetComponent<BoxTrap>().Explode();
            }
            Destroy(gameObject);
        }
    }
}
