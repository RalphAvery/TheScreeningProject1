using UnityEngine;

public class PaperTrayAnimationHandler : MonoBehaviour
{
    public Animator animator;

    // Method to trigger the animation
    public void TriggerAnimation()
    {
        // Set the "Tray_Click" parameter to trigger the animation
        animator.SetBool("Tray_Click", true);
    }
}
