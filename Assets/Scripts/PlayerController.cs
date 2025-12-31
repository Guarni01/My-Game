using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float moveLeft;
    private float goStraight;
    public float turnSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveLeft = Input.GetAxis("Horizontal");
        goStraight = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * moveLeft);
        transform.Translate(Vector3.forward * speed * Time.deltaTime * goStraight);
    }
}
