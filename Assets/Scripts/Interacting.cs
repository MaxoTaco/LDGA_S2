using UnityEngine;
using UnityEngine.UI;

public class Interacting : MonoBehaviour
{
    public float interactRange = 3f;
    public LayerMask interactableLayer;
    public Image reticle;
    public float reticleAnimationSpeed = 5f;
    public float reticleScaleFactor = 2f;

    Color initialReticleColor;
    Vector3 initialReticleScale;
    Vector3 targetReticleScale;
    GameObject interactableTarget;

    void Start()
    {
        initialReticleColor = reticle.color;
        initialReticleScale = reticle.transform.localScale;

        targetReticleScale = initialReticleScale * reticleScaleFactor;
    }

    void LateUpdate()
    {
        UpdateUI();

        if (Input.GetMouseButtonDown(0) && interactableTarget)
        {
            InteractableObject interactableObject = interactableTarget.GetComponent<InteractableObject>();
            interactableObject?.Interact();
        }
    }
    
    void UpdateUI()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, interactRange, interactableLayer))
        {
            reticle.color = Color.Lerp(reticle.color, Color.white, reticleAnimationSpeed * Time.deltaTime);
            reticle.transform.localScale = Vector3.Lerp(reticle.transform.localScale, targetReticleScale, reticleAnimationSpeed * Time.deltaTime);
            interactableTarget = hit.collider.gameObject;
        }
        else
        {
            reticle.color = Color.Lerp(reticle.color, initialReticleColor, reticleAnimationSpeed * Time.deltaTime);
            reticle.transform.localScale = Vector3.Lerp(reticle.transform.localScale, initialReticleScale, reticleAnimationSpeed * Time.deltaTime);
            interactableTarget = null;
        }
    }
}