using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    [SerializeField] public Button startButton;
    [SerializeField] public Button howToPlayButton;
    [SerializeField] public Button creditsButton;

    public void Start()
    {
        startButton.onClick.AddListener(OnStartButtonClicked);
        howToPlayButton.onClick.AddListener(OnHowToPlayButtonClicked);
        creditsButton.onClick.AddListener(OnCreditsButtonClicked);
    }

    private void OnCreditsButtonClicked()
    {
        SceneManager.LoadScene("Credits");
    }

    private void OnHowToPlayButtonClicked()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    private void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Wave1");
    }
}
