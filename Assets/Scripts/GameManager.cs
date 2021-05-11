using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameStarted;
    public bool gameEnded;
    public GameObject startPannel;

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
}
