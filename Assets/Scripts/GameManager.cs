using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public bool gameStarted = false;
    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Image gameOverOverlay;
    public TMP_InputField playerNameInputField;
    private GameOver gameOver;
    public Button restartButton;
    public Button sendScoreButton;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScoreText();
        gameOver = FindFirstObjectByType<GameOver>();
        scoreText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver.gameOver)
        {
            sendScoreButton.gameObject.SetActive(true);
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            gameOverOverlay.gameObject.SetActive(true);
            playerNameInputField.gameObject.SetActive(true);
        }
        else
        {
            sendScoreButton.gameObject.SetActive(false);
            gameOverText.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(false);
            gameOverOverlay.gameObject.SetActive(false);
            playerNameInputField.gameObject.SetActive(false);
        }


    }
    public void StartGame()
    {
        gameStarted = true;
    }
    public void AddRockPoints(int scoreToAdd)
    {
        if (gameOver.gameOver) return;

        score += scoreToAdd;
        UpdateScoreText();
    }
    public void LosePoints(int scoreToLose)
    {

        score -= scoreToLose;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {

        scoreText.text = "Score: " + score;

    }
    public void RestartGame()

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
