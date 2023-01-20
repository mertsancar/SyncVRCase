using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelFailedScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text newBestText;
    [SerializeField] private TMP_Text currentScore;
    [SerializeField] private Button retryButton;
    void Awake()
    {
        scoreText.text = currentScore.text;

        if (Int32.Parse(scoreText.text) <= PersistenceManager.GetHighScore())
        {
            newBestText.gameObject.SetActive(false);
        }
        else
        {
            PersistenceManager.SetHighScore(Int32.Parse(scoreText.text));
        }
        
        retryButton.onClick.AddListener(ClickRetryButton);
    }

    private void ClickRetryButton()
    {
        SceneManager.LoadScene("Game");
    }
}
