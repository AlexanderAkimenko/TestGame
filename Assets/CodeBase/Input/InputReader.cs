using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CodeBase.Input
{
    public readonly struct InputReader
    {
        private readonly InputActionReference _inputAction;

        public InputReader(InputActionReference inputAction) => 
            _inputAction = inputAction ?? throw new ArgumentNullException(nameof(inputAction));

       
        public Vector2 LookDelta => _inputAction.action.ReadValue<Vector2>();

        
        public bool IsTriggered => _inputAction.action.triggered;
      
    }
}