using System.Diagnostics;
using UnityEngine;

namespace ItsaMeKen
{


    public class MoveToObject : MonoBehaviour
    {
        public GameObject target_Play;
        public GameObject target_Menu;
        public GameObject target_Options;
        public GameObject target_Credits;
        public GameObject target_Exit;

        public void MoveToPlay()
        {
            transform.position = target_Play.transform.position;
        }
        public void MoveToMainMenu()
        {
            transform.position = target_Menu.transform.position;
        }
        public void MoveToOptions()
        {
            transform.position = target_Options.transform.position;
        }
        public void MoveToCredits()
        {
            transform.position = target_Credits.transform.position;
        }
        public void MoveToExit()
        {
            transform.position = target_Exit.transform.position;
        }
    }
}
