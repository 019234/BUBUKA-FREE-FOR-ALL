using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItsaMeKen
{
    public class SpawnerWithDelay : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour spawner;

        public float timerDelay = 5f;

        private void Start()
        {
            StartCoroutine(ActivateAnimatorAfterDelay());
        }

        private IEnumerator ActivateAnimatorAfterDelay()
        {
            yield return new WaitForSeconds(timerDelay);

            spawner.enabled = true;
        }
    }
}