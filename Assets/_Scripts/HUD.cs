using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HUD : MonoBehaviour
{
    public TMP_Text speed;
    CameraMovement cameraMovement;
    public TMP_Text distance;

    private void FixedUpdate()
    {
        speed.text=cameraMovement.speed.ToString();
        distance.text = cameraMovement.distance.ToString();
    }
}
