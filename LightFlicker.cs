using UnityEngine;
using System.Collections;
public class LightFlicker : MonoBehaviour
{
    public float minIntensity = 0.5f; // Minimum intensity of the light
    public float maxIntensity = 1.0f; // Maximum intensity of the light
    public float flickerSpeed = 1.0f; // Speed of the flickering effect
    public float flickerInterval = 3.0f; // Interval between flickers

    private Light lightComponent;
    private float timeSinceLastFlicker = 0.0f;
    private bool isFlickering = false;

    void Start()
    {
        lightComponent = GetComponent<Light>();
        if (lightComponent == null)
        {
            Debug.LogError("Light component not found.");
            enabled = false; // Disable the script if the light component is not found
        }
    }

    void Update()
    {
        // Check if the light is not currently flickering
        if (!isFlickering)
        {
            // Increment time since last flicker
            timeSinceLastFlicker += Time.deltaTime;

            // Check if it's time to flicker
            if (timeSinceLastFlicker >= flickerInterval)
            {
                // Start flickering
                StartCoroutine(Flicker());
                timeSinceLastFlicker = 0.0f;
            }
        }
    }

    IEnumerator Flicker()
    {
        isFlickering = true;

        // Flicker the light for a random duration
        float flickerDuration = Random.Range(0.1f, 0.5f);
        float elapsedTime = 0.0f;
        while (elapsedTime < flickerDuration)
        {
            // Randomly change the intensity of the light
            float randomIntensity = Random.Range(minIntensity, maxIntensity);
            lightComponent.intensity = randomIntensity;

            // Wait for a short time to create the flickering effect
            yield return new WaitForSeconds(Random.Range(0.01f, 0.1f));

            elapsedTime += Time.deltaTime;
        }

        // Reset the light intensity to its original value
        lightComponent.intensity = maxIntensity;

        isFlickering = false;
    }
}
