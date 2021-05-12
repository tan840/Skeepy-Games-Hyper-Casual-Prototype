using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;


/// <summary>
/// Handles the progression of the level
/// </summary>
public class LevelManager : MonoBehaviour
{
    public LevelData[] leveldata;
    public int currrentLevel = 0;
    public Slider slider;
    public static LevelManager instance;
    public Transform player;
    float distance;
    public TMP_Text[] progressBarlevelText;
    GameManager gameManager;
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

    void Start()
    {
        gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        LevelCompleteBar();
    }
    public void LevelCompleteBar()
    {
        distance = Vector3.Distance(player.position, leveldata[currrentLevel].finishPos.position);
        if (player.position.z < leveldata[currrentLevel].finishPos.position.z)
        {
            slider.DOValue(1 - (distance / getDistance()), 0.5f);
        }
    }
    float getDistance()
    {
        return Vector3.Distance(leveldata[currrentLevel].startingPos.position, leveldata[currrentLevel].finishPos.position);
    }

    public void ResetLevel()
    {
        
        slider.value = 0f;
        gameManager.startPannel.SetActive(true);
        player.position = leveldata[currrentLevel].startingPos.position; ;
        //player.DORotate(new Vector3(0f, startPos.localRotation.eulerAngles.y, 0f), 0.5f);
        //player.transform.GetChild(0).transform.DOLocalRotate(new Vector3(0, 0, 0), 1f);

        //rb.useGravity = false;
       // anim.Play("Idle");

        LevelTextTopChange();

    }
    public void LevelTextTopChange()
    {
        progressBarlevelText[0].text = (1 + currrentLevel).ToString();
        progressBarlevelText[1].text = (2 + currrentLevel).ToString();
    }
    public void LoadNextLevel()
    {

        //gameManager.startPos = leveldata[currrentLevel].startingPos;
        if (currrentLevel > 2)
        {
            leveldata[2].Level.SetActive(true);
            leveldata[1].Level.SetActive(false);
            leveldata[currrentLevel].startingPos.position = leveldata[currrentLevel].startingPos.position;
        }
        else
        {
            leveldata[currrentLevel].Level.SetActive(true);
            leveldata[currrentLevel - 1].Level.SetActive(false);
            leveldata[currrentLevel].startingPos = leveldata[currrentLevel].startingPos;
        }

        //print(currrentLevel);

        ResetLevel();

    }
    public void SetCurrentLevel()
    {
        if (currrentLevel >= leveldata.Length)
        {
            currrentLevel = leveldata.Length;
            //print("greater");
        }
        else if (currrentLevel < leveldata.Length)
        {
            //print("less");
            currrentLevel++;
            player.GetComponent<PlayerMovement>().moveSpeed += 3;
        }

        PlayerPrefs.SetInt("Level", currrentLevel);
    }
}
[System.Serializable]
public class LevelData
{
    public string LevelName;
    public Transform startingPos;
    public Transform finishPos;
    public GameObject Level;
    public int Points;
}
