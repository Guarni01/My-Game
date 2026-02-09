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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPlatform();
        StartCoroutine(DestroyPlatformRoutine());
    }

    // Update is called once per frame
    void Update()
    {

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
        float randomY = Random.Range(minYPosition, maxYPosition);
        float randomX = Random.Range(-SpawnXPosition, SpawnXPosition);
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
                int randomIndex = Random.Range(0, platforms.Length);
                Destroy(platforms[randomIndex]);

                SpawnSinglePlatform();
            }
        }
    }
}