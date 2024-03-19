using UnityEngine;

public class CandleLight : MonoBehaviour
{
    public float fadeDuration = 5.0f; // Duration of the fade out effect

    private Light candleLight;
    private float timer = 0f;
    private bool fadingOut = false;
    private float initialIntensity; // Store the initial intensity of the light

    void Start()
    {
        // Get the Light component attached to the game object
        candleLight = GetComponent<Light>();

        // Store the initial intensity of the light
        initialIntensity = candleLight.intensity;
    }

    void Update()
    {
        // Check if the light is fading out
        if (fadingOut)
        {
            // Increment the timer
            timer += Time.deltaTime;

            // Calculate the normalized progress of the fade out
            float progress = Mathf.Clamp01(timer / fadeDuration);

            // Calculate the intensity value based on the progress
            float intensity = Mathf.Lerp(initialIntensity, 0f, progress);

            // Apply the intensity to the light
            candleLight.intensity = intensity;

            // Check if the fade out is complete
            if (progress >= 1.0f)
            {
                // Ensure the light is completely turned off
                candleLight.intensity = 0f;

                // Reset the timer and fading status
                timer = 0f;
                fadingOut = false;
            }
        }
    }

    // Method to start fading out the light
    public void StartFadeOut()
    {
        fadingOut = true;
    }
}
