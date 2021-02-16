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
        buyButton1.onClick.AddListener(BuyButton1Click);
        buyButton2.onClick.AddListener(BuyButton2Click);
        buyButton3.onClick.AddListener(BuyButton3Click);


        SetUpButton();
    }

    public void BuyButton1Click()
    {
        BuyRocket(ESkinId.First);
    }

    public void BuyButton2Click()
    {
        BuyRocket(ESkinId.Second);
    }

    public void BuyButton3Click()
    {
        BuyRocket(ESkinId.Third);
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
    
    public void BuyRocket(ESkinId skinId)
    {
        if (coins >= GameSession.Instance.rocketScriptableObject.GetSkin(skinId).rocketPrice)
        {
            coins -= GameSession.Instance.rocketScriptableObject.GetSkin(skinId).rocketPrice;
            PlayerPrefs.SetInt("ActualShip",(int)skinId);
            PlayerPrefs.SetInt("TotalCoins", coins);
            Debug.Log("You Bought Rocket n.: " + 1);
        } else
        {
            Debug.Log("You dont have enough coins");
        }
    }
}
