using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HUD : MonoBehaviour
{
    [SerializeField] private TMP_Text speedText;
    [SerializeField] private CameraMovement cameraMovement;
    [SerializeField] private TMP_Text distanceText;
    [SerializeField] private TMP_InputField changeSpeed;
    private void FixedUpdate()
    {
        speedText.text = cameraMovement.speed.ToString();
        distanceText.text = cameraMovement.distance.ToString();
    }
    public void CallChangeDistance()
    {
        cameraMovement.ChangeDistance(int.Parse(changeSpeed.text));
    }

    public void ChangeSpeedInput()
    {
        var currentSpeed = cameraMovement.speed;
        WebsocketManager.Instance.SendRequest(currentSpeed.ToString());
    }
}
