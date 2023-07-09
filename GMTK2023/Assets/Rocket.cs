using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : HasProperties
{
    Rigidbody2D rb;
    public int speed;
    Animator anim;
    public bool moving = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            rb.velocity = transform.up * speed;
        }
    }
    public void Rotate()
    {
        transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z -90f);
    }
    public void Launch()
    {
        anim.SetBool("Moving",true);
        moving = true;
        StartCoroutine(SelfDestruct());
        
    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(3f);
        moving = false;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
