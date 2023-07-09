using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : HasProperties
{
    public float shootCD = 3f;
    float currentCD = 0;
    [SerializeField]
    GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currentCD >= shootCD)
        {
            Shoot();
            currentCD = 0;
        }
        else
        {
            currentCD += Time.deltaTime;
        }
    }
    void Shoot()
    {
        GameObject b = Instantiate(bullet);
        bullet.transform.position = transform.position;
        bullet.transform.up = transform.up;
        //bullet.transform.up = ((Vector2)GameManager.instance.playerTrans.position - (Vector2)transform.position).normalized;
    }

    public void CRotate()
    {
        transform.rotation = Quaternion.Euler(0,0,transform.eulerAngles.z+45f);
    }
}
