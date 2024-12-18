using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private  protected float speedMove = 10f; 
    [SerializeField] private protected Rigidbody rigidbody;
    

    protected virtual void Start()
    {
        Move();
    }

    // Метод для движения пули
    protected virtual void Move()
    {
        rigidbody.velocity = transform.forward * speedMove;
    }

    // Метод для обработки столкновений
    protected virtual void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}