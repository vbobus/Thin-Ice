using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Follow Parameter")]

    [Tooltip("GameObject you want the camera to Follow")]

    public Transform target = null;

    [SerializeField, Range(0.1f, 1f), Tooltip("Camera Fast")]
    private float smoothSpeed = 0.125f;

    [SerializeField, Tooltip("Camera offset from Target")]
    private Vector3 offset = new Vector3(0f, 2.25f, -1.5f);

    private Vector3 velocity = Vector3.zero;

    private void LastUpdate()
    {
        Vector3 desiredPosition = target.position + offset;

        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
    }

    public void CenterOnTarget()
    {
        transform.position = target.position + offset;
    }
}


