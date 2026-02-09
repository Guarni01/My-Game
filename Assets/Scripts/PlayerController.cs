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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            PlRb = GetComponent<Rigidbody>();
            Physics.gravity *= gravityModifier;

       
    }

    // Update is called once per frame
    void Update()
    {
        moveHR = Input.GetAxis("Horizontal");
        
        transform.Translate(Vector2.right * moveHR * Time.deltaTime * speed);
      

        if (Input.GetKey(KeyCode.Space) && isOnGround)
        {
            PlRb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
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


  
