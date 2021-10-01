using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCube : Block
{
    private int score = 3;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        Move();
    }

    public override void OnMouseDown()
    {
        base.OnMouseDown();
        if (gameManager.isGameActive)
        {
            gameManager.AddToScore(score);
        }
    }
}
