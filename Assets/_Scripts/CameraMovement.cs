using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public int speed = 1;
    public float distance;

    float currentDistance = 0;
    Vector3 startPosition = Vector3.zero;

    private void Awake()
    {
        this.transform.position = startPosition;
        if (WebsocketManager.Instance != null)
        {
            WebsocketManager.Instance.onMessageReceived += ChangeSpeed;
        }
        else
        {
            Debug.LogWarning("WebsocketManager.Instance non è disponibile.");
        }
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
        //distance=Vector3.Distance(new Vector3(this.transform.position.x, this.transform.position.y, distance), startPosition);
        transform.position += Vector3.forward * speed * Time.deltaTime;
        distance += 1 * speed * Time.deltaTime;
    }

    public void ChangeDistance(int changeDistance)
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, changeDistance);
        distance = changeDistance;
    }
}
