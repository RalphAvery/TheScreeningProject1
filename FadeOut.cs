using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeOut : MonoBehaviour
{
    public float fadeDuration = 1.0f; // Duration of the fade effect
    public CanvasGroup canvasGroup; // Reference to the CanvasGroup component

    public void StartFadeOut()
    {
        // Start the fade-out effect
        StartCoroutine(FadeOutTitleScreen());
    }

    IEnumerator FadeOutTitleScreen()
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            canvasGroup.alpha = alpha;
            yield return null;
        }

        // Deactivate the title screen GameObject after fading out
        gameObject.SetActive(false);
    }
}
