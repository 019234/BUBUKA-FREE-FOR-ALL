using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ItsaMeKen
{
    public class AnimationStarterWithDelay : MonoBehaviour
    {
        private Animator animator;

        private void Start()
        {

            animator = GetComponent<Animator>();
            StartCoroutine(ActivateAnimatorAfterDelay());
        }

        private IEnumerator ActivateAnimatorAfterDelay()
        {
            yield return new WaitForSeconds(10f);

            if (animator != null)
            {
                animator.SetBool("IsHead", true);
            }
        }
    }
}

