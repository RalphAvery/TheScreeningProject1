using UnityEngine;
using TMPro;

public class ComputerScript : MonoBehaviour
{
    public TMP_InputField inputField;

    private void Update()
    {
        // Check for Enter key press
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckInput();
        }
    }

    private void CheckInput()
    {
        // Ensure inputField is not null
        if (inputField != null)
        {
            string input = inputField.text;
            // Implement your logic for checking the input here
            Debug.Log("Typed: " + input);

            // Clear the input field after processing
            inputField.text = "";
        }
        else
        {
            Debug.LogError("InputField is not assigned in the inspector.");
        }
    }
}
