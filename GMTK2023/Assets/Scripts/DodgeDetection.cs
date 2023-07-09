using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeDetection : MonoBehaviour
{
    private PlayerAI ai;
    // Start is called before the first frame update
    void Start()
    {
        ai = GetComponentInParent<PlayerAI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Danger")||collision.CompareTag("Corner"))
        {
            ai.dodgeList.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(ai.dodgeList.Contains(collision.gameObject))
            ai.dodgeList.Remove(collision.gameObject);
    }
}
