using UnityEngine.SceneManagement;
using UnityEngine;

/// <summary>
/// Pause in anyGame, it doesn't stop time, it reappears in any levels. press Escape
/// </summary>
/// 

public class PauseScript : MonoBehaviour
{
    public KeyCode keyToPress;

    [SerializeField] private GameObject canvas;
    [SerializeField] private int sceneIndexToLoad;

    private static PauseScript instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        { 
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            canvas.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SkipToNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    public void LoadSceneByIndex()
    {
        SceneManager.LoadScene(sceneIndexToLoad);
    }
}
