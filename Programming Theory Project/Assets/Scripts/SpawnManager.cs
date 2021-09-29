using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] blocks;
    [SerializeField] private GameObject[] yellowCubeChild;
    [SerializeField] private float timeBetweenSpawn = 1.5f;
    private Block block;
    
    private int index;
    private float maxXPos = 8;
    private float spawnPosX;

    private bool isGameActive = true;

    private void Start()
    {
        block = FindObjectOfType<Block>();
        StartCoroutine(BlockSpawn());
    }

    IEnumerator BlockSpawn()
    {
        while(isGameActive)
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
