using UnityEngine;

public class DPadInputTest : MonoBehaviour
{
    private bool isDPadPressed = false;

    void Update()
    {
        // Check if the D-Pad is not already pressed and if D-Pad Up is pressed
        if (!isDPadPressed && Input.GetAxisRaw("DPADL") > -0.5f)
        {
            Debug.Log("D-Pad Up pressed");

            // Set the flag to true to indicate D-Pad is pressed
            isDPadPressed = true;

            // Call a method to handle the D-Pad press
            HandleDPadPress();
        }

        // Check if D-Pad is released
        if (isDPadPressed && Input.GetAxisRaw("DPADL") <= -0.5f)
        {
            // Reset the flag since D-Pad is released
            isDPadPressed = false;
        }
    }

    void HandleDPadPress()
    {
        // Do something when D-Pad is pressed
    }
}
