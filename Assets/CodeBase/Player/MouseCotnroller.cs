using CodeBase.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CodeBase.Player
{
    public class MouseController : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;
        [Range(0.0f,1.0f)]
        [SerializeField] private float sensitivity = 1f; 
        [SerializeField] private InputActionReference aim;
        
        private InputReader _inputReader;
        private Vector2 _lookDelta;
        private float _xRotation = 0f;

        private void Awake()
        {
            _inputReader = new InputReader(aim);
            Cursor.lockState = CursorLockMode.Locked; 
            //Cursor.visible = false; 
        }

    

        private void Update()
        {
            UpdateLookRotation();
        }

        private void UpdateLookRotation()
        {
            _lookDelta = _inputReader.LookDelta;
             
            transform.Rotate(Vector3.up, _lookDelta.x * sensitivity);

            
            _xRotation -= _lookDelta.y * sensitivity;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f); 

            cameraTransform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        }
    }
}