using UnityEngine;
using TMPro;


public class LeaderboardEntryBH : MonoBehaviour
{
    public TMP_Text RankText;
    public TMP_Text PlayerNameText;
    public TMP_Text ScoreText;


    public void SetEntryValues(string rankValue, string playerNameValue, string scoreValue)
    {
        RankText.text = rankValue;
        PlayerNameText.text = playerNameValue;
        ScoreText.text = scoreValue;
    }
}