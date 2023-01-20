using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScreen : MonoBehaviour
{
    [SerializeField] private Button playButton;
    void Start()
    {
        playButton.onClick.AddListener(ClickPlayButton);
    }

    private void ClickPlayButton()
    {
        EventManager.Instance.TriggerEvent(EventName.GameStarted);
        gameObject.SetActive(false);
    }
}
