// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;

// public class HomeScreenUiManager : MonoBehaviour
// {
//     [SerializeField]public GameObject homeScreen;
//     [SerializeField] public Button howToPlayBackButton;
//     [SerializeField] public Button creditsBackButton;
//     [SerializeField] public Button startButton;

//     public void Start()
//     {
//         howToPlayBackButton.onClick.AddListener(OnHowToPlayBackButtonClicked);
//         creditsBackButton.onClick.AddListener(OnCreditsBackButtonClicked);
//         startButton.onClick.AddListener(OnStartButtonClicked);
//     }

//     private void OnStartButtonClicked()
//     {
//         SceneManager.LoadScene("Wave1");
//     }

//     private void OnCreditsBackButtonClicked()
//     {
//         SceneManager.LoadScene("StartScreen");
//     }

//     private void OnHowToPlayBackButtonClicked()
//     {
//         SceneManager.LoadScene("StartScreen");
//     }
// }
