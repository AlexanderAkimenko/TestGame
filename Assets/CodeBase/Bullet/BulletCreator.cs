using UnityEngine;

public class BulletCreator : MonoBehaviour
{
    [SerializeField] private GameObject standartBulletPrefab; 
    [SerializeField] private GameObject explosiveBulletPrefab; 
    [SerializeField] private GameObject bouncingBulletPrefab; 

    public void CreateBullet(BulletType bulletType, Vector3 position, Quaternion rotation)
    {
        GameObject bulletPrefab = null;

        // Выбираем префаб в зависимости от типа пули
        switch (bulletType)
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
            Debug.LogWarning($"Префаб для пули типа {bulletType} не найден!");
        }
    }
}