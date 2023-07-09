using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : HasProperties
{
    public bool isTriggerMine = false;
    public GameObject explosion_trigger;
    public GameObject explosion_dynamite;

    public AudioClip trigger_impact;

    public AudioClip dynamite_impact;
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
            StartCoroutine(Explode());
        }
        if (isTriggerMine == true && collision.CompareTag("Trigger"))
        {
            StartCoroutine(Explode());
        }
        
    }
    IEnumerator Explode()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject o;
        if (isTriggerMine)
        {
            SoundManager.instance.PlayClip(trigger_impact);
            o = Instantiate(explosion_trigger);
        }
        else
        {
            SoundManager.instance.PlayClip(dynamite_impact);
            o = Instantiate(explosion_dynamite);
        }
        
        o.transform.position = transform.position;
        Destroy(gameObject);
    }

    public void SetTrigger()
    {
        isTriggerMine = true;
        GetComponent<Animator>().SetBool("IsTrigger",true);
    }
    public void SetDynamite()
    {
        isTriggerMine = false;
        GetComponent<Animator>().SetBool("IsTrigger", false);
    }
}
