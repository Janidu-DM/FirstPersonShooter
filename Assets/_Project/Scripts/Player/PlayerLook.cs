using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [Header("Sensitivity Settings")]
    [SerializeField] private float _mouseSensitivity = 15f;
    [SerializeField] private float _maxPitch = 85f;
    [SerializeField] private float _minPitch = -85f;

    [Header("Reference")]
    [SerializeField] private Transform _cameraHolder;

    private float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    public void Look(Vector2 lookInput)
    {
        float mouseX = lookInput.x * _mouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * _mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, _minPitch, _maxPitch);
        _cameraHolder.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);
    }
}
