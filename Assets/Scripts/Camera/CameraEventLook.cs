using UnityEngine;
using System.Collections;
public class CameraEventLook : MonoBehaviour
{
    public Transform cameraTransform; 
    public Transform eventTarget;      
    public float moveSpeed = 5f;
    public float rotateSpeed = 5f;

    private CameraContorl fpsCamera;

    void Start()
    {
        fpsCamera = cameraTransform.GetComponent<CameraContorl>();
     
    }

    public void StartEvent()
    {
        if (fpsCamera.isEventActive)
            StartCoroutine(MoveCameraToTarget());
    }

    private IEnumerator MoveCameraToTarget()
    {
        fpsCamera.isEventActive = true;

        while (true)
        {
           
            Vector3 direction = eventTarget.position - cameraTransform.position;
            float distance = direction.magnitude;

            if (distance < 0.01f && Quaternion.Angle(cameraTransform.rotation, eventTarget.rotation) < 0.1f)
            {
                cameraTransform.position = eventTarget.position;
                cameraTransform.rotation = eventTarget.rotation;

               
                fpsCamera.SetPitch(cameraTransform.localEulerAngles.x);

                fpsCamera.ResetMouse();
                fpsCamera.isEventActive = false;
                break;
            }

           
            cameraTransform.position += direction.normalized * moveSpeed * Time.deltaTime;

            cameraTransform.rotation = Quaternion.Slerp(cameraTransform.rotation, eventTarget.rotation, rotateSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
