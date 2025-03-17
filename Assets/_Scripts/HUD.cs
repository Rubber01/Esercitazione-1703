using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HUD : MonoBehaviour
{
    public TMP_Text speed;
    public CameraMovement cameraMovement;
    public TMP_Text distance;
    public TMP_InputField changeSpeed;
    private void FixedUpdate()
    {
        speed.text=cameraMovement.speed.ToString();
        distance.text = cameraMovement.distance.ToString();
    }
    public void CallChangeDistance()
    {
        cameraMovement.changeDistance(int.Parse(changeSpeed.text));
    }
}
