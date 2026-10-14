using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public bool gameStarted = false;
    public int score;
    public TextMeshProUGUI scoreText;

    private GameOver gameOver;
    public CanvasGroup ScoreInsert;
    public CanvasGroup Leaderboard;

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
            ScoreInsert.gameObject.SetActive(true);
        }
        else
        {
            ScoreInsert.gameObject.SetActive(false);
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

    public void ActiveLeaderbord()
    {
       Leaderboard.gameObject.SetActive(true);
    }
     public void CloseLeaderboard()
    {
        Leaderboard.gameObject.SetActive(false);
    }

}
