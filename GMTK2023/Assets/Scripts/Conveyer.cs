using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyer : HasProperties
{
    public int direction = 1;
    public float force = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Rotate()
    {
        transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + 90f);
        direction++;
        if (direction > 4)
        {
            direction = 1;
        }
        GetComponent<Animator>().SetInteger("Direction",direction);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInParent<PlayerAI>().currentState = PlayerAI.State.Staggered;
            collision.gameObject.GetComponentInParent<Rigidbody2D>().velocity = transform.up * force;
        }
        else if (collision.GetComponent<BoxTrap>())
        {
            if (collision.GetComponent<BoxTrap>().type == 1)
            {
                collision.gameObject.GetComponentInParent<Rigidbody2D>().velocity = transform.up * force;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInParent<Rigidbody2D>().velocity = Vector2.zero;
            collision.transform.up = transform.up;
            collision.gameObject.GetComponentInParent<PlayerAI>().currentState = PlayerAI.State.FreeRoam;
        }
    }
}
