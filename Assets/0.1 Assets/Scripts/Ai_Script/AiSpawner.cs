using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ItsaMeKen
{
    public class AiSpawner : MonoBehaviour
    {

        [Header("Options")]
        public int numberOfAiToSpawn = 5;
        public float spawnInterval = 15f;

        [Header("Objects to spawn")]
        public GameObject aiP1;
        public GameObject aiP2;
        public GameObject aiP3;
        public GameObject aiP4;

        [Header("Spawn Location")]

        [SerializeField] private Transform spawnP1;
        [SerializeField] private Transform spawnP2;
        [SerializeField] private Transform spawnP3;
        [SerializeField] private Transform spawnP4;

        private bool isP1Found = false;
        private bool isP2Found = false;
        private bool isP3Found = false;
        private bool isP4Found = false;

        private HeadP1 headP1;
        private HeadP2 headP2;
        private HeadP3 headP3;
        private HeadP4 headP4;

        private bool spawningEnabledP1 = true;
        private bool spawningEnabledP2 = true;
        private bool spawningEnabledP3 = true;
        private bool spawningEnabledP4 = true;

        private int aiSpawnedP1 = 0;
        private int aiSpawnedP2 = 0;
        private int aiSpawnedP3 = 0;
        private int aiSpawnedP4 = 0;

        void Update()
        {
            headP1 = FindObjectOfType<HeadP1>();
            if (headP1 != null)
            {
                if (!isP1Found)
                {
                    StartCoroutine(SpawnAiP1());
                }
            }

            headP2 = FindObjectOfType<HeadP2>();
            if (headP2 != null)
            {
                if (!isP2Found)
                {
                    StartCoroutine(SpawnAiP2());
                }
            }

            headP3 = FindObjectOfType<HeadP3>();
            if (headP3 != null)
            {
                if (!isP3Found)
                {
                    StartCoroutine(SpawnAiP3());
                }
            }

            headP4 = FindObjectOfType<HeadP4>();
            if (headP4 != null)
            {
                if (!isP4Found)
                {
                    StartCoroutine(SpawnAiP4());
                }
            }
        }

        IEnumerator SpawnAiP1()
        {
            while (spawningEnabledP1)
            {
                if (aiSpawnedP1 < numberOfAiToSpawn)
                {
                    Instantiate(aiP1, spawnP1.position, Quaternion.identity);
                    aiSpawnedP1++;
                    spawningEnabledP1 = false;
                    yield return new WaitForSeconds(spawnInterval);
                    spawningEnabledP1 = true;
                }
                else
                {
                    spawningEnabledP1 = false;
                }
            }
        }

        IEnumerator SpawnAiP2()
        {
            while (spawningEnabledP2)
            {
                if (aiSpawnedP2 < numberOfAiToSpawn)
                {
                    Instantiate(aiP2, spawnP2.position, Quaternion.identity);
                    aiSpawnedP2++;
                    spawningEnabledP2 = false;
                    yield return new WaitForSeconds(spawnInterval);
                    spawningEnabledP2 = true;
                }
                else
                {
                    spawningEnabledP2 = false;
                }
            }
        }

        IEnumerator SpawnAiP3()
        {
            while (spawningEnabledP3)
            {
                if (aiSpawnedP3 < numberOfAiToSpawn)
                {
                    Instantiate(aiP3, spawnP3.position, Quaternion.identity);
                    aiSpawnedP3++;
                    spawningEnabledP3 = false;
                    yield return new WaitForSeconds(spawnInterval);
                    spawningEnabledP3 = true;
                }
                else
                {
                    spawningEnabledP3 = false;
                }
            }
        }

        IEnumerator SpawnAiP4()
        {
            while (spawningEnabledP4)
            {
                if (aiSpawnedP4 < numberOfAiToSpawn)
                {
                    Instantiate(aiP4, spawnP4.position, Quaternion.identity);
                    aiSpawnedP4++;
                    spawningEnabledP4 = false;
                    yield return new WaitForSeconds(spawnInterval);
                    spawningEnabledP4 = true;
                }
                else
                {
                    spawningEnabledP4 = false;
                }
            }
        }
    }
}
