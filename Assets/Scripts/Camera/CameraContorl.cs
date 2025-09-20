using System;
using UnityEngine;

public class CameraContorl : MonoBehaviour
{
    [Header("Mouse Settings")]
    public Transform playerBody;
    public float mouseSensitivity = 100f;

   public bool isEventActive = false;
    private float pitch = 0f;
    private bool ignoreNextMouseFrame = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        pitch = transform.localEulerAngles.x;
        if (pitch > 180f) pitch -= 360f;
    }

    void Update()
    {
        if (ignoreNextMouseFrame)
        {
            ignoreNextMouseFrame = false; 
            return;
        }

        if (isEventActive) return; 

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

       
        if (playerBody != null)
            playerBody.Rotate(Vector3.up * mouseX);

        
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -50f, 50f);
        transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);



    }

    public void ResetMouse()
    {
        ignoreNextMouseFrame = true;
    }


    public void SetPitch(float newPitch)
    {
        pitch = newPitch;

        Debug.Log($"Pitch: {pitch}");
        if (pitch > 180f) pitch -= 360f;
        transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }
}

