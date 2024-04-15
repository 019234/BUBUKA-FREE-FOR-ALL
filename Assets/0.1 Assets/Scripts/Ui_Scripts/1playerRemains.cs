using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ItsaMeKen
{
    public class OnePlayerRemain : MonoBehaviour
    {
        private bool p1 = false;
        private bool p2 = false;
        private bool p3 = false;
        private bool p4 = false;

        public GameObject win1;
        public GameObject win2;
        public GameObject win3;
        public GameObject win4;

        void Update()
        {

            HeadP1 headP1 = FindObjectOfType<HeadP1>();
            if (headP1 != null)
            {
                p1 = true;
                if (!headP1.IsAlive())
                {
                    p1 = false;
                }
            }

            HeadP2 headP2 = FindObjectOfType<HeadP2>();
            if (headP2 != null)
            {
                p2 = true;
                if (!headP2.IsAlive())
                {
                    p2 = false;
                }
            }

            HeadP3 headP3 = FindObjectOfType<HeadP3>();
            if (headP3 != null)
            {
                p3 = true;
                if (!headP3.IsAlive())
                {
                    p3 = false;
                }
            }

            HeadP4 headP4 = FindObjectOfType<HeadP4>();
            if (headP4 != null)
            {
                p4 = true;
                if (!headP4.IsAlive())
                {
                    p4 = false;
                }
            }

            if (p1 && !p2 && p3 && p4)
            {
                win1.SetActive(true);
                StartCoroutine(LoadNextSceneAfterDelay());
            }
            else
            {
                win1.SetActive(false);
            }

            if (!p1 && p2 && p3 && p4)
            {
                win2.SetActive(true);
                StartCoroutine(LoadNextSceneAfterDelay());
            }
            else
            {
                win2.SetActive(false);
            }

            if (!p1 && !p2 && p3 && !p4)
            {
                win3.SetActive(true);
                StartCoroutine(LoadNextSceneAfterDelay());
            }
            else
            {
                win3.SetActive(false);
            }

            if (!p1 && !p2 && !p3 && p4)
            {
                win4.SetActive(true);
                StartCoroutine(LoadNextSceneAfterDelay());
            }
            else
            {
                win4.SetActive(false);
            }
        }

        IEnumerator LoadNextSceneAfterDelay()
        {
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
