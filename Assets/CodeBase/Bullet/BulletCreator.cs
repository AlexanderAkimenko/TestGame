using UnityEngine;

namespace CodeBase.Bullet
{
    public class BulletCreator : MonoBehaviour
    {
        [SerializeField] private GameObject standartBulletPrefab; 
        [SerializeField] private GameObject explosiveBulletPrefab; 
        [SerializeField] private GameObject bouncingBulletPrefab;

        public BulletType ActiveBulletType;
        public void CreateBullet(Vector3 position, Quaternion rotation)
        {
            GameObject bulletPrefab = null;
            
            switch (ActiveBulletType)
            {
                case BulletType.Standart:
                    bulletPrefab = standartBulletPrefab;
                    break;
                case BulletType.Explosive:
                    bulletPrefab = explosiveBulletPrefab;
                    break;
                case BulletType.Bouncing:
                    bulletPrefab = bouncingBulletPrefab;
                    break;
            }

            if (bulletPrefab != null)
            {
                Instantiate(bulletPrefab, position, rotation);
            }
            else
            {
                Debug.LogWarning($"Префаб для пули типа {ActiveBulletType} не найден!");
            }
        }
    }
}