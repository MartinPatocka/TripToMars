using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [Header("Prices of Ships")]
    [SerializeField] int priceOfFirstShip = 50;
    [SerializeField] int priceOfSecondShip = 100;
    [SerializeField] int priceOfThirdShip = 300;

    [SerializeField] bool isInteractable = false;

    public int coins;
    public Rocket rocket;

    [Header("Buttons")]
    public Button buyButton1;
    public Button buyButton2;
    public Button buyButton3;
    public Image imageOfButton;

    public int[] boughtRockets;

    private void Start()
    {
        coins = FindObjectOfType<CoinManager>().GetCoins();
        buyButton1.onClick.AddListener(BuyButton1Click);
        buyButton2.onClick.AddListener(BuyButton2Click);
        buyButton3.onClick.AddListener(BuyButton3Click);

        SetUpButton();
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("BoughtFirstShip") == 1)
        {
            buyButton1.GetComponent<Image>().color = UnityEngine.Color.green;
            buyButton1.GetComponentInChildren<Text>().resizeTextForBestFit = true;
            buyButton1.GetComponentInChildren<Text>().text = "Change Ship";
            buyButton1.transform.GetChild(1).transform.gameObject.SetActive(false);
            GameSession.Instance.rocketScriptableObject.GetSkin(ESkinId.First).rocketPrice = 0;
        }
        if (PlayerPrefs.GetInt("BoughtSecondShip") == 1)
        {
            buyButton2.GetComponent<Image>().color = UnityEngine.Color.green;
            buyButton2.GetComponentInChildren<Text>().resizeTextForBestFit = true;
            buyButton2.GetComponentInChildren<Text>().text = "Change Ship";
            buyButton2.transform.GetChild(1).transform.gameObject.SetActive(false);
            GameSession.Instance.rocketScriptableObject.GetSkin(ESkinId.Second).rocketPrice = 0;
        }
        if (PlayerPrefs.GetInt("BoughtThirdShip") == 1)
        {
            buyButton3.GetComponent<Image>().color = UnityEngine.Color.green;
            buyButton3.GetComponentInChildren<Text>().resizeTextForBestFit = true;
            buyButton3.GetComponentInChildren<Text>().text = "Change Ship";
            buyButton3.transform.GetChild(1).transform.gameObject.SetActive(false);
            GameSession.Instance.rocketScriptableObject.GetSkin(ESkinId.Third).rocketPrice = 0;
        }
    }

    public void BuyButton1Click()
    {
        BuyRocket(ESkinId.First);
        PlayerPrefs.SetInt("BoughtFirstShip", 1);
    }

    public void BuyButton2Click()
    {
        BuyRocket(ESkinId.Second);
        PlayerPrefs.SetInt("BoughtSecondShip", 1);
    }

    public void BuyButton3Click()
    {
        BuyRocket(ESkinId.Third);
        PlayerPrefs.SetInt("BoughtThirdShip", 1);
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
            Debug.Log("You Bought Rocket");
        } else
        {
            Debug.Log("You dont have enough coins");
        }
    }
}
