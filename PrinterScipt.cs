using UnityEngine;

public class PrinterController : MonoBehaviour
{
    public GameObject paperPrefab;
    public Transform paperSpawnPoint;
    public float spawnForce = 10f;
    public Animator paperAnimator;

    private GameObject currentPaper;

    void Update()
    {
        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits the printer object
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                // Spawn and push the paper only if the printer object is clicked
                SpawnAndPushPaper();
            }
        }
    }

    void SpawnAndPushPaper()
    {
        if (currentPaper != null)
        {
            Destroy(currentPaper);
        }

        Vector3 spawnPosition = paperSpawnPoint.position;
        GameObject paper = Instantiate(paperPrefab, spawnPosition, Quaternion.identity);
        currentPaper = paper;

        Rigidbody paperRigidbody = paper.GetComponent<Rigidbody>();
        if (paperRigidbody != null)
        {
            paperRigidbody.AddForce(transform.forward * spawnForce, ForceMode.Impulse);
        }

        // Trigger animation
        paperAnimator.SetTrigger("Click");
    }
}
