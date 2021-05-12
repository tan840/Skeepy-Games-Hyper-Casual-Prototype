using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Detects the collison of the coloured holes
/// </summary>
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
            //print("Match");
            gameManager.point();
        }
        else
        {
            gameManager.DeductPoint();
        }
        if (other.gameObject.CompareTag("End"))
        {
            //print("End");
            gameManager.gameEnded = true;
            gameManager.gameStarted = false;
            gameManager.levelCompletePannel.SetActive(true);
            levelManager.SetCurrentLevel();
            levelManager.slider.value = 1;

        }
    }
}
