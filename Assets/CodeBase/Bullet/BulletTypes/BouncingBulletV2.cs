using System.Collections.Generic;
using CodeBase.Enemy;
using UnityEngine;

namespace CodeBase.Bullet.BulletTypes
{
    public class BouncingBulletV2 : Bullet
    {
        [SerializeField] private int maxBounces = 3; 
        [SerializeField] private float bounceForce = 10f;

        private int _bouncesLeft;
        private Transform _currentTarget;

        private void Awake() => _bouncesLeft = maxBounces;

        protected override void OnCollisionEnter(Collision collision)
        {
            if (CheckBounces()) return;
            if (collision.gameObject.GetComponent<EnemyHealth>() != null)
            {
                
                var enemies = FindObjectsOfType<EnemyHealth>();
                
                Transform nextTarget = GetRandomEnemy(enemies, collision.transform);

                if (nextTarget != null)
                {
                    _currentTarget = nextTarget;
                    
                    Vector3 direction = ((_currentTarget.position + new Vector3(0,3,0)) - transform.position).normalized;
                    
                    rigidbody.velocity = Vector3.zero; 
                    rigidbody.velocity = direction * bounceForce;
                    
                }
            }
        }

        private bool CheckBounces()
        {
            _bouncesLeft--;
            if (_bouncesLeft < 0)
            {
                Destroy(gameObject);
                return true;
            }

            return false;
        }

        private Transform GetRandomEnemy(EnemyHealth[] enemies, Transform excludeTarget)
        {
            if (enemies == null || enemies.Length == 0)
            {
                return null; 
            }

            int randomIndex = Random.Range(0, enemies.Length);
            Transform selectedEnemy = enemies[randomIndex].transform;

            if (selectedEnemy != excludeTarget)
            {
                return selectedEnemy;
            }
            else
            {
                List<EnemyHealth> remainingEnemies = new List<EnemyHealth>(enemies);
                remainingEnemies.RemoveAt(randomIndex);
                return GetRandomEnemy(remainingEnemies.ToArray(), excludeTarget);
            }
        }
    }
}
