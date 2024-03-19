using UnityEngine;
using TMPro;

public class MainCameraController : MonoBehaviour
{
    public float sensitivity = 1.0f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * horizontalInput * sensitivity);
        }

        // Add any additional code that you need to execute in the Update method here
    }
}
