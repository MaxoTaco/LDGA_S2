using System;
using UnityEngine;

public class EventManager1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static Action<Transform> cameraEvent;
    public static void TriggerCameraEventAtTarget(Transform target)
    {
        cameraEvent?.Invoke(target);
    }


}

