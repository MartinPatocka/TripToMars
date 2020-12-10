﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    [SerializeField] Sprite image1;
    [SerializeField] Sprite image2;

    [SerializeField] SpriteRenderer rocketImage;
    [SerializeField] PolygonCollider2D rocketCollider;

    [Header("Power")]
    [SerializeField] float turnThrust = 100f;
    [SerializeField] float forceThrust = 100f;

    [Header("FuelBar")]
    [SerializeField] float maxFuel = 100f;
    [SerializeField] float currentFuel;
    [SerializeField] float fuelForThrust = 2f;
    public FuelBar fuelBar;

    [Header("Visual Efects")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] ParticleSystem flameVFX;
    [SerializeField] float durationOfExplosion = 1f;

    private Rigidbody2D rigidbody;
    private GameSession gameSession;
    private CoinManager coinManager;

    [Header("ScriptableObject")]
    public RocketScriptableObject rocketImageSO;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        gameSession = FindObjectOfType<GameSession>();
        coinManager = FindObjectOfType<CoinManager>();

        SetScriptableObject();

        currentFuel = maxFuel;
        fuelBar.SetMaxFuel(maxFuel);
    }

    void Update()
    {
        MouseControll();
    }

    private void SetScriptableObject()
    {
        rocketImage.sprite = rocketImageSO.rocketImage;
        rocketCollider = rocketImageSO.rocketCollider;
        maxFuel = rocketImageSO.maxFuel;
    }

    private void ChangeSkin()
    {
        //scriptable object
        if (rocketImage.sprite == image1)
        {
            rocketImage.sprite = image2;
        }
        else
        {
            rocketImage.sprite = image1;
        }
        
    }

    private void MouseControll()
    {
        if (currentFuel <= 0) {
            return;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                flameVFX.Play();
                if (Input.mousePosition.x < Screen.width / 2)
                {
                    ThrustToLeft();
                }
                else if (Input.mousePosition.x > Screen.width / 2)
                {
                    ThrustToRight();
                }
            }
        }
    }

    public void ThrustToLeft()
    {
        Thrust(fuelForThrust);
        rigidbody.AddRelativeForce(Vector3.left * turnThrust);
    }

    public void ThrustToRight()
    {
        Thrust(fuelForThrust);
        rigidbody.AddRelativeForce(Vector3.right * turnThrust);
    }

    public void Thrust(float fuel)
    {
        currentFuel -= fuel;
        fuelBar.SetFuel(currentFuel);
        rigidbody.AddRelativeForce(Vector3.up* forceThrust);
    }

    public void TouchControll()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.position.x < Screen.width / 2)
            {
                ThrustToLeft();
            }
            else if (touch.position.x > Screen.width / 2)
            {
                ThrustToRight();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fuel"))
        {
            currentFuel = maxFuel;
            Destroy(collision.gameObject);
            return;
        }
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            coinManager.AddCoin();
            Destroy(collision.gameObject);
        }
    }

    public void Die()
    {
        FindObjectOfType<GameSession>().CancelInvoke();
        FindObjectOfType<SceneController>().LoadGameOver();
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
        //AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
    }

}
