using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinShop : MonoBehaviour
{
    public int coins;

    void Start()
    {
        coins = FindObjectOfType<CoinManager>().GetCoins();
    }

    public void Buy100Coins()
    {
        coins += 100;
        PlayerPrefs.SetInt("TotalCoins", coins);
        Debug.Log("You Bought 100 coins");
    }

    public void Buy300Coins()
    {
        coins += 300;
        PlayerPrefs.SetInt("TotalCoins", coins);
        Debug.Log("You Bought 300 coins");
    }

    public void Buy500Coins()
    {
        coins += 500;
        PlayerPrefs.SetInt("TotalCoins", coins);
        Debug.Log("You Bought 500 coins");
    }
}
