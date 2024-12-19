using System.Collections;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private Renderer renderer;
        [SerializeField] private Material redMaterial;
        private Material _defaultMaterial;


        private Coroutine _setDefaultColor;
        private void Start() => _defaultMaterial = renderer.material;

        private void OnCollisionEnter(Collision other)
        { 
            if(other.gameObject.GetComponent<Bullet.Bullet>()) SwitchColor();
        }

        public void SwitchColor()
        {
            renderer.material = redMaterial;
            if (_setDefaultColor == null) _setDefaultColor =  StartCoroutine(TimeToswichColor());
        
        }

        private IEnumerator TimeToswichColor()
        {
            yield return new WaitForSeconds(0.5f);
            renderer.material = _defaultMaterial;
            _setDefaultColor = null;
        }
        
    
    }
}
