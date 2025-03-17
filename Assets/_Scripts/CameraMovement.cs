using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public int speed = 1;
    public float distance;
    Vector3 startPosition = Vector3.zero;


    private void Awake()
    {
        this.transform.position = startPosition;
    }

        WebsocketManager.Instance.onMessageReceived += ChangeSpeed;
    }

    private void OnDestroy()
    {
        WebsocketManager.Instance.onMessageReceived -= ChangeSpeed;

    }

    private void ChangeSpeed(string newSpeed)
    {
        Debug.Log($"New Speed: {newSpeed}");
        speed = int.Parse(newSpeed);
    }

    private void FixedUpdate()
    {
        distance = this.transform.position.z;
        //distance=Vector3.Distance(new Vector3(this.transform.position.x, this.transform.position.y, distance), startPosition);
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }
    public void changeDistance(int changeDistance)
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, changeDistance);
    }
}
