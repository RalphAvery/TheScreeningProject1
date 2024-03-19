using UnityEngine;
using UnityEngine.UI;

public class EndGameScreenFader : MonoBehaviour
{
    public Image fadeImage; // Reference to the Image component

    private float fadeDuration = 1.0f; // Duration of the fade effect
    private float fadeTimer = 0f; // Timer for the fading effect

    void Start()
    {
        // Disable the script at the start of the game
        enabled = false;

        // Check if fadeImage is assigned
        if (fadeImage == null)
        {
            Debug.LogError("Fade Image is not assigned.");
        }
    }

    void Update()
    {
        // Increment the fade timer if fading is in progress
        if (fadeTimer < fadeDuration)
        {
            fadeTimer += Time.deltaTime;

            // Check if fadeImage is assigned
            if (fadeImage != null)
            {
                // Calculate the alpha value based on the fade duration
                float alpha = Mathf.Clamp01(fadeTimer / fadeDuration);

                // Set the alpha value of the color property of the Image component
                Color color = fadeImage.color;
                color.a = alpha;
                fadeImage.color = color;
            }
            else
            {
                Debug.LogError("Fade Image is not assigned.");
            }

            // If the fading is complete, disable the script
            if (fadeTimer >= fadeDuration)
            {
                enabled = false; // Disable the script
            }
        }
    }

    public void StartFading(float duration)
    {
        // Reset the fade timer
        fadeTimer = 0f;

        // Set the fade duration
        fadeDuration = duration;

        // Enable the script to start fading
        enabled = true;
    }
}
