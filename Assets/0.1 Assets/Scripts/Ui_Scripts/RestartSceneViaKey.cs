using UnityEngine;
using UnityEngine.SceneManagement;

namespace ItsaMeKen
{
    public class RestartSceneViaKey : MonoBehaviour
    {
        [SerializeField]
        private KeyCode restartKey = KeyCode.R;

        public float holdDuration = 2f;

        private float keyPressedTime = 0f;
        private bool isRestarting = false;

        void Update()
        {

            if (Input.GetKeyDown(restartKey))
            {
                keyPressedTime = Time.time;
                isRestarting = true;
            }

            if (Input.GetKeyUp(restartKey) || (isRestarting && Time.time - keyPressedTime >= holdDuration))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                isRestarting = false;
            }
        }
    }
}
