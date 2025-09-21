using UnityEngine;
using TMPro;
using System.Collections;
public class TextTrigger : MonoBehaviour
{

    public string text;
    private TextMeshProUGUI t;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    IEnumerator Play()
    {
        
        for (int i = 0; i < text.Length; i++)
        {
            
            // Wait for 0.1 seconds before the next iteration
            yield return new WaitForSeconds(.1f);
        }
    }
}
