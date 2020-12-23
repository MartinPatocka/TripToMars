using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    [SerializeField] SpriteRenderer rocketImage;

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

    [Header("Sounds Efects")]
    [SerializeField] AudioClip thrustSound;
    [SerializeField] GameObject deathSound;

    [Header("ScriptableObject")]
    [SerializeField] RocketScriptableObject[] rocketsSO;
    public RocketScriptableObject rocketImageSO;

    private Rigidbody2D rigidbody;
    private AudioSource audioSource;
    private GameSession gameSession;
    private CoinManager coinManager;

    void Start()
    {
        SetScriptableObject();

        rigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        gameSession = FindObjectOfType<GameSession>();
        coinManager = FindObjectOfType<CoinManager>();

        currentFuel = maxFuel;
        fuelBar.SetMaxFuel(maxFuel);
    }

    void Update()
    {
        MouseControll();
    }

    #region ScriptableObejct
    private void SetScriptableObject()
    {
        SetValuesOfRocket();
    }

    private void SetValuesOfRocket()
    {
        rocketImage.sprite = rocketImageSO.rocketImage;
        maxFuel = rocketImageSO.maxFuel;
    }

    public void ChangeOnTheFirstSkin()
    {
        rocketImageSO = rocketsSO[1];
        SetValuesOfRocket();
    }

    public void ChangeOnTheSecondSkin()
    {
        rocketImageSO = rocketsSO[2];
        SetValuesOfRocket();
    }

    public void ChangeOnTheThirdSkin()
    {
        rocketImageSO = rocketsSO[3];
        SetValuesOfRocket();
    }
    #endregion;

    #region RocketControl
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
        audioSource.PlayOneShot(thrustSound);
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
    #endregion;

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
        GameObject explosionSound = Instantiate(deathSound);
        Destroy(explosionSound, durationOfExplosion);
        Destroy(explosion, durationOfExplosion);
    }

}
