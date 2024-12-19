using CodeBase.Input;
using UnityEngine;

namespace CodeBase.Player
{
    public class ShootEffectActivate : MonoBehaviour
    {

        [SerializeField] private GameObject shootVfx;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip shootSound;
    

        private InputReader _inputReader;


        public void CreateShootVfx(Vector3 position, Quaternion rotation)
        {
            var obj =  Instantiate(shootVfx, position, rotation);
            Destroy(obj,1.5f);
        }

        public void PlayShootSound()
        {
            audioSource.PlayOneShot(shootSound,0.5f);
        }
    }
}
