using UnityEngine;

public class DPadInputTest : MonoBehaviour
{
    private bool isDPadPressed = false;

    void Update()
    {
        // Check if the D-Pad is not already pressed and if D-Pad Up is pressed
        if (!isDPadPressed && Input.GetAxisRaw("DPADLEFT") > -0.5f)
        {
            isDPadPressed = true;
            HandleDPadPress();
        }
        if (isDPadPressed && Input.GetAxisRaw("DPADL") <= -0.5f)
        {
            isDPadPressed = false;
        }
    }

    void HandleDPadPress()
    {
        
    }
}
