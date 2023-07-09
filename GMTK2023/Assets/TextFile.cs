using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class TextFile : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject selected;
    public bool hovering;
    public GameObject text;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!selected.activeSelf)
        {
            selected.SetActive(true);
        }
        else
        {
            text.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!hovering)
            {
                selected.SetActive(false);
            }
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        hovering = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        hovering = false;
    }
    public void Close()
    {
        text.SetActive(false);
    }
}
