using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [Header("Coins")]
    [SerializeField] public int totalCoins = 0;
    [SerializeField] int coinValue = 1;

    private static CoinManager instance = null;

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;//Avoid doing anything else
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public int GetCoins()
    {
        return totalCoins;
    }

    public void AddCoin()
    {
        totalCoins += coinValue;
        
    }

}
