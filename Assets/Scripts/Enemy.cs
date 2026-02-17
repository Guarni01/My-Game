using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float moveHR;
    private Rigidbody PlRb;
    public float jumpForce = 10.0f;
    private float jumpMaxWait = 2.0f;
    private float jumpMinWait = 0.5f;
    private GameOver gameOverScript;
    private GameManager gameManager;
    private bool isJumping = false;
    public int ScoreValue = 15;
    public AudioClip hitSound;
    private AudioSource enemyAudio;

    void Start()
    {
        PlRb = GetComponent<Rigidbody>();
        gameOverScript = FindFirstObjectByType<GameOver>();
        gameManager = FindFirstObjectByType<GameManager>();
        StartCoroutine(Move()); // Start the movement coroutine
        enemyAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!gameManager.gameStarted) return; // Don't execute movement if the game hasn't started

        if (!gameOverScript.gameOver)
        {
            transform.Translate(Vector2.right * moveHR * Time.deltaTime * speed, Space.World); // Move the enemy horizontally

            if (moveHR < 0f)
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            else if (moveHR > 0f)
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
       
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!gameManager.gameStarted) return; // Don't execute collision logic if the game hasn't started

        if (!gameOverScript.gameOver)
        {
            if (collision.gameObject.CompareTag("Ground") ||
                collision.gameObject.CompareTag("Platform")) //added bool
            {
                if (!isJumping)
                    StartCoroutine(Jump()); // Start the jump coroutine if not already jumping
            }

            if (collision.gameObject.CompareTag("Player"))
            {
                PointLoss(); // Call the method to deduct points from the player
                enemyAudio.PlayOneShot(hitSound, 1.0f);
            }
        }
    }

    IEnumerator Jump() // Coroutine to jump with a random delay between jumps
    {
        isJumping = true;

        float waitTime = Random.Range(jumpMinWait, jumpMaxWait);
        yield return new WaitForSeconds(waitTime);

        PlRb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);

        isJumping = false;
    }

    IEnumerator Move() // Coroutine to change horizontal movement direction at random intervals
    {
        while (true)
        {
            moveHR = Random.Range(-1f, 1f);
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }
    public void PointLoss() // Method to deduct points from the player when the enemy collides with the player
    {
        gameManager.LosePoints(ScoreValue);
    }
}

