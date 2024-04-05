using UnityEngine;

namespace ItsaMeKen
{
    public class buttonActivatorMenu : MonoBehaviour
    {
        [SerializeField] private GameObject PlayerInstantiate;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private string _inputNameJump;

        [SerializeField] private GameObject objectToDisable;

        private bool hasDoneAction = false;



        private void Update()
        {
            if (!hasDoneAction && Input.GetButtonDown(_inputNameJump))
            {
                Instantiate(PlayerInstantiate, spawnPoint.position, spawnPoint.rotation);

                if (objectToDisable != null)
                {
                    objectToDisable.SetActive(false);
                }


                hasDoneAction = true;
            }
        }
    }
}
