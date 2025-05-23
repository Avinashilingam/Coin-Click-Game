using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinTapUIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public GameObject endPanel;
    public TextMeshProUGUI finalScoreText;

    public void UpdateScore(int score)
    {
        scoreText.text = $"Score: {score}";
    }

    public void UpdateTimer(int secondsLeft)
    {
        timerText.text = secondsLeft.ToString();
    }

    public void ShowEndPanel(int finalScore)
    {
        endPanel.SetActive(true);
        finalScoreText.text = $"Final Score: {finalScore}";
    }

    public void HideEndPanel()
    {
        endPanel.SetActive(false);
    }

    public void OnRestartPressed()
    {
        GameManager.instance.RestartGame();
    }

    public void OnBackPressed()
    {
        GameManager.instance.BackToMenu();
    }
}
