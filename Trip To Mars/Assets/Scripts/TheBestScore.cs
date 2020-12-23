using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBestScore : MonoBehaviour
{
    public int theBestScore;
    private static TheBestScore instance = null;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public int GetTheBestScore()
    {
        return PlayerPrefs.GetInt("TheBestScore");
    }

}
