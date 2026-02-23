using UnityEngine;



public class PlayerController : MonoBehaviour
{
    public float speed;
    public float moveHR;
    private Rigidbody PlRb;
    public float jumpForce = 10.0f;
    public float gravityModifier;
    public bool isOnGround = true;

    private GameOver gameOverScript;
    private GameManager gameManager;

    public AudioClip jumpSound;
    private AudioSource playerAudio;

    private float gravity = -9.81f;

    // JOYSTICK MOBILE
    public MobileJoystick joystick;   // <--- aggiunto
    private bool jumpPressed = false; // <--- aggiunto

    void Start()
    {
        PlRb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, gravity * gravityModifier, 0);

        gameManager = FindFirstObjectByType<GameManager>();
        gameOverScript = FindFirstObjectByType<GameOver>();
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!gameManager.gameStarted) return;
        if (gameOverScript.gameOver) return;

        // --- MOVIMENTO PC ---
        float pcMove = Input.GetAxis("Horizontal");

        // --- MOVIMENTO ANDROID ---
        float mobileMove = joystick != null ? joystick.Horizontal() : 0f;

        // Se sto su PC uso la tastiera, se sto su Android uso il joystick
#if UNITY_ANDROID
        moveHR = mobileMove;
#else
        moveHR = pcMove;
#endif

        // Flip sprite
        if (moveHR < 0f)
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        else if (moveHR > 0f)
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        // Movimento
        transform.Translate(Vector2.right * moveHR * Time.deltaTime * speed, Space.World);

        // --- SALTO PC ---
        if (Input.GetKey(KeyCode.Space) && isOnGround)
        {
            DoJump();
        }

        // --- SALTO ANDROID ---
        if (jumpPressed && isOnGround)
        {
            DoJump();
            jumpPressed = false;
        }
    }

    void DoJump()
    {
        PlRb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
        playerAudio.PlayOneShot(jumpSound, 1.0f);
    }

    public void JumpButton()   // <--- chiamato dal pulsante UI
    {
        jumpPressed = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") ||
            collision.gameObject.CompareTag("Platform"))
        {
            isOnGround = true;
        }
    }
}
