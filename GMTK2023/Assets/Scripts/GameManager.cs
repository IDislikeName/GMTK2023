using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
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
        Wait,
    }
    public GameState gState;


    public TMP_Text n;
    public TMP_Text d;

    public AudioClip bgm;
    public GameObject startButton;

    public GameObject LoseScreen;
    public GameObject WinScreen;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        currentTime = maxTime;
        currentSelected = null;
        gState = GameState.Wait;
    }

    // Update is called once per frame
    void Update()
    {
        if (gState == GameState.Playing)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                timeBar.localScale = new Vector3(currentTime, 1, 1);
            }
            else
            {
                Lose();
                
            }
            if (currentHp <= 0)
            {
                Win();
            }
            else
            {
                hpBar.localScale = new Vector3(currentHp, 1, 1);
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (currentSelected != null)
                {
                    if (currentSelected.GetComponent<ItemUI>())
                    {
                        Vector3 mousePos = Input.mousePosition;
                        mousePos.z = Camera.main.nearClipPlane;
                        Vector3 worldpos = Camera.main.ScreenToWorldPoint(mousePos);
                        Vector2 worldpos2D = new Vector2(worldpos.x, worldpos.y);
                        if (!onUI && worldpos2D.x > -29f && worldpos2D.x < 18f && worldpos2D.y < 15f && worldpos2D.y > -4.5f)
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
    public void StartGame()
    {
        playerTrans.GetComponent<PlayerAI>().currentState = PlayerAI.State.FreeRoam;
        gState = GameState.Playing;
        SoundManager.instance.PlayBGM(bgm);
        startButton.SetActive(false);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Lose()
    {
        playerTrans.GetComponent<PlayerAI>().currentState = PlayerAI.State.Staggered;
        gState = GameState.Lose;
        LoseScreen.SetActive(true);

    }
    public void Win()
    {
        hpBar.localScale = new Vector3(0, 1, 1);
        playerTrans.GetComponent<PlayerAI>().currentState = PlayerAI.State.Staggered;
        gState = GameState.Win;
        WinScreen.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
