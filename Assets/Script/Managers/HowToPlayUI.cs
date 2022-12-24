using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HowToPlayUI : MonoBehaviour
{
    [SerializeField] public Button howToPlayBackButton;

    public void Start()
    {
        howToPlayBackButton.onClick.AddListener(OnHowToPlayBackButtonClicked);
    }

    private void OnHowToPlayBackButtonClicked()
    {
        SceneManager.LoadScene("Start");
    }
}
