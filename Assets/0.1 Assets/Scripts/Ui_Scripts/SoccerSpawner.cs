using UnityEngine;

namespace ItsaMeKen
{
    public class SoccerSpawner : MonoBehaviour
    {
        [Header("Player")]
        public GameObject playerPrefab1;
        public GameObject playerPrefab2;
        public GameObject playerPrefab3;
        public GameObject playerPrefab4;
        [Header("Post")]
        public GameObject postPrefabP1;
        public GameObject postPrefabP2;
        public GameObject postPrefabP3;
        public GameObject postPrefabP4;
        [Header("uiScore")]
        public GameObject scoreP1;
        public GameObject scoreP2;
        public GameObject scoreP3;
        public GameObject scoreP4;
 
        [Header("Player Spawn Location")]
        public Transform spawnPoint1;
        public Transform spawnPoint2;
        public Transform spawnPoint3;
        public Transform spawnPoint4;


        private void Start()
        {

            P1_checker p1_checker = FindObjectOfType<P1_checker>();
            if (p1_checker != null && p1_checker.DoesPlayerExist())
            {
                InstantiatePlayer1();
            }


            P2_checker p2_checker = FindObjectOfType<P2_checker>();
            if (p2_checker != null && p2_checker.DoesPlayerExist())
            {
                InstantiatePlayer2();
            }


            P3_checker p3_checker = FindObjectOfType<P3_checker>();
            if (p3_checker != null && p3_checker.DoesPlayerExist())
            {
                InstantiatePlayer3();
            }


            P4_checker p4_checker = FindObjectOfType<P4_checker>();
            if (p4_checker != null && p4_checker.DoesPlayerExist())
            {
                InstantiatePlayer4();
            }
        }

        private void InstantiatePlayer1()
        {

            Instantiate(playerPrefab1, spawnPoint1.position, spawnPoint1.rotation);
            postPrefabP1.SetActive(true);
            scoreP1.SetActive(true);


        }

        private void InstantiatePlayer2()
        {
            Instantiate(playerPrefab2, spawnPoint2.position, spawnPoint2.rotation);
            postPrefabP2.SetActive(true);
            scoreP2.SetActive(true);
        }

        private void InstantiatePlayer3()
        {
            Instantiate(playerPrefab3, spawnPoint3.position, spawnPoint3.rotation);
            postPrefabP3.SetActive(true);
            scoreP3.SetActive(true);

        }

        private void InstantiatePlayer4()
        {
            Instantiate(playerPrefab4, spawnPoint4.position, spawnPoint4.rotation);
            postPrefabP4.SetActive(true);
            scoreP4.SetActive(true);

        }
    }
}