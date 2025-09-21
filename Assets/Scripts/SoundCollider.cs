using System;
using UnityEngine;

public class SoundCollider : MonoBehaviour
{
    /// <summary>
    /// This script should be placed on the collider which will create a sound when the player collides with it.
    /// The soundObject variable should be assigned in the editor and given a Sound Object prefab (although it could be anything with an Audio Source component)
    /// oneTimeOnly is true by default but can be changed if needed. If it is false, the sound plays whenever the player enters the collider. 
    
    /// Ask Max if confused.
    /// </summary>
    
    [SerializeField]
    private GameObject soundObject;

    [SerializeField]
    private bool oneTimeOnly = true;
    private bool canPlay = true;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = soundObject.GetComponent<AudioSource>();
        if(audioSource == null)
            Debug.Log("no audio source found");
    }

    public void PlaySound()
    {
        if (canPlay)
        {
            AudioSource.PlayClipAtPoint(audioSource.clip, soundObject.transform.position);

        }

        if (oneTimeOnly)
        {
            canPlay = false;
        }
    }
}
