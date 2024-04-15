using System.Collections;
using System.Collections.Generic;   
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ItsaMeKen
{
    public class HeadChecker : MonoBehaviour
    {
        private HeadP1 headP1;
        private HeadP2 headP2;
        private HeadP3 headP3;
        private HeadP4 headP4;

        private bool isP1Found = false;
        private bool isP2Found = false;
        private bool isP3Found = false;
        private bool isP4Found = false;

        [Header("Player UI")]
        
        public GameObject uiP1;
        public GameObject uiP2;
        public GameObject uiP3;
        public GameObject uiP4;

        [Header("KnockOut")]

        public GameObject kOP1;
        public GameObject kOP2;
        public GameObject kOP3;
        public GameObject kOP4;


        [Header("Died")]

        public GameObject diedP1;
        public GameObject diedP2;
        public GameObject diedP3;
        public GameObject diedP4;

        private static HeadChecker instance;

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


        void Update()
        {
            // finds the heads if (headcount = zero then game object p1 true
            //p1Alive && 1 headCount = ...


            headP1 = FindObjectOfType<HeadP1>();
            if (headP1 != null)
            {
                if (!isP1Found)
                {
                    isP1Found = true;
                    uiP1.SetActive(true);

                }
            }

            headP2 = FindObjectOfType<HeadP2>();
            if (headP2 != null)
            {
                if (!isP2Found)
                {
                    isP2Found = true;
                    uiP2.SetActive(true);

                }
            }

            headP3 = FindObjectOfType<HeadP3>();
            if (headP3 != null)
            {
                 if (!isP3Found)
                {
                    isP3Found = true;
                    uiP3.SetActive(true);

                }
            }

            headP4 = FindObjectOfType<HeadP4>();
            if (headP4 != null)
            {
                 if (!isP4Found)
                {
                    isP4Found = true;
                    uiP4.SetActive(true);

                }
            }

            //When theyre sleeping 

            if (headP1 != null && headP1.IsSleeping())
            {
                kOP1.SetActive(true);
            }
            else 
            {
                kOP1.SetActive(false);
            }

            if (headP2 != null && headP2.IsSleeping())
            {
                kOP2.SetActive(true);
            }
            else 
            {
                kOP2.SetActive(false);
            }

            if (headP3 != null && headP3.IsSleeping())
            {
                kOP3.SetActive(true);
            }
            else 
            {
                kOP3.SetActive(false);
            }

            if (headP4 != null && headP4.IsSleeping())
            {
                kOP4.SetActive(true);
            }
            else 
            {
                kOP4.SetActive(false);
            }



            // when they're no longer alive or dead sum sum

            if (headP1 != null && !headP1.IsAlive())
            {

                diedP1.SetActive(true);
                kOP1.SetActive(false);

            }

            if (headP2 != null && !headP2.IsAlive())
            {
                diedP2.SetActive(true);
                kOP2.SetActive(false);
          
            }

            if (headP3 != null && !headP3.IsAlive())
            {
                diedP3.SetActive(true);
                kOP3.SetActive(false);
             
            }

            if (headP4 != null && !headP4.IsAlive())
            {
                diedP4.SetActive(true);
                kOP4.SetActive(false);
             
            }

        }

        //Next scene if only 1 player remains
        // but the players are instantiated, the second player 1 enters it goes directly to next level.


    }
}
