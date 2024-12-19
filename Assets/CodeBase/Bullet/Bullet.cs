using UnityEngine;

namespace CodeBase.Bullet
{
    [RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
    public abstract class Bullet : MonoBehaviour
    {
        [SerializeField] private  protected float speedMove = 10f; 
        [SerializeField] private protected Rigidbody rigidbody;
    

        protected virtual void Start() => Move();

        protected virtual void Move() => rigidbody.velocity = transform.forward * speedMove;

        protected virtual void OnCollisionEnter(Collision collision) => Destroy(gameObject);
    }
}