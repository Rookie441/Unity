using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private PlayerController playerControllerScript;
    private float startDelay = 2;
    private float repeatRate = 2;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            int index = Random.Range(0, obstaclePrefab.Length);
            Instantiate(obstaclePrefab[index], spawnPos, obstaclePrefab[index].transform.rotation);
        }
    }
}
