using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public enum InteractableType { Door };
    public InteractableType ObjectType;

    bool doorOpened = false;
    Animator animator;
    AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // add interactable object types with the enum InteractableType, run specific method for each
    public void Interact()
    {
        switch (ObjectType)
        {
            case InteractableType.Door:
                animator?.SetTrigger("Open");

                if (!doorOpened) audioSource?.Play();

                doorOpened = true;
                break;
        }
        // add more cases here
    }
}
