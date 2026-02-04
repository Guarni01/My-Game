using System.Collections;
using UnityEngine;

public class RandomRock : MonoBehaviour
{
    private float SpawnXPosition = 11.50f;
    public GameObject rockPrefab;
    public GameObject player;
    public float SpawnRockInterval = 2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnRockRoutine());
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }

    IEnumerator SpawnRockRoutine()
    {
        while (true)
        {
            Vector3 randomPos = new Vector3(Random.Range(SpawnXPosition,-SpawnXPosition),5, player.transform.position.z);
            Instantiate(rockPrefab, randomPos, Quaternion.identity);
            yield return new WaitForSeconds(SpawnRockInterval);
        }
    }

  
}

