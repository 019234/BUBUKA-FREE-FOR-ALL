using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace ItsaMeKen
{
    public class AddToGameObjectChildren : MonoBehaviour
    {
        void Start()
        {
            StartCoroutine(FindEm());
        }

        private IEnumerator FindEm()
        {
            yield return new WaitForSeconds(0.01f);
            ApplyTargetGroupLogic();
        }

        void ApplyTargetGroupLogic()
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            CinemachineTargetGroup targetGroup = FindObjectOfType<CinemachineTargetGroup>();

            if (targetGroup != null)
            {
                targetGroup.m_Targets = new CinemachineTargetGroup.Target[0];

                foreach (GameObject player in players)
                {
                    if (player.CompareTag("Player"))
                    {
                        targetGroup.AddMember(player.transform, 1f, 0f);
                    }
                }
            }
        }
    }
}
