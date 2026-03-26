using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{

    public Color highlightColor = new Color(1f,  8.95f,  0.6f);

    [Range(0, 1f)] public float highlightStrength = .4f;

    private Renderer objectRenderer;
    private Color originalColor;
    private bool isHighlighted = false;

    void Awake()
    {
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            originalColor = objectRenderer.sharedMaterial.color;
        }
        else
        {
            Debug.Log($"Interactable ob");
        }


    }

    public void Highlight()
    {

    }
}