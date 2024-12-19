using UnityEngine;

namespace CodeBase.Bullet.BulletTypes
{
    public class BouncingBullet : Bullet
    {
        [SerializeField] private int maxBounces = 3; 
        [SerializeField] private float bounceForce = 10f; 
    
        private int _bouncesLeft;

        private void Awake() => _bouncesLeft = maxBounces;

        protected override void OnCollisionEnter(Collision collision)
        {
        
            if (_bouncesLeft <= 0)
            {
                Destroy(gameObject);
                return;
            }
        
            Vector3 normal = collision.contacts[0].normal;
            Vector3 newDirection = Vector3.Reflect(rigidbody.velocity.normalized, normal);
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(newDirection * bounceForce, ForceMode.Impulse);
        
            _bouncesLeft--;
        
        }
    }
}