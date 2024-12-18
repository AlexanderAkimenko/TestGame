using CodeBase.Input;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunCotroller : MonoBehaviour
{
    [SerializeField] private Transform gunTransform;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float fireRate = 1f;

    [SerializeField] private BulletCreator bulletCreator;
    [SerializeField] private ShootEffectActivate effectActivate;
    [SerializeField] private InputActionReference shoot;

    
    
    private InputReader _inputReader;
    private float _nextFireTime;

    private void Awake() => _inputReader = new InputReader(shoot);


    private void Update()
    {
        CheckInputFireButton();
    }

    private void CheckInputFireButton()
    {
        if (_inputReader.IsTriggered && Time.time >= _nextFireTime)
        {
            Fire();
            _nextFireTime = Time.time + 1f / fireRate; 
        }
    }

    private void Fire()
    {// отрефакторить поля метода
       bulletCreator.CreateBullet(BulletType.Explosive, shootPoint.position,shootPoint.rotation );
       effectActivate.PlayShootSound();
       effectActivate.CreateShootVfx(shootPoint.position,shootPoint.rotation);
    }
}
