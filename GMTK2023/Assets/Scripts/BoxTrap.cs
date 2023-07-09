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

    public AudioClip ironblock_spawn;
    public AudioClip TNT_spawn;
    public AudioClip lightning_spawn;
    public AudioClip ironblock_hit;
    public AudioClip TNT_hit;
    public AudioClip lightning_hit;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(Die());
        SoundManager.instance.PlayClip(ironblock_spawn);
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(7f);
        Destroy(gameObject);
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
            if (collision.collider.CompareTag("Player"))
            {
                if (rb.velocity.magnitude>4f)
                {
                    GameManager.instance.currentHp -= ironDmg;
                    SoundManager.instance.PlayClip(ironblock_hit);
                    Destroy(gameObject);
                }
            }
        }

        if (type == 3)
        {
            if(collision.collider.CompareTag("Player"))
            {
                //anim.SetTrigger("Hurt");
                GameManager.instance.currentHp -= elecDmg;
                SoundManager.instance.PlayClip(lightning_hit);
                Destroy(gameObject);
            }
        }
        
    }
    public void Explode()
    {
        GameObject e =  Instantiate(explosion);
        e.transform.position = transform.position;
        SoundManager.instance.PlayClip(TNT_hit);
        Destroy(gameObject);
    }

    public void Iron()
    {
        type = 1;
        SoundManager.instance.PlayClip(ironblock_spawn);
    }
    public void TNT()
    {
        type = 2;
        SoundManager.instance.PlayClip(TNT_spawn);
    }
    public void Electric()
    {
        type = 3; SoundManager.instance.PlayClip(lightning_spawn);
    }
}
