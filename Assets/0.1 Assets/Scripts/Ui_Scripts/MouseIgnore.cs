using UnityEngine;

namespace itsaMeKen
{
    public class DisableMouseInput : MonoBehaviour
    {
        private static DisableMouseInput instance;

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
        }

        void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}