using CodeBase.Enemy;
using UnityEngine;

namespace CodeBase.Bullet.BulletTypes
{
    public class ExplosiveBullet : Bullet
    {
        [SerializeField] private float explosionRadius = 5f;
        [SerializeField] private float explosionForce = 1000f;
        [SerializeField] private GameObject explosionFx;

        private bool hasExploded = false;
        private Collider[] hitColliders;

        protected override void OnCollisionEnter(Collision collision)
        {
            if (hasExploded) return;

            Instantiate(explosionFx, transform.position, Quaternion.identity);
            hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);

            hasExploded = true;
        }

        private void FixedUpdate()
        { 
            Move();
            if (hasExploded)
            {
                ApplyExplosionForce();
                Destroy(gameObject);
            }
        }

        private void ApplyExplosionForce()
        {
            foreach (Collider hitCollider in hitColliders)
            {
                EnemyHealth enemy = hitCollider.GetComponent<EnemyHealth>();
                if (enemy != null)
                {
                    enemy.SwitchColor();
                    enemy.GetComponent<Rigidbody>()?.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                }
            }
        }
    }
}