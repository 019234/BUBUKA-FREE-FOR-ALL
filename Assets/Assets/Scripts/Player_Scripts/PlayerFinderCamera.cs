using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    void Start()
    {
        ApplyTargetGroupLogic();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ApplyTargetGroupLogic();
    }

    void ApplyTargetGroupLogic()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        CinemachineTargetGroup targetGroup = FindObjectOfType<CinemachineTargetGroup>();

        if (targetGroup != null)
        {
            foreach (GameObject player in players)
            {
                targetGroup.AddMember(player.transform, 1f, 0f);
            }
        }
    }
}
