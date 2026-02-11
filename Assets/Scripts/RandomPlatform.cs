using System;
using System.Collections;
using UnityEngine;

public class RandomPlatform : MonoBehaviour
{
    private float SpawnXPosition = 11.50f;
    public GameObject player;
    public GameObject platformPrefab;
    private float minYPosition = 1f;
    private float maxYPosition = 3.5f;
    public float DestroyPlatformDelay = 5f;
    private GameOver gameOverScript;
    private GameManager gameManager; 
    private bool started = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        gameOverScript = FindFirstObjectByType<GameOver>();
        gameManager = FindFirstObjectByType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.gameStarted && !started)
        {
            started = true;
            SpawnPlatform();
            StartCoroutine(DestroyPlatformRoutine());
        }
        if (gameOverScript.gameOver == true)
        {
            StopAllCoroutines();
        }
    }

    void SpawnPlatform()
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnSinglePlatform();
        }

    }
    void SpawnSinglePlatform()
    {
        float randomY = UnityEngine.Random.Range(minYPosition, maxYPosition);
        float randomX = UnityEngine.Random.Range(-SpawnXPosition, SpawnXPosition);
        Vector3 spawnPosition = new Vector3(randomX, randomY, player.transform.position.z);
        Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
    }



    IEnumerator DestroyPlatformRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(DestroyPlatformDelay);
            GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");
            if (platforms.Length > 0)
            {
                int randomIndex = UnityEngine.Random.Range(0, platforms.Length);
                Destroy(platforms[randomIndex]);

                SpawnSinglePlatform();
            }
        }
    }
}