using UnityEngine;

public class PaperController : MonoBehaviour
{
    public Animator printerAnimator;
    public Animator paperTrayAnimator;

    void Update()
    {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position into the scene
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits a collider
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the collider belongs to the printer
                if (hit.collider.gameObject.CompareTag("Printer"))
                {
                    // Trigger animation for the printer
                    if (printerAnimator != null)
                    {
                        printerAnimator.SetTrigger("Click");
                    }
                }
                // Check if the collider belongs to the paper tray
                else if (hit.collider.gameObject.CompareTag("PaperTray"))
                {
                    // Trigger animation for the paper tray
                    if (paperTrayAnimator != null)
                    {
                        paperTrayAnimator.SetTrigger("Tray_Click");
                    }
                }
            }
        }
    }
}
