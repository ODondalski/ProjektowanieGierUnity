using System.Collections;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public Transform player;
    public float sensitivity = 200f;
    public float minimumX = -90f;
    public float maximumX = 90f;
    private float rotationX = 0f;

    void Start()
    {
        LockCursor();
    }

    void Update()
    {
        HandleMouseInput();
    }

    void HandleMouseInput()
    {
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        LimitRotationY(mouseYMove);
        RotatePlayerHorizontally(mouseXMove);
        RotateCameraVertically();
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LimitRotationY(float mouseYMove)
    {
        rotationX -= mouseYMove;
        rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);
    }

    void RotatePlayerHorizontally(float mouseXMove)
    {
        player.Rotate(Vector3.up * mouseXMove);
    }

    void RotateCameraVertically()
    {
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }
}
