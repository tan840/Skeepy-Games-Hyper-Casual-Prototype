using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameStarted;
    public bool gameEnded;
    public GameObject startPannel;
    public GameObject[] planes;
    [SerializeField] GameObject selectedPlane;

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

    public void TapToStart_btn()
    {
        gameStarted = true;
        startPannel.SetActive(false);
    }

    public void Middle_Btn()
    {       
        checkBtnClicks();
        
        if (buttonClicks == 2)
        {
            print("Middle btn 2nd time");
            SwapPlanes(planes[1]);
            buttonClicks = 0;
        }
        if (buttonClicks > 0)
        {
            selectedPlane = planes[1];
        }
    }
    public void Left_Btn()
    {
        checkBtnClicks();
        if (buttonClicks == 2)
        {
            print("left btn 2nd time");
            SwapPlanes(planes[0]);
            buttonClicks = 0;
        }
        if (buttonClicks > 0)
        {
            selectedPlane = planes[0];
        }
    }
    public void Right_Btn()
    {
        checkBtnClicks();
        if (buttonClicks == 2)
        {
            print("left btn 2nd time");
            SwapPlanes(planes[2]);
            buttonClicks = 0;
        }
        if (buttonClicks > 0)
        {
            selectedPlane = planes[2];
        }
    }
    void SwapPlanes(GameObject sceondPlane)
    {
        
        Vector3 pos1 = selectedPlane.transform.position;
        Vector3 pos2 = sceondPlane.transform.position;
        sceondPlane.transform.position = pos1;
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
}
