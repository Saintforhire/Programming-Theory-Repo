using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] blocks;
    [SerializeField] private GameObject[] yellowCubeChild;
    [SerializeField] private float timeBetweenSpawn = 1.5f;

    private GameManager gameManager;
    
    private int index;
    private float maxXPos = 8;
    private float spawnPosX;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(BlockSpawn());
    }

    IEnumerator BlockSpawn()
    {
        while(gameManager.isGameActive)
        {
            index = Random.Range(0, blocks.Length);
            spawnPosX = Random.Range(-maxXPos, maxXPos);
            Instantiate(blocks[index], new Vector3(spawnPosX, 
                        transform.position.y, transform.position.z), transform.rotation);
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }

    public void SpawnYellowBlocks(Vector3 destroyPosition, Vector3 destroyPositionOffset)
    {
        int firstBlock = 0;
        int lastBlock = yellowCubeChild.Length - 1;

        Instantiate(yellowCubeChild[firstBlock], destroyPosition - destroyPositionOffset, transform.rotation);
        Instantiate(yellowCubeChild[lastBlock], destroyPosition + destroyPositionOffset, transform.rotation);
    }
}
