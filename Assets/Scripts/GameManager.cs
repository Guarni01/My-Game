using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreText;
  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddRockPoints (int scoreToAdd)
    {
        score += scoreToAdd;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {

        scoreText.text = "Score: " + score;

    }
}
