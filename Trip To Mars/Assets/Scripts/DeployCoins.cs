using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployCoins : MonoBehaviour
{
    [Header("Coin")]
    [SerializeField] GameObject coinPrefab;
    [SerializeField] float respawnTimeCoin = 15f;

    private Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(CoinWave());
    }

    private void SpawnCoin()
    {
        GameObject a = Instantiate(coinPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenBounds.x * 0.7f, screenBounds.x * 0.7f), screenBounds.y * 2);
    }

    IEnumerator CoinWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTimeCoin);
            SpawnCoin();
        }
    }
}
