using CodeBase.Bullet;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class BulletSelector : MonoBehaviour
    {
        [SerializeField]  private Button standardBulletButton;
        [SerializeField]  private Button explosiveBulletButton;
        [SerializeField]  private Button bouncingBulletButton;
        [SerializeField] private  BulletCreator bulletCreator;

        private Button _selectedButton;
        
        private void Start()
        {
            _selectedButton = standardBulletButton;
            standardBulletButton.onClick.AddListener(() => SelectBullet(BulletType.Standart,standardBulletButton));
            explosiveBulletButton.onClick.AddListener(() => SelectBullet(BulletType.Explosive,explosiveBulletButton));
            bouncingBulletButton.onClick.AddListener(() => SelectBullet(BulletType.Bouncing,bouncingBulletButton));
        }

        private void SelectBullet(BulletType bulletType, Button button)
        {
            bulletCreator.ActiveBulletType = bulletType;
            if (_selectedButton != button)
            {
                SetButtonCollor( button);
            }
            
        }

        private void SetButtonCollor(Button button)
        {
            if (_selectedButton != null)
            {
                _selectedButton.image.color = new Color(255,255,255,255);
            }
            button.image.color = new Color(255,0,0,255);
            _selectedButton = button;
        }
    }
}