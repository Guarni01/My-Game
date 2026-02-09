using UnityEngine;

public class Rock : MonoBehaviour
{
    private GameOver gameOverScript;
    private GameObject spawn;
    private GameManager gameManager;
    public int scoreValue ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        spawn = GameObject.Find("Spawn rock");
        gameOverScript = spawn.GetComponent<GameOver>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

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
    private void OnDestroy()
    {
        
        gameManager.AddRockPoints(scoreValue);

    }



}
