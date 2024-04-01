using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ItsaMeKen
{
    public class Viewpoint : MonoBehaviour
    {
        [Header("Viewpoint")]
        [SerializeField] string PointText = "Press E";
        [Space]
        [SerializeField] Image ImagePrefab;
        [Space]
        [SerializeField, Range(0.1f, 20)] float MaxViewRange = 8;
        [SerializeField, Range(0.1f, 20)] float MaxTextViewRange = 3;

        private Camera cam;
        private GameObject playerController;
        private float distance;
        private Text imageText;
        private Image imageUI;

        void Start()
        {
            cam = Camera.main;
            playerController = GameObject.FindGameObjectWithTag("Player"); // Assuming player controller is tagged as "Player"

            imageUI = Instantiate(ImagePrefab, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
            imageText = imageUI.GetComponentInChildren<Text>();
            imageText.text = PointText;
        }

        void Update()
        {
            if (cam == null || playerController == null)
                return;

            imageUI.transform.position = cam.WorldToScreenPoint(calculateWorldPosition(transform.position, cam));
            distance = Vector3.Distance(playerController.transform.position, transform.position);

            if (distance < MaxTextViewRange)
            {
                Color opacityColor = imageText.color;
                opacityColor.a = Mathf.Lerp(opacityColor.a, 1, 10 * Time.deltaTime);
                imageText.color = opacityColor;
            }
            else
            {
                Color opacityColor = imageText.color;
                opacityColor.a = Mathf.Lerp(opacityColor.a, 0, 10 * Time.deltaTime);
                imageText.color = opacityColor;
            }

            if (distance < MaxViewRange)
            {
                Color opacityColor = imageUI.color;
                opacityColor.a = Mathf.Lerp(opacityColor.a, 1, 10 * Time.deltaTime);
                imageUI.color = opacityColor;
            }
            else
            {
                Color opacityColor = imageUI.color;
                opacityColor.a = Mathf.Lerp(opacityColor.a, 0, 10 * Time.deltaTime);
                imageUI.color = opacityColor;
            }
        }

        private Vector3 calculateWorldPosition(Vector3 position, Camera camera)
        {
            Vector3 camNormal = camera.transform.forward;
            Vector3 vectorFromCam = position - camera.transform.position;
            float camNormDot = Vector3.Dot(camNormal, vectorFromCam.normalized);
            if (camNormDot <= 0f)
            {
                float camDot = Vector3.Dot(camNormal, vectorFromCam);
                Vector3 proj = (camNormal * camDot * 1.01f);
                position = camera.transform.position + (vectorFromCam - proj);
            }
            return position;
        }
    }
}
