using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    private Rigidbody2D rigidbody;
    private Vector2 screenBounds;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(0, -speed);

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.height, Screen.width, Camera.main.transform.position.z));
    }

    void Update()
    {
        DestroyFuel();
    }

    private void DestroyFuel()
    {
        if (transform.position.y < screenBounds.y - 10)
        {
            Destroy(this.gameObject);
        }
    }
}
