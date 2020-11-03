using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject targetObject;
    private float distanceToTarget;

    //Background
    public Transform background1;
    public Transform background2;
    private float size;

    void Start()
    {
        distanceToTarget = transform.position.y - targetObject.transform.position.y;
        size = background1.GetComponent<BoxCollider2D>().size.y;
    }

    private void FixedUpdate()
    {
        float targetObjectY = targetObject.transform.position.y;
        Vector3 newCameraPosition = transform.position;
        newCameraPosition.y = targetObjectY + distanceToTarget;
        transform.position = newCameraPosition;

        AddBackground();
    }

    private void AddBackground()
    {
        if (transform.position.y >= background2.position.y)
        {
            background1.position = new Vector3(background1.position.x, background2.position.y + size, background1.position.z);
            SwitchBackground();
        }
    }

    private void SwitchBackground()
    {
        Transform temp = background1;
        background1 = background2;
        background2 = temp;
    }
}
