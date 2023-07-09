using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public int dmg;
    Collider2D[] inexplosion = null;

    public float exploradius = 5;

    public float exploforce = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.currentHp -= dmg;
        }
        inexplosion = Physics2D.OverlapCircleAll(transform.position, exploradius);


        foreach (Collider2D o in inexplosion)
        {
            Rigidbody2D rb = o.GetComponent<Rigidbody2D>();

            if (rb != null)
            {

                Vector2 distex = o.transform.position - transform.position;

                if (distex.magnitude > 0)
                {

                    float explosionForce = exploforce / distex.magnitude;

                    rb.AddForce(distex.normalized * explosionForce);

                }

            }

        }

    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
