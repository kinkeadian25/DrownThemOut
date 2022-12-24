using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsUi : MonoBehaviour
{
    [SerializeField] public Button creditsBackButton;

    public void Start()
    {
        creditsBackButton.onClick.AddListener(OnCreditsBackButtonClicked);
    }


    private void OnCreditsBackButtonClicked()
    {
        SceneManager.LoadScene("Start");
    }

}
