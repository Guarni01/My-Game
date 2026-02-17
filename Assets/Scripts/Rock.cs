using Unity.VisualScripting;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private GameOver gameOverScript;
    private GameManager gameManager;
    public int scoreValue;
    public AudioClip rockHitSound;
    private AudioSource rockAudio;
    private bool HitGround = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        gameOverScript = FindFirstObjectByType<GameOver>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rockAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 3f);


        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform")) //added bool 
        {
            HitGround = true;
        }

        if (!HitGround && collision.gameObject.CompareTag("Player")) // if bool is false and player is hit, game over
        {
            gameOverScript.gameOver = true;
            Debug.Log("Game Over");
            rockAudio.PlayOneShot(rockHitSound, 1.0f);
        }



    }
    private void OnDestroy()
    {

        gameManager.AddRockPoints(scoreValue);

    }



}
