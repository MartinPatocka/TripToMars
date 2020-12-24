using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [Header("Prices of Ships")]
    [SerializeField] int priceOfFirstShip = 300;
    [SerializeField] int priceOfSecondShip = 500;
    [SerializeField] int priceOfThirdShip = 1000;

    [SerializeField] bool isInteractable = false;

    public int coins;
    public Rocket rocket;

    public Button buyButton1;
    public Button buyButton2;
    public Button buyButton3;

    private void Start()
    {
        coins = FindObjectOfType<CoinManager>().GetCoins();

        SetUpButton();
    }

    private void FixedUpdate()
    {
        SetUpButton();
    }

    private void SetUpButton()
    {
        if (coins <= priceOfFirstShip)
        {
            buyButton1.interactable = isInteractable;
        }

        if (coins <= priceOfSecondShip)
        {
            buyButton2.interactable = isInteractable;
        }

        if (coins <= priceOfThirdShip)
        {
            buyButton3.interactable = isInteractable;
        }
    }

    public void BuyTheFirstRocket()
    {
        if (coins >= priceOfFirstShip)
        {
            rocket.ChangeOnTheFirstSkin();
            coins -= priceOfFirstShip;
            PlayerPrefs.SetInt("TotalCoins", coins);
            Debug.Log("You Bought Rocket n.: " + 1);
        } else
        {
            Debug.Log("You dont have enough coins");
        }
    }

    public void BuyTheSecondRocket()
    {
        if (coins >= priceOfSecondShip)
        {
            rocket.ChangeOnTheSecondSkin();
            coins -= priceOfSecondShip;
            PlayerPrefs.SetInt("TotalCoins", coins);
            Debug.Log("You Bought Rocket n.: " + 2);
        }
        else
        {
            Debug.Log("You dont have enough coins");
        }
    }

    public void BuyTheThirdRocket()
    {
        if (coins >= priceOfThirdShip)
        {
            rocket.ChangeOnTheThirdSkin();
            coins -= priceOfThirdShip;
            PlayerPrefs.SetInt("TotalCoins", coins);
            Debug.Log("You Bought Rocket n.: " + 3);
        }
        else
        {
            Debug.Log("You dont have enough coins");
        }
    }
}
