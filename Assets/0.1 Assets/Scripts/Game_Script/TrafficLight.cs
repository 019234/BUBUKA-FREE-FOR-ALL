using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItsaMeKen
{
    public class TrafficLight : MonoBehaviour
    {
        public Light blinkingLight;
        public float blinkDuration = 5f;
        public float blinkInterval = 180f;

        private bool isBlinking = false;

        void Start()
        {
            StartCoroutine(BlinkCoroutine());
        }

        IEnumerator BlinkCoroutine()
        {
            while (true)
            {
                isBlinking = true;
                yield return new WaitForSeconds(blinkDuration);

                isBlinking = false;
                blinkingLight.enabled = false;

                yield return new WaitForSeconds(blinkInterval - blinkDuration);

                blinkingLight.enabled = true;
            }
        }

        void Update()
        {
            if (isBlinking)
            {
                blinkingLight.enabled = !blinkingLight.enabled;
            }
        }
    }
}