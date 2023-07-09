using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspector : MonoBehaviour
{
    public void OnMouseExit()
    {
        GameManager.instance.onUI = false;
    }

    public void OnMouseOver()
    {
        GameManager.instance.onUI = true;

    }
}
