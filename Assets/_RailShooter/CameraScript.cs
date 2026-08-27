using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform playerTarget;

    public float smoothSpeed = 0.1f;
    public Vector3 offset;

    Vector3 camVelocity = Vector3.zero;

    public float minPosX, maxPosX, minPosY, maxPosY;

    private void Update()
    {
        ClampToScreen();
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, playerTarget.position + offset, smoothSpeed);
    }

    void ClampToScreen()
    {
        Vector3 _pos = transform.localPosition;
        _pos.x = Mathf.Clamp(_pos.x, minPosX, maxPosX);
        _pos.y = Mathf.Clamp(_pos.y, minPosY, maxPosY);
        transform.localPosition = _pos;
    }
}
