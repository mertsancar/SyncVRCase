using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] private Transform mainMenuScreen;
    [SerializeField] private Transform gameScreen;
    [SerializeField] private Transform levelFailedScreen;
    
    void Start()
    {
        EventManager.Instance.AddListener(EventName.ShowMainMenu, ShowMainMenuScreen);
        EventManager.Instance.TriggerEvent(EventName.ShowMainMenu);
        
        EventManager.Instance.AddListener(EventName.GameStarted, () => gameScreen.gameObject.SetActive(true));
        EventManager.Instance.AddListener(EventName.LevelFailed, ShowLevelFailedScreen);
    }

    private void ShowLevelFailedScreen()
    {
        levelFailedScreen.gameObject.SetActive(true);
    }
    
    private void ShowMainMenuScreen()
    {
        mainMenuScreen.gameObject.SetActive(true);
    }
    
}
