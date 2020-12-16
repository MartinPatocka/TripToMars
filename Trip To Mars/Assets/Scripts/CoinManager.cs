using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [Header("Coins")]
    [SerializeField] public int totalCoins = 0;
    [SerializeField] int coinValue = 1;

    private static CoinManager instance = null;

    private void Start()
    {
        totalCoins = PlayerPrefs.GetInt("TotalCoins");
    }

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

    public int GetCoins()
    {
        return PlayerPrefs.GetInt("TotalCoins");
    }

    public void AddCoin()
    {
        totalCoins += coinValue;
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
    }

    public void Add100Coin()
    {
        totalCoins += 100;
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
    }

    public void Add300Coin()
    {
        totalCoins += 300;
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
    }

    public void Add500Coin()
    {
        totalCoins += 500;
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
    }


}
