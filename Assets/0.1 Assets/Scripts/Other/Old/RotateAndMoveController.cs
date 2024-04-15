using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithCenterController : MonoBehaviour
{
    public Transform centerPoint;
    private float moveSpeed = 15f;
    private float maxDistance = 0.5f;

    [SerializeField] private string _inputNameHorizontal;
    [SerializeField] private string _inputNameVertical;

    private void Update()
    {
        // Check for input to move
        float horizontalInput = Input.GetAxis(_inputNameHorizontal);
        float verticalInput = Input.GetAxis(_inputNameVertical);

        // Move based on input in local space
        MoveWithInput(horizontalInput, verticalInput);

        // Clamp the distance to stay within the specified range
        ClampDistance();
    }

    private void MoveWithInput(float horizontal, float vertical)
    {
        // Move based on input in local space
        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.Self);
    }

    private void ClampDistance()
    {
        // Calculate the current distance from the center
        float currentDistance = Vector3.Distance(centerPoint.position, transform.position);

        // If the current distance exceeds the maximum distance, snap back to the center
        if (currentDistance > maxDistance)
        {
            // Calculate the direction from the center to the current position
            Vector3 directionToCenter = (centerPoint.position - transform.position).normalized;

            // Calculate the new position based on snapping back
            Vector3 newPosition = centerPoint.position - directionToCenter * maxDistance;

            // Update the object's position
            transform.position = newPosition;
        }
    }
}
