using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCollider : MonoBehaviour
{
    [SerializeField] float forwardMovementSpeed = 10f;
    private Rigidbody2D gameOverController;

    void Start()
    {
        gameOverController = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 newVelocity = gameOverController.velocity;
        newVelocity.y = forwardMovementSpeed;
        gameOverController.velocity = newVelocity;
    }

}
