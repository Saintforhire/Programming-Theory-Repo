using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowCube : Block
{
    [SerializeField] private GameObject[] childBlocks;
    private SpawnManager spawnManager;
    public Vector3 destroyPosition;
    public Vector3 destroyPositionOffset;

    private int score = 3;
    private GameManager gameManager;

    private void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        Move();
    }

    public override void OnMouseDown()
    {
        destroyPosition = transform.position;
        destroyPositionOffset = destroyPosition - new Vector3(transform.position.x - 2f, transform.position.y, transform.position.z);
        base.OnMouseDown();
        if (gameManager.isGameActive)
        {
            gameManager.AddToScore(score);
        }
        spawnManager.SpawnYellowBlocks(destroyPosition, destroyPositionOffset);
    }
}
