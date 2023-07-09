using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenLeg : HasProperties
{
    public int healAmt = 10;
    public AudioClip chicken_eat;
    public AudioClip chicken_spawn;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.playerTrans.GetComponent<PlayerAI>().chickenList.Add(gameObject);
        SoundManager.instance.PlayClip(chicken_spawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.currentHp += 10;
            GameManager.instance.currentHp = Mathf.Min(GameManager.instance.currentHp, GameManager.instance.maxHp);
            GameManager.instance.playerTrans.GetComponent<PlayerAI>().chickenList.Remove(gameObject);
            SoundManager.instance.PlayClip(chicken_eat);
            Destroy(gameObject);
        }
    }
}
