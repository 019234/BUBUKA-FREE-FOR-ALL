using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItsaMeKen
{
    public class TrainController : MonoBehaviour
    {
        public GameObject trainPrefab; 
        public Transform startPoint;  
        public Transform endPoint;    
        public float speed = 5f;       
        public float interval = 180f;

        [Header("SoundClip")]
        [SerializeField] private AudioClip[] passingByClips;

        void Start()
        {
            StartCoroutine(SpawnAndMoveTrainCoroutine());
        }

        IEnumerator SpawnAndMoveTrainCoroutine()
        {
            while (true)
            {
                GameObject train = Instantiate(trainPrefab, startPoint.position, startPoint.rotation);
                SoundFXManager.instance.PlayRandomSoundFXClip(passingByClips, transform, 1f);
                MoveTrain(train, startPoint.position, endPoint.position);
                yield return new WaitForSeconds(interval);
            }
        }

        void MoveTrain(GameObject train, Vector3 from, Vector3 to)
        {
            float distance = Vector3.Distance(from, to);
            float travelTime = distance / speed;
            StartCoroutine(MoveToPosition(train, to, travelTime));
        }

        IEnumerator MoveToPosition(GameObject train, Vector3 targetPosition, float timeToMove)
        {
            Vector3 currentPos = train.transform.position;
            float elapsedTime = 0;
            while (elapsedTime < timeToMove)
            {
                train.transform.position = Vector3.Lerp(currentPos, targetPosition, (elapsedTime / timeToMove));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            train.transform.position = targetPosition;
            Destroy(train);
        }
    }
}