using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public int speed = 1;
    public float distance;
    Vector3 startPosition= Vector3.zero;
    private void Awake()
    {
        this.transform.position = startPosition;
    }
    private void FixedUpdate()
    {
        distance=Vector3.Distance(this.transform.position, startPosition);
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }
}
