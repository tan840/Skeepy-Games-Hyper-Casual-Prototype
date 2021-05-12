using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourDetector : MonoBehaviour
{
    public string colour;
    GameManager gameManager;
    LevelManager levelManager;
    private void Start()
    {
        gameManager = GameManager.instance;
        levelManager = LevelManager.instance;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(colour))
        {
            print("Match");
        }
        if (other.gameObject.CompareTag("End"))
        {
            print("End");
            gameManager.gameEnded = true;
            gameManager.gameStarted = false;
            gameManager.levelCompletePannel.SetActive(true);
            levelManager.SetCurrentLevel();

        }
    }
}
