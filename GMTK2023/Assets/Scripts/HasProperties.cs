using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HasProperties : MonoBehaviour
{
    public GameObject pUI;

    private void OnMouseDown()
    {
        if (GameManager.instance.currentSelected != null && GameManager.instance.currentSelected.GetComponent<HasProperties>())
            GameManager.instance.currentSelected.GetComponent<HasProperties>().pUI.gameObject.SetActive(false);
        GameManager.instance.currentSelected = gameObject;
        pUI.SetActive(true);
    }
    public void OnMouseExit()
    {
        GameManager.instance.onUI = false;
    }

    public void OnMouseOver()
    {
        GameManager.instance.onUI = true;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(GameManager.instance.onUI == false)
    }
}
