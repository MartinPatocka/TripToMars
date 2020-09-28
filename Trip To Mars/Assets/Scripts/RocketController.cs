using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class RocketController : MonoBehaviour
{
    [Header("Power")]
    [SerializeField] float rcsThrust = 1000f;
    [SerializeField] float forceThrust = 10000f;

    Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

    }

    public void ThrustToLeft()
    {

        float rotationThisFrame = rcsThrust * Time.deltaTime * 8;

        transform.Rotate(Vector3.forward * rotationThisFrame);
        Thrust();
    }

    public void ThrustToRight()
    {

        float rotationThisFrame = rcsThrust * Time.deltaTime * 8;

        transform.Rotate(-Vector3.forward * rotationThisFrame);
        Thrust();
    }

    public void Thrust()
    {
        rigidbody.AddRelativeForce(Vector3.up* forceThrust);
    }
}
