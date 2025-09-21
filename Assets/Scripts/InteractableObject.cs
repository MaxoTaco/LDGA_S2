using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public enum InteractableType { TestObject };
    public InteractableType ObjectType;

    // add interactable object types with the enum InteractableType, run specific method for each
    public void Interact()
    {
        switch (ObjectType)
        {
            case InteractableType.TestObject:
                // run case specific method
                Debug.Log("Interacted");
                break;
        }
        // add more cases here
    }
}
