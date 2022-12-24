using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] public int _lives = 20;

    public int TotalLives { get; set; }
    public int WaveTotal { get; set; }
    public int CurrentWave { get; set; }
    public AudioSource BackgroundMusic;


    private void Start()
    {
        TotalLives = _lives;
        WaveTotal = 1;
        BackgroundMusic = GetComponent<AudioSource>();
        BackgroundMusic.Play();
    }
    private void Update()
    {
        CurrentWave = WaveTotal;
        
    }

    private void OnEnable()
    {
        Enemy.OnEnemyReachedEnd += DecrementLives;
        Spawner.WaveCompleted += EndWave;
    }

    private void EndWave()
    {
        WaveTotal++;
        if (WaveTotal == 11)
        {
            LevelManager.Instance.enabled = false;
            UIManager.Instance.WinGame();
        }

    }

    private void OnDisable()
    {
        Enemy.OnEnemyReachedEnd -= DecrementLives;
        Spawner.WaveCompleted -= EndWave;
    }

    private void DecrementLives()
    {
        TotalLives--;
        if (TotalLives <= 0)
        {
            LevelManager.Instance.enabled = false;
            UIManager.Instance.GameOver();
        }
    }

    private void WinGame()
    {
        UIManager.Instance.WinGame();
    }

    private void StartScreen()
    {
        UIManager.Instance.StartScreen();    
    }

    private void CreditScreen()
    {
        UIManager.Instance.CreditScreen();
    }

    private void HowToPlayScreen()
    {
        UIManager.Instance.HowToPlayScreen();
    }
}
