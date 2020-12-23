using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] int totalScore = 0;
    [SerializeField] int scoreValue = 1;
    public int theBestScore = 0;

    private void Start()
    {
        InvokeRepeating("AddScore", 1f, 2f);
    }

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return totalScore;
    }

    public void AddScore()
    {
        totalScore += scoreValue;
        PlayerPrefs.SetInt("TotalScore", totalScore);
        if (totalScore > PlayerPrefs.GetInt("TheBestScore"))
        {
            PlayerPrefs.SetInt("TheBestScore", totalScore);
        }
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

}