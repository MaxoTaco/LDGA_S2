using UnityEngine;

public class TriggerZone : MonoBehaviour
{


    [SerializeField] private Transform targetZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Target Detected");
            EventManager1.TriggerCameraEventAtTarget(targetZone);
            Destroy(gameObject);
        }
    }
}
