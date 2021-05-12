using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public LevelData[] leveldata;
    [SerializeField] private int currrentLevel = 0;

    public static LevelManager instance;

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
