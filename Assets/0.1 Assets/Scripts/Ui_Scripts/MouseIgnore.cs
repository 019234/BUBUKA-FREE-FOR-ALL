using UnityEngine;

namespace itsaMeKen
{
    public class DisableMouseInput : MonoBehaviour
    {
        void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}