using UnityEngine.SceneManagement;
using UnityEngine;

namespace itsaMeKen
{
    public class PauseScript : MonoBehaviour
    {
        public KeyCode keyToPress;

        [SerializeField] private GameObject canvas;
        [SerializeField] private int sceneIndexToLoad;
        private bool isPaused = false;

        void Update()
        {
            if (Input.GetKeyDown(keyToPress))
            {
                isPaused = !isPaused;
                canvas.SetActive(isPaused);
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
}