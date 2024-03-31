using UnityEngine;

namespace ItsaMeKen
{
    public class Bomb : MonoBehaviour
    {
        public float explosionForce = 1000f;
        public float explosionRadius = 10f;
        public float fuseDuration = 3f;
        public GameObject explosionEffect;

        public Animator _anim;

        private bool hasExploded = false;

        void OnCollisionEnter(Collision collision)
        {
            if (hasExploded || !collision.gameObject.CompareTag("Player"))
                return;

            _anim.SetBool("Fuse_lit", true);
            StartFuse();

        }

        void StartFuse()
        {
            Invoke("Explode", fuseDuration);
        }

        void Explode()
        {
            if (hasExploded)
                return;

            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                }
            }

            if (explosionEffect != null)
            {
                Instantiate(explosionEffect, transform.position, Quaternion.identity);
            }

            

            Destroy(gameObject);

            hasExploded = true;
        }
    }

}