using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public GameObject lightSource;
    
    bool flashlightActive = true;

    void Start()
    {
        lightSource.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            flashlightActive = !flashlightActive;
            lightSource.SetActive(flashlightActive);
        }
    }
}
