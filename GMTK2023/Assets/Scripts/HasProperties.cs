using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HasProperties : MonoBehaviour
{
    public GameObject pUI;
    public string n;
    [TextArea(15, 20)]
    public string d;

    private void OnMouseDown()
    {
        if (GameManager.instance.currentSelected != null && GameManager.instance.currentSelected.GetComponent<HasProperties>())
        {
            GameManager.instance.currentSelected.GetComponent<HasProperties>().pUI.gameObject.SetActive(false);
            GameManager.instance.n.text = "";
            GameManager.instance.d.text = "";
        }
            
        GameManager.instance.currentSelected = gameObject;
        pUI.SetActive(true);
        GameManager.instance.n.text = n;
        GameManager.instance.d.text = d;
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
        GetComponentInChildren<Canvas>().worldCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //if(GameManager.instance.onUI == false)
    }
}
