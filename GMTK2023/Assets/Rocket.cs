using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : HasProperties
{
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
        transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z -90f);
    }
}
