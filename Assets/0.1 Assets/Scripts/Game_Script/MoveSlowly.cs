using UnityEngine;

namespace itsaMeKen
{
    public class MoveToEnd : MonoBehaviour
    {
        public Transform startPoint;
        public Transform endPoint;
        public float speed = 5f;

        private bool isMovingToEnd = false;

        void Start()
        {
            transform.position = startPoint.position;
        }

        void Update()
        {
            if (!isMovingToEnd)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, endPoint.position, step);

                if (Vector3.Distance(transform.position, endPoint.position) < 0.001f)
                {
                    isMovingToEnd = true;
                }
            }
        }
    }
}