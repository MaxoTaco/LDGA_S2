using System.Collections;
using UnityEngine;

public class PlayParticle : MonoBehaviour
{
    [SerializeField] private float waitTime;
    [SerializeField] private ParticleSystem particle;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("player detected");
        if (other.CompareTag("Player"))
        {
            var moveScript = other.GetComponent<PlayerControllerTony>();
            if (moveScript != null)
            {
                Debug.Log("Player move enabled false");
                moveScript.enabled = false;
            }
            StartCoroutine(waitAndPlay());
        }
    }
    private IEnumerator waitAndPlay()
    {
        while (true)
        {
            particle.Play();

            Debug.Log("particle played");

            yield return new WaitForSeconds(waitTime);
        }
    }
   
}
