using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployAsteroids : MonoBehaviour
{
    [Header("Asteroids")]
    [SerializeField] GameObject asteroidPrefab;
    [SerializeField] float respawnTime = 1.0f;

    private Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(AsteroidWave());
    }

    private void SpawnAsteroids()
    {
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenBounds.x * 0.85f, screenBounds.x * 0.85f), screenBounds.y * 2);
    }

    IEnumerator AsteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnAsteroids();
        }
    }


}
