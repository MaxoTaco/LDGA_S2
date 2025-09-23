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
        if (Input.GetKeyDown("space"))
        {
            flashlightActive = !flashlightActive;
            lightSource.SetActive(flashlightActive);
        }
    }
}
