using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float moveHR;
    private Rigidbody PlRb;
    public float jumpForce = 10.0f;
    public float gravityModifier;
    public bool isOnGround = true;
    public float horizontalInput;
    private GameOver gameOverScript;
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        gameManager = FindFirstObjectByType<GameManager>();
        gameOverScript =FindFirstObjectByType<GameOver>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.gameStarted) return;


        if (gameOverScript.gameOver == false)
        {

            moveHR = Input.GetAxis("Horizontal");

            transform.Translate(Vector2.right * moveHR * Time.deltaTime * speed);


            if (Input.GetKey(KeyCode.Space) && isOnGround)
            {
                PlRb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
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


  
