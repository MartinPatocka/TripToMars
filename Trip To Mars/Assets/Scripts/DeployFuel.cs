using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployFuel : MonoBehaviour
{
    [Header("Fuel")]
    [SerializeField] GameObject fuelPrefab;
    [SerializeField] float respawnTimeFuel = 15f;

    private Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(FuelWave());
    }

    private void SpawnFuel()
    {
        GameObject a = Instantiate(fuelPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenBounds.x * 0.7f, screenBounds.x * 0.7f), screenBounds.y * 2);
    }

    IEnumerator FuelWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTimeFuel);
            SpawnFuel();
        }
    }
}
