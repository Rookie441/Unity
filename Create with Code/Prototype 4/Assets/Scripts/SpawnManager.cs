using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] powerupPrefabs;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        int index = Random.Range(0, powerupPrefabs.Length);
        Instantiate(powerupPrefabs[index], GenerateSpawnPosition(), powerupPrefabs[index].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            int index = Random.Range(0, powerupPrefabs.Length);
            Instantiate(powerupPrefabs[index], GenerateSpawnPosition(), powerupPrefabs[index].transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i=0; i< enemiesToSpawn; i++)
        {
            int index = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[index], GenerateSpawnPosition(), enemyPrefabs[index].transform.rotation);
        }
        
    }
}
