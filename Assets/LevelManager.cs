using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    cameraScript cs;
    private float maxHorizontal, maxVertical;
    private float spawnTimer, spawnInterval;

    public GameObject asteroidPrefab;
    // Start is called before the first frame update
    void Start()
    {
        cs = Camera.main.GetComponent<cameraScript>();
        spawnInterval = 3;
        spawnTimer = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        maxHorizontal = (cs.worldWidth / 2) * 1.2f;
        maxVertical = (cs.worldHeight / 2) * 1.2f;
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0)
        {
            Spawn();
            spawnTimer = spawnInterval;
        }
    }

    void Spawn()
    {
        float randomX, randomZ;
        if (Mathf.Round(Random.Range(0, 1)) == 0)
        {
            randomZ = randomSigm() * maxVertical;
            randomX = Random.Range(0, maxHorizontal);
        }
        else
        {
            randomX = randomSigm() * maxHorizontal;
            randomZ = Random.Range(0, maxVertical);
        }
        Vector3 spawnPoint = new Vector3(randomX, 0, randomZ);
        Instantiate(asteroidPrefab, spawnPoint, Quaternion.identity);
    }
    int randomSigm()
    {
        int[] numbers = { -1, 1 };
        int randomIndex = Random.Range(0, numbers.Length);
        return numbers[randomIndex];
    }
}
