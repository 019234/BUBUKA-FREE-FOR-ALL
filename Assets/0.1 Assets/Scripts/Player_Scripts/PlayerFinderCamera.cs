using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace ItsaMeKen
{
    public class AddToGameObjectChildren : MonoBehaviour
    {
        private static AddToGameObjectChildren instance;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }


        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            ApplyTargetGroupLogic();
        }

        void Start()
        {
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