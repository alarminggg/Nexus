using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // DESIGN PATTERN: SINGLETON
    public static GameManager Instance { get; private set; }
    public UIManager UIManager { get; private set; }

    private static float timeElapsed = 0f;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        UIManager = GetComponent<UIManager>();

    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

    }
    public static void IncrementTime(float value)
    {
        timeElapsed += value;
        Debug.Log("Time Taken: " + timeElapsed);
    }

    public static void ResetGame()
    {
        ResetTime();
        timeElapsed = 0f;
    }

    private static void ResetTime()
    {
        timeElapsed = 0f;
        Debug.Log("Time Taken: " + timeElapsed);
    }

    public void GameOver()
    {
        Instance.UIManager.ActivateEndGame();
        MenuController.IsGamePaused = true;

    }
}
