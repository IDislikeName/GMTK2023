using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class United : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject selected;
    public GameObject loading;
    public bool hovering;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!selected.activeSelf)
        {
            selected.SetActive(true);
        }
        else if(!loading.activeSelf)
        {
            StartCoroutine(St());
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
    IEnumerator St()
    {
        loading.SetActive(true);
        yield return new WaitForSeconds(3f);
        Menu.instance.StartGame();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovering = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        hovering = false;
    }

    
}
