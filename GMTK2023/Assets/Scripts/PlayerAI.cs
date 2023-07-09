using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PlayerAI : MonoBehaviour
{
    public int speed = 5;
    public float changeDirTimer = 3f;
    float currentTimer = 0;
    private Rigidbody2D rb;
    private Animator anim;

    public enum State
    {
        FreeRoam,
        Dodging,
        Staggered,
    }
    public State currentState;

    public List<GameObject> dodgeList;
    public List<GameObject> chickenList;
    // Start is called before the first frame update
    void Start()
    {
        currentState = State.Staggered;
        rb = GetComponent<Rigidbody2D>();
        dodgeList = new List<GameObject>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StateUpdate();
        if (currentState == State.FreeRoam)
        {
            if (GameManager.instance.currentHp <= GameManager.instance.maxHp)
            {
                if(chickenList.Count != 0)
                {
                    if (chickenList.Count > 1)
                    {
                        chickenList = chickenList.OrderBy(x => Vector2.Distance(this.transform.position, x.transform.position)).ToList();
                    }
                    if (Vector2.Distance(transform.position, chickenList[0].transform.position) < 10f)
                    {
                        rb.velocity = ((chickenList[0].transform.position - transform.position).normalized)*speed;
                    }
                }
                
            }
            if (currentTimer >= changeDirTimer)
            {
                rb.velocity = new Vector2(Random.Range(-1, 2) * speed, Random.Range(-1, 2) * speed);
                
                currentTimer = 0;
                changeDirTimer = Random.Range(0.5f, 2.5f) ;
            }
            else
            {
                currentTimer += Time.deltaTime;
            }
            /*if (rb.velocity == Vector2.zero)
            {
                currentTimer = changeDirTimer;
            }*/
        }
        else if(currentState == State.Dodging)
        {
            
            if (dodgeList.Count != 0)
            {
                if( dodgeList.Count > 1)
                {
                    dodgeList = dodgeList.OrderBy(x => Vector2.Distance(this.transform.position, x.transform.position)).ToList();
                }
                
                GameObject currentObj = dodgeList[0];
                Vector2 posDiff = (currentObj.transform.position - transform.position).normalized;
                rb.velocity = -posDiff * speed;
            }             

        }
        else if (currentState == State.Staggered)
        {

        }

        if (rb.velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            anim.SetInteger("Horizontal",1);
        }
        else if (rb.velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            anim.SetInteger("Horizontal", 1);
        }
        else
        {
            anim.SetInteger("Horizontal", 0);
        }
        if (rb.velocity.y > 0)
        {
            anim.SetInteger("Vertical", 1);
        }
        else
        {
            anim.SetInteger("Vertical", -1);
        }
    }

    void StateUpdate()
    {
        if (currentState != State.Staggered)
        {
            if (dodgeList.Count > 0)
            {
                currentState = State.Dodging;
            }
            else
            {
                currentState = State.FreeRoam;
            }
        }
        
    }
}


