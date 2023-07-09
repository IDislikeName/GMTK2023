using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrap : HasProperties
{
    public int type = 1;
    private Rigidbody2D rb;
    public int ironDmg = 40;
    public GameObject explosion;
    public int elecDmg = 10;
    public Sprite[] sprites;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (type == 3)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        sr.sprite = sprites[type - 1];
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (type == 1)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (rb.velocity.magnitude > 4)
                {
                    GameManager.instance.currentHp -= ironDmg;
                }
            }
        }
        if (type == 2)
        {
            if (collision.gameObject.CompareTag("Trigger") || collision.gameObject.GetComponent<Bullet>())
            {
                Explode();
            }
        }
        if (type == 3)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                //anim.SetTrigger("Hurt");
                GameManager.instance.currentHp -= elecDmg;
            }
        }
        
    }
    public void Explode()
    {
        GameObject e =  Instantiate(explosion);
        e.transform.position = transform.position;
        Destroy(gameObject);
    }

    public void Iron()
    {
        type = 1;
    }
    public void TNT()
    {
        type = 2;
    }
    public void Electric()
    {
        type = 3;
    }
}
