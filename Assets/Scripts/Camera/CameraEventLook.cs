using UnityEngine;
using System.Collections;
using System;
public class CameraEventLook : MonoBehaviour
{
    public Transform cameraTransform;   
    public Transform playerBody;        
    public Transform eventTarget;       
    public float rotateSpeed = 5f;

    private CameraContorl fpsCamera;
    private bool eventStarted = false;

    void Start()
    {
        fpsCamera = cameraTransform.GetComponent<CameraContorl>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && !eventStarted)
        {
            eventStarted = true;
            StartCoroutine(EventRoutine());
        }
    }

    private IEnumerator EventRoutine()
    {
        fpsCamera.isEventActive = true;

        while (true)
        {
            Vector3 targetDir = eventTarget.position - cameraTransform.position;
            Quaternion targetRotation = Quaternion.LookRotation(targetDir);

          
            cameraTransform.rotation = Quaternion.Slerp(
                cameraTransform.rotation,
                targetRotation,
                rotateSpeed * Time.deltaTime
            );

            Vector3 targetDirXZ = targetDir;
            targetDirXZ.y = 0f; // 수평 방향만
            if (targetDirXZ != Vector3.zero)
                playerBody.rotation = Quaternion.Slerp(
                    playerBody.rotation,
                    Quaternion.LookRotation(targetDirXZ),
                    rotateSpeed * Time.deltaTime
                );

           
            if (Quaternion.Angle(cameraTransform.rotation, targetRotation) < 0.1f)
            {
                cameraTransform.rotation = targetRotation;

                fpsCamera.SetPitch(cameraTransform.localEulerAngles.x);

                fpsCamera.isEventActive = false;
                fpsCamera.ResetMouse(); 
                break;
            }

            yield return null;
        }

        eventStarted = false;
    }

}
