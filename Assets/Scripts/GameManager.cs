using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool gameStarted;
    public bool gameEnded;
    public GameObject startPannel;
    public GameObject levelCompletePannel;
    public GameObject[] planes;
    [SerializeField] GameObject selectedPlane;
    LevelManager levelManager;

    public AudioSource audio;
    public TMP_Text score_text;
    public int score = 0;
    int index;

    //swaping Variables
    private int buttonClicks;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        levelManager = LevelManager.instance;
        audio = GetComponent<AudioSource>();
    }

    public void TapToStart_btn()
    {
        gameStarted = true;
        gameEnded = false;
        startPannel.SetActive(false);
    }
    public void LevelComplete_btn()
    {
        levelCompletePannel.SetActive(false);
        levelManager.LoadNextLevel();
    }

    public void Middle_Btn()
    {       
        checkBtnClicks();
        
        if (buttonClicks == 2)
        {
            //print("Middle btn 2nd time");
            SwapPlanes(planes[1],1);
            buttonClicks = 0;
        }
        if (buttonClicks > 0)
        {
            selectedPlane = planes[1];
            index = 1;
        }
    }
    public void Left_Btn()
    {
        checkBtnClicks();
        if (buttonClicks == 2)
        {
           // print("left btn 2nd time");
            SwapPlanes(planes[0], 0);
            buttonClicks = 0;
        }
        if (buttonClicks > 0)
        {
            selectedPlane = planes[0];
            index = 0;
        }
    }
    public void Right_Btn()
    {
        checkBtnClicks();
        if (buttonClicks == 2)
        {
           // print("left btn 2nd time");
            SwapPlanes(planes[2],2);
            buttonClicks = 0;
        }
        if (buttonClicks > 0)
        {
            selectedPlane = planes[2];
            index = 2;
        }
    }
    void SwapPlanes(GameObject sceondPlane ,int num)
    {
        
        Vector3 pos1 = selectedPlane.transform.position;
        Vector3 pos2 = sceondPlane.transform.position;
        sceondPlane.transform.position = pos1;
        GameObject temp = selectedPlane;
        planes[index] = sceondPlane;
        planes[num] = selectedPlane;
        selectedPlane.transform.position = pos2;

    }

    void checkBtnClicks()
    {
        buttonClicks++;
        if (buttonClicks>2)
        {
            buttonClicks = 0;
        }
    }

    public void point()
    {
        score += 5;
        score_text.text = score.ToString();
        audio.Play();
        
    }
    public void DeductPoint()
    {
        score -= 5;
        score_text.text = score.ToString();
        audio.Play();

    }
}
