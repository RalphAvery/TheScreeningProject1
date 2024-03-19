using UnityEngine;

public class TurnBlackAnimation : MonoBehaviour
{
    [Range(1.0f, 10.0f)] // Adjust the min and max values as needed
    public float defaultTransitionTime = 5.0f; // Default transition time

    private Renderer paintingRenderer;
    private Color startColor; // Renamed from originalColor
    private Color desiredColor = new Color(0.369f, 0.031f, 0.031f); // Color set to 5E0808
    private float animationTimer = 0f;

    void Start()
    {
        // Get the renderer component of the painting prefab
        paintingRenderer = GetComponent<Renderer>();

        // Check if paintingRenderer is not null
        if (paintingRenderer != null)
        {
            startColor = paintingRenderer.material.color; // Renamed from originalColor
        }
        else
        {
            Debug.LogError("No renderer found on the object.");
        }
    }

    private void Update()
    {
        // Check if paintingRenderer is not null
        if (paintingRenderer != null)
        {
            // Increment animationTimer
            animationTimer += Time.deltaTime; // Renamed from transitionTime

            // Calculate the progress of the transition
            float progress = Mathf.Clamp01(animationTimer / defaultTransitionTime); // Renamed from transitionTime

            // Interpolate between startColor and desiredColor
            Color lerpedColor = Color.Lerp(startColor, desiredColor, progress);

            // Apply the interpolated color to the renderer's material
            paintingRenderer.material.color = lerpedColor;

            // Check if transition is complete
            if (progress >= 1.0f)
            {
                // Transition complete, you can stop or reset the animation here if needed
            }
        }
        else
        {
            Debug.LogError("No renderer found on the object.");
        }
    }
}
