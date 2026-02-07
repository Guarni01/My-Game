using UnityEngine;

public class Rock : MonoBehaviour
{
    private GameOver gameOverScript;
    private GameObject spawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawn = GameObject.Find("Spawn rock");
        gameOverScript = spawn.GetComponent<GameOver>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 3f);

        if (collision.gameObject.CompareTag("Player"))
        {
            gameOverScript.gameOver = true;
            Debug.Log("Game Over");
        }
    }
}
