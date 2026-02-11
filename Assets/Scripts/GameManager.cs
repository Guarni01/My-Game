using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{   
    public bool gameStarted = false;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private GameOver gameOver;
    public Button restartButton;
  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScoreText();
        gameOver = FindFirstObjectByType<GameOver>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver.gameOver)
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
        else
        {
            gameOverText.gameObject.SetActive(false);
        }


    }
    public void StartGame()
    {
        gameStarted = true;
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
    public void RestartGame()

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
