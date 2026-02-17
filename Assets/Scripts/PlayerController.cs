using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float moveHR;
    private Rigidbody PlRb;
    public float jumpForce = 10.0f;
    public float gravityModifier;//gravity modifier moltiplied every restart
    public bool isOnGround = true;
    private GameOver gameOverScript;
    private GameManager gameManager;
    public AudioClip jumpSound;
    private AudioSource playerAudio;
    private float gravity = -9.81f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlRb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, gravity * gravityModifier, 0); //modify gravity to debug jump, using the true value of gravity
        gameManager = FindFirstObjectByType<GameManager>();
        gameOverScript = FindFirstObjectByType<GameOver>();
        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.gameStarted) return;


        if (gameOverScript.gameOver == false)
        {

            moveHR = Input.GetAxis("Horizontal");

            //move player left and flip the sprite
            if (moveHR < 0f)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else if (moveHR > 0f)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }


            transform.Translate(Vector2.right * moveHR * Time.deltaTime * speed, Space.World);




            if (Input.GetKey(KeyCode.Space) && isOnGround)
            {
                PlRb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                playerAudio.PlayOneShot(jumpSound, 1.0f);
            }




        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        if (collision.gameObject.CompareTag("Platform"))
        {
            isOnGround = true;
        }
    }

}




