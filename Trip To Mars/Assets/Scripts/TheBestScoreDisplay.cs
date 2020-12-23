
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheBestScoreDisplay : MonoBehaviour
{
    public Text scoreText;
    public TheBestScore theBestScore;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        theBestScore = FindObjectOfType<TheBestScore>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = theBestScore.GetTheBestScore().ToString();
    }
}