using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowCubeChild : Block
{
    private int score = 10;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
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
