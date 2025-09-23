using System.Collections;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{


    [SerializeField] private Transform targetZone;
    [SerializeField] private AudioClip clip;
    [SerializeField] private float waitTime;
    [SerializeField] private bool playerWatching;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            StartCoroutine(PlayAndTrigger());
        }
    }
    private IEnumerator PlayAndTrigger()
    {
        

        AudioSource.PlayClipAtPoint(clip, targetZone.position);
        Debug.Log("Target Detected");
        yield return new WaitForSeconds(waitTime);

        if (playerWatching)
        {
            EventManager1.TriggerCameraEventAtTarget(targetZone);
        }
        Destroy(gameObject);

    }

}
