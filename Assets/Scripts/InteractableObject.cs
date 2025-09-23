using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public enum InteractableType { Door };
    public InteractableType ObjectType;

    // add interactable object types with the enum InteractableType, run specific method for each
    public void Interact()
    {
        switch (ObjectType)
        {
            case InteractableType.Door:
                Animator animator = GetComponent<Animator>();
                animator.SetTrigger("Open");
                break;
        }
        // add more cases here
    }
}
