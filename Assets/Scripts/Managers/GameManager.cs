using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Scene & Audio")]
    public SceneLoader sceneLoader;
    public AudioManager audioManager;

    [Header("Game Config")]
    public float gameDuration = 30f;

    [Header("Game State")]
    public int score = 0;
    public float timeLeft;
    public bool isGameOver = false;

    private CoinTapUIManager coinUI;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            sceneLoader = GetComponentInChildren<SceneLoader>();
            audioManager = GetComponentInChildren<AudioManager>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // Handle countdown timer during CoinTapGame
        if (!isGameOver)
        {
            timeLeft -= Time.deltaTime;
            coinUI?.UpdateTimer(Mathf.CeilToInt(timeLeft));

            if (timeLeft <= 0)
            {
                EndCoinGame();
            }
        }
    }

    public void StartCoinGame()
    {
        score = 0;
        timeLeft = gameDuration;
        isGameOver = false;

        // Wait a frame and get the UI reference
        StartCoroutine(InitCoinUI());
    }

    private IEnumerator InitCoinUI()
    {
        yield return new WaitForSeconds(0.1f); // Allow UI scene to load
        coinUI = FindObjectOfType<CoinTapUIManager>();
        coinUI?.UpdateScore(score);
        coinUI?.HideEndPanel();
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return;
        score += amount;
        coinUI?.UpdateScore(score);
    }

    private void EndCoinGame()
    {
        isGameOver = true;
        coinUI?.ShowEndPanel(score);
    }

    public void RestartGame()
    {
        sceneLoader.LoadSceneWithLoading("CoinGame");
    }

    public void BackToMenu()
    {
        sceneLoader.LoadSceneWithLoading("MainMenuScene");
        isGameOver = false;
    }
}
