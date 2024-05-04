using UnityEngine;

namespace ItsaMeKen
{
    public class Ai_Look : MonoBehaviour
    {
        public string targetTag = "Player"; 
        public float rotationSpeed = 50f;

        void Update()
        {
 
            GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);

             
            foreach (GameObject target in targets)
            {
              
                Vector3 directionToTarget = target.transform.position - transform.position;

                 
                directionToTarget.y = 0f;

                
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget, Vector3.up) * Quaternion.Euler(0, 90, 0);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
