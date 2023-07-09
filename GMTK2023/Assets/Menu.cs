using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static Menu instance;

    public AudioClip close;
    public AudioClip open;
    public AudioClip click;
    public GameObject shutDown;
    public static Menu FindInstance()
    {
        return instance; //that's just a singletone as the region says
    }

    void Awake() //this happens before the game even starts and it's a part of the singletone
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else if (instance == null)
        {
            //DontDestroyOnLoad(this);
            instance = this;
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
            SoundManager.instance.PlayClip(click);
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        StartCoroutine(Q());
    }
    IEnumerator Q()
    {
        yield return new WaitForSeconds(4f);
        SoundManager.instance.PlayClip(close);
        Application.Quit();
    }
    public void Wind()
    {
        if (!shutDown.activeSelf)
        {
            shutDown.SetActive(true);
        }
        else
        {
            shutDown.SetActive(false);
        }
    }

}
