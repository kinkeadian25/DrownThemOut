using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private TextMeshProUGUI _livesText;
    [SerializeField] private TextMeshProUGUI _waveText;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _restartWinButton;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _howToPlayButton;
    [SerializeField] private Button _creditsButton;

    private LevelManager _levelManager;


    private void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
        _gameOverScreen.SetActive(false);
        _winScreen.SetActive(false);
    }

    private void Update()
    {
        _livesText.text = _levelManager.TotalLives.ToString();
        _waveText.text = _levelManager.WaveTotal.ToString();
    }

    public void GameOver()
    {
        _gameOverScreen.SetActive(true);
        _restartButton.onClick.AddListener(RestartGame);
        
    }

    private void RestartGame()
    {
        _gameOverScreen.SetActive(false);
        LevelManager.Instance.enabled = true;
        LevelManager.Instance.TotalLives = 20;
        LevelManager.Instance.WaveTotal = 1;
        LevelManager.Instance.BackgroundMusic.Play();
        SceneManager.LoadScene("Wave1");
    }

    
    public void WinGame()
    {
        _winScreen.SetActive(true);
        _restartWinButton.onClick.AddListener(RestartGameWin);
    }

    private void StartGame()
    {
        _startButton.onClick.AddListener(StartButtonClicked);
    }

    public void StartButtonClicked()
    {
        SceneManager.LoadScene("Wave1");
    }

    private void RestartGameWin()
    {
        _winScreen.SetActive(false);
        LevelManager.Instance.TotalLives = 20;
        LevelManager.Instance.WaveTotal = 1;
        LevelManager.Instance.BackgroundMusic.Play();
        LevelManager.Instance.enabled = true;
        SceneManager.LoadScene("Wave1");
    }

    public void StartScreen()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void HowToPlayScreen()
    {
        SceneManager.LoadScene("HowToPlayScreen");
        if(SceneManager.GetActiveScene().name == "HowToPlayScreen")
        {
            _howToPlayButton.onClick.AddListener(HowToPlayScreen);
        }
    }

    public void CreditScreen()
    {
        SceneManager.LoadScene("CreditScreen");
    }
}

