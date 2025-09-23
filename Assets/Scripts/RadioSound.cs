using UnityEngine;

public class RadioSound : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private AudioSource audioSource;
    public Transform player;
    public float maxDistance = 10.0f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.Play();
        audioSource.volume = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        
        if (distance < maxDistance)
        {
            audioSource.volume = 1f - (distance / maxDistance);
        }
        else
        {
            audioSource.volume = 0f;
        }
    }
}
