using UnityEngine;

public class Start_Button : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject titleText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnStartPressed() 
    {
       gameManager.StartGame(); 
       gameObject.SetActive(false);
       titleText.SetActive(false);
    }
}
