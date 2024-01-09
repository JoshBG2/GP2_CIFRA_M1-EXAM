using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailTrigger : MonoBehaviour
{
    public string originalColorHex = "#484545";
    private Color originalColor;
    private Color collisionColor = Color.yellow;

    private Renderer objectRenderer;
    private bool isGrinding = false;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();

        // Convert hexadecimal codes to Color
        ColorUtility.TryParseHtmlString(originalColorHex, out originalColor);

        objectRenderer.material.color = originalColor;
    }

    void Update()
    {
        if (isGrinding)
        {
            // Change color while colliding with player
            objectRenderer.material.color = collisionColor;
        }
        else
        {
            // Revert back to the original color when not colliding
            objectRenderer.material.color = originalColor;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isGrinding = true;
            
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isGrinding = false;
            
        }
    }
}
