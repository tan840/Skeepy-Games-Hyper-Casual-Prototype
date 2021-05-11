using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }
    private void Update()
    {
        if (gameManager.gameStarted)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        
    }
}
