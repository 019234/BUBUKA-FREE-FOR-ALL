using UnityEngine;

namespace ItsaMeKen
{
    public class Ai_Look : MonoBehaviour
    {
        public string targetTag = "Player"; // Tag of the target GameObject
        public float rotationSpeed = 50f;

        void Update()
        {
            // Find all GameObjects with the specified tag
            GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);

            // Rotate towards each target
            foreach (GameObject target in targets)
            {
                // Calculate the direction to the target
                Vector3 directionToTarget = target.transform.position - transform.position;

                // Ignore the vertical component to keep the rotation only around the Y-axis
                directionToTarget.y = 0f;

                // Rotate towards the target's right side
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget, Vector3.up) * Quaternion.Euler(0, 90, 0);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
