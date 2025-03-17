using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingOrigin : Singleton<FloatingOrigin> 
{
    [SerializeField]
    SphereCollider col;

    [SerializeField]
    CameraMovement camMovement;

    float _threshold;

    public Action<Vector3> OriginShiftEvent;

    // Start is called before the first frame update
    void Start()
    {
        _threshold = col.radius;
    }

    private void FixedUpdate()
    {
        var refPosition = camMovement.transform.position;
        if (refPosition.magnitude >= _threshold)
        {
            OriginShiftEvent.Invoke(-refPosition);
        }
    }
}
