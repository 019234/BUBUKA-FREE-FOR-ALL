using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItsaMeKen
{
    public class FeetSoundFx : MonoBehaviour
    {
        [Header("Sound")]
        [SerializeField] private AudioClip[] fallSoundClips;

        private bool _fallFinishedClip;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground") && collision.relativeVelocity.magnitude > 5.5)
            {
                if (!_fallFinishedClip)
                {
                    SoundFXManager.instance.PlayRandomSoundFXClip(fallSoundClips, transform, 0.7f);
                    _fallFinishedClip = true;
                }
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _fallFinishedClip = false;  
            }
        }

    }
}
