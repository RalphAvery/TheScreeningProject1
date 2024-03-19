using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Lightning : MonoBehaviour
{
    public Light lightningLight;
    public float minIntensity = 1f;
    public float maxIntensity = 8f;
    public float minDelay = 0.1f;
    public float maxDelay = 0.5f;

    // Define an event to trigger when lightning occurs
    public UnityEvent OnLightning;

    private bool isFlashing = false;

    void Start()
    {
        // Start the lightning effect loop
        StartCoroutine(FlashLightning());
    }

    IEnumerator FlashLightning()
    {
        while (true)
        {
            // Generate a random delay
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            // Start flashing
            isFlashing = true;

            // Set a random intensity
            float intensity = Random.Range(minIntensity, maxIntensity);
            lightningLight.intensity = intensity;

            // Trigger the lightning event
            OnLightning.Invoke();

            // Wait for a short duration
            yield return new WaitForSeconds(0.1f);

            // Reset intensity
            lightningLight.intensity = 0;

            // Stop flashing
            isFlashing = false;
        }
    }

    // You can call this method to trigger a lightning flash manually
    public void TriggerLightning()
    {
        if (!isFlashing)
        {
            StartCoroutine(FlashLightning());
        }
    }
}
