using UnityEngine;

public class ExplosiveBullet : Bullet
{
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private float explosionForce = 1000f;
    [SerializeField] private float damage = 20f;


    protected override void OnCollisionEnter(Collision collision)
    {
  
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider hitCollider in hitColliders)
        {
           Debug.Log( hitCollider.gameObject.name);
     
           
               EnemyHealth enemy = hitCollider.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.GetComponent<Rigidbody>()?.AddExplosionForce(explosionForce,transform.position,explosionRadius);
               // enemy.TakeDamage(damage); // Наносим урон
            }
        }

      
        Destroy(gameObject);
    }

   
}