using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform _playerPrefab;
    [SerializeField] private Transform _enemyPrefab;
    [SerializeField] private Transform _enemySpawnLocations;
    [SerializeField] private Transform _enemyDeadLocation;
    [SerializeField] private TMP_Text currentScoreText;
    [NonSerialized] private float currentScore = 0;
    [SerializeField] private Transform game;
    [SerializeField] private Transform enemies;
    [SerializeField] private bool isFinish;
    

    void Start()
    {
        EventManager.Instance.AddListener(EventName.GameStarted, SpawnCharacters);
        EventManager.Instance.AddListener(EventName.GameStarted, () => currentScoreText.gameObject.SetActive(true));

        EventManager.Instance.AddListener(EventName.SpawnEnemies, () =>  StartCoroutine(InstantiateEnemies()));
        
        EventManager.Instance.AddListener(EventName.LevelFailed, () => game.gameObject.SetActive(false));
        EventManager.Instance.AddListener(EventName.LevelFailed, () => currentScoreText.gameObject.SetActive(false));
        EventManager.Instance.AddListener(EventName.LevelFailed, ResetLevel);
        
        EventManager.Instance.TriggerEvent(EventName.GameStarted);
    }
    
    void Update()
    {
        UpdatePlayerScore();
    }
    
    private void SpawnCharacters()
    {
        InstantiatePlayer();
        StartCoroutine(InstantiateEnemies());
    }

    private IEnumerator InstantiateEnemies()
    {

        if (!isFinish)
        {
            var spawnLocation = _enemySpawnLocations.transform.GetChild(0);
            var spawnLocation1 = _enemySpawnLocations.transform.GetChild(1);
            var spawnLocation2 = _enemySpawnLocations.transform.GetChild(2);
            
            var enemy = Instantiate(_enemyPrefab, spawnLocation.position, Quaternion.identity);
            enemy.SetParent(enemies);
            yield return new WaitForSeconds(5f);
            StartCoroutine(InstantiateEnemies());
            
            var enemy1 = Instantiate(_enemyPrefab, spawnLocation1.position, Quaternion.identity);
            enemy1.SetParent(enemies);
            yield return new WaitForSeconds(3f);
            StartCoroutine(InstantiateEnemies());
            
            var enemy2 = Instantiate(_enemyPrefab, spawnLocation2.position, Quaternion.identity);
            enemy2.SetParent(enemies);
            yield return new WaitForSeconds(8f);
            StartCoroutine(InstantiateEnemies());
        }
        
    }
    
    private void InstantiatePlayer()
    {
        var player = Instantiate(_playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        player.SetParent(game);
    }

    private void UpdatePlayerScore()
    {
        currentScore += Time.deltaTime * 1;
        currentScoreText.text = ((int)currentScore).ToString();
    }

    private void ResetLevel()
    {
        currentScoreText.text = "0";
        isFinish = true;
    }

    
}
