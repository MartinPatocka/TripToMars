using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] int totalScore = 0;
    [SerializeField] int scoreValue = 1;

    private void Start()
    {
        InvokeRepeating("AddScore", 1.0f, 1.0f);
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
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}