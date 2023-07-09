using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    public Transform playerTrans;

    public int maxHp = 100;
    public float currentHp;
    public RectTransform hpBar;

    public int maxTime = 180;
    public float currentTime;
    public RectTransform timeBar;

    public GameObject currentSelected;
    public bool onUI;

    public enum GameState
    {
        Win,
        Lose,
        Playing,
        wait,
    }
    public GameState gState;


    public TMP_Text n;
    public TMP_Text d;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        currentTime = maxTime;
        currentSelected = null;
        gState = GameState.Playing;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime >0)
        {
            currentTime -= Time.deltaTime;
            timeBar.localScale = new Vector3( currentTime,1,1);
        }
        else
        {
            //lose
        }
        if (currentHp <= 0)
        {
            //win
        }
        else
        {
            hpBar.localScale = new Vector3(currentHp, 1, 1);
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (currentSelected!=null)
            {
                if (currentSelected.GetComponent<ItemUI>())
                {
                    Vector3 mousePos = Input.mousePosition;
                    mousePos.z = Camera.main.nearClipPlane;
                    Vector3 worldpos = Camera.main.ScreenToWorldPoint(mousePos);
                    Vector2 worldpos2D = new Vector2(worldpos.x, worldpos.y);
                    if (!onUI&&worldpos2D.x > -29f && worldpos2D.x < 18f && worldpos2D.y < 15f && worldpos2D.y > -4.5f)
                    {
                        GameObject o = Instantiate(currentSelected.GetComponent<ItemUI>().obj);
                        o.transform.position = worldpos2D;
                        currentSelected = null;
                    }
                    else if (!onUI)
                    {
                        currentSelected = null;
                    }

                }
                else if (currentSelected.GetComponent<HasProperties>())
                {
                    if (!onUI)
                    {
                        currentSelected.GetComponent<HasProperties>().pUI.SetActive(false);
                        n.text = "";
                        d.text = "";
                        currentSelected = null;
                    }
                }

                
            }
        }
    }
}
