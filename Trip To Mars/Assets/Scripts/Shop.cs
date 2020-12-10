using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public int coins;
    public Rocket rocket;

    private void Start()
    {
        coins = FindObjectOfType<CoinManager>().totalCoins;
    }

    public void BuyTheFirstRocket()
    {   
        rocket.ChangeOnTheFirstSkin();
        Debug.Log("You Bought Rocket n.: " + 1);
    }

    public void BuyTheSecondRocket()
    {
        rocket.ChangeOnTheSecondSkin();
        Debug.Log("You Bought Rocket n.: " + 2);
    }

    public void BuyTheThirdRocket()
    {
        rocket.ChangeOnTheThirdSkin();
        Debug.Log("You Bought Rocket n.: " + 3);
    }
}
