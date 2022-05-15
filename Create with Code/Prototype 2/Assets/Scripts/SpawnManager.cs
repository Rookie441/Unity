using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnLeftAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnRightAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        int index = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[index], (transform.position + new Vector3(Random.Range(0, 40), 0, 0)), animalPrefabs[index].transform.rotation);
    }

    void SpawnLeftAnimal()
    {
        int index = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[index], (transform.position + new Vector3(0, 0, Random.Range(-15, 0))), Quaternion.Euler(new Vector3(0, 90, 0)));
    }

    void SpawnRightAnimal()
    {
        int index = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[index], (transform.position + new Vector3(40, 0, Random.Range(-15, 0))), Quaternion.Euler(new Vector3(0, -90, 0)));
    }

}
