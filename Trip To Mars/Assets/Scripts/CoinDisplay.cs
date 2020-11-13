using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{
    public Text coinText;
    public CoinManager coinManager;

    void Start()
    {
        coinText = GetComponent<Text>();
        coinManager = FindObjectOfType<CoinManager>();
    }

    void Update()
    {
        coinText.text = coinManager.GetCoins().ToString();
    }
}
