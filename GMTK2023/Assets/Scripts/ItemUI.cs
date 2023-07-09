using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameManager.instance.currentSelected!=null&&GameManager.instance.currentSelected.GetComponent<HasProperties>())
            GameManager.instance.currentSelected.GetComponent<HasProperties>().pUI.gameObject.SetActive(false);
        GameManager.instance.currentSelected = gameObject;
    }

    public GameObject obj;

    public void OnPointerExit(PointerEventData eventData)
    {
        GameManager.instance.onUI = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
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
        
    }
}
