using System.Collections;
using UnityEngine;

namespace itsaMeKen
{
    public class ObjectSpawner : MonoBehaviour
    {
        public GameObject objectToSpawn;
        public int numberOfObjectsToSpawn = 5;
        public float spawnInterval = 30f;

        private int objectsSpawned = 0;
        private bool spawningEnabled = true;

        void Start()
        {
            StartCoroutine(SpawnObjects());
        }

        IEnumerator SpawnObjects()
        {
            while (spawningEnabled)
            {
                if (objectsSpawned < numberOfObjectsToSpawn)
                {
                    Instantiate(objectToSpawn, transform.position, Quaternion.identity);
                    objectsSpawned++;
                }
                else
                {
                    spawningEnabled = false;
                }

                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }
}
