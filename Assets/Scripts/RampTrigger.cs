using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampTrigger : MonoBehaviour
{
    public string originalColorHex = "#653900";  // Default is white
    private Color originalColor;
    private Color collisionColor = Color.black;

    private Renderer objectRenderer;
    private bool hasCollided = false;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();

        // Convert hexadecimal codes to Color
        ColorUtility.TryParseHtmlString(originalColorHex, out originalColor);

        objectRenderer.material.color = originalColor;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!hasCollided)
            {
                // Change color on first collision with player
                objectRenderer.material.color = collisionColor;
                hasCollided = true;
            }
            else
            {
                // Revert back to original color on subsequent collisions with player
                objectRenderer.material.color = originalColor;
                hasCollided = false;
            }
        }
    }
}
