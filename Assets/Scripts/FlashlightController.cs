using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FlashlightController : MonoBehaviour
{
    public GameObject lightSource;
    public AudioClip onSFX;
    public AudioClip offSFX;

    AudioSource audioSource;

    bool flashlightActive = true;

    void Start()
    {
        lightSource.SetActive(true);
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            flashlightActive = !flashlightActive;
            lightSource.SetActive(flashlightActive);

            audioSource.clip = flashlightActive ? onSFX : offSFX;
            audioSource.Play();
        }
    }
}
