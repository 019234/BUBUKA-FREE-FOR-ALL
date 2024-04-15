using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

namespace ItsaMeKen
{
    public class VideoPlayerController : MonoBehaviour
    {
        public VideoPlayer videoPlayer;
        public string _inputNameJump;

        void Start()
        {
            if (videoPlayer == null)
            {
                videoPlayer = GetComponent<VideoPlayer>();
            }

            if (videoPlayer != null)
            {
                videoPlayer.loopPointReached += OnVideoEnd;
                videoPlayer.Play();
            }
        }

        void Update()
        {
            if (Input.GetButtonDown(_inputNameJump))
            {
                LoadNextScene();
            }
        }

        void OnVideoEnd(VideoPlayer vp)
        {
            LoadNextScene();
        }

        void LoadNextScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        void OnDestroy()
        {
            if (videoPlayer != null)
            {
                videoPlayer.loopPointReached -= OnVideoEnd;
            }
        }
    }
}