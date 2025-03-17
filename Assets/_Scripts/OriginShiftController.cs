using UnityEngine;

public class OriginShiftController : MonoBehaviour
{

    private void Start()
    {
        FloatingOrigin.Instance.OriginShiftEvent += ChangeOrigin;
    }

    private void OnDestroy()
    {
        FloatingOrigin.Instance.OriginShiftEvent -= ChangeOrigin;
    }

    private void ChangeOrigin(Vector3 offset)
    {
        transform.position += offset;
    }
}
