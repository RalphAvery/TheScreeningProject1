using UnityEngine;

public class WindowFlashing : MonoBehaviour
{
    public GameObject windowCanvas; // Reference to the canvas containing window images

    // This method is called when lightning occurs
    public void FlashWindows()
    {
        // Activate the canvas to show the window images
        windowCanvas.SetActive(true);

        // Add any additional logic for flashing the images here
    }
}
