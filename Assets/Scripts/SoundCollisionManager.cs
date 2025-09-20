using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundCollisionManager : MonoBehaviour
{
    /// <summary>
    /// Should be attached to the player.
    /// Checks for collision with SoundColliders and plays their associated sound.
    /// Ask Max if confused.
    /// </summary>

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SoundCollider")
        {
            other.gameObject.GetComponent<SoundCollider>().PlaySound();
        }
    }
}
