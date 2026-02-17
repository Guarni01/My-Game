using System.Collections;
using UnityEngine;

public class RandomRock : MonoBehaviour
{
    private float SpawnXPosition = 11.50f;
    public GameObject rockPrefab;
    public GameObject player;
    public float spawnRockInterval = 2.0f;
    private GameOver gameOverScript;
    private Coroutine Coroutine;
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
        if (gameManager.gameStarted && !started)
        {
            started = true;
            Coroutine = StartCoroutine(SpawnRockRoutine());
        }


        if (gameOverScript.gameOver == true)
        {
            StopCoroutine(Coroutine);
        }

    }

    IEnumerator SpawnRockRoutine()
    {
        while (true)
        {
            Vector3 randomPos = new Vector3(Random.Range(SpawnXPosition, -SpawnXPosition), 5, player.transform.position.z);
            Instantiate(rockPrefab, randomPos, Quaternion.identity);
            yield return new WaitForSeconds(spawnRockInterval);
        }
    }

}

