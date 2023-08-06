using Input;
using UnityEngine;

namespace Scripts.Hero
{
    public class HeroMove : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _speedRan;
        [SerializeField] private float _walkingSpeed;
        [SerializeField] private float _jump;
        [SerializeField] private float _gravity;
        private IInputService _inputService;
        private Vector3 _direction;
        private float _movementSpeed;

        private void Awake()
        {
            _inputService = Game.InputService;
        }

        private void Update()
        {
            if (_characterController.isGrounded)
            {
                _direction = new Vector3(_inputService.Axis.x, 0f, _inputService.Axis.y);
                _direction = transform.TransformDirection(_direction);

                if (UnityEngine.Input.GetKey(KeyCode.Space))
                {
                    _direction.y += _jump; 
                }
            }
            

            _direction.y -= _gravity;

            if (UnityEngine.Input.GetKey(KeyCode.LeftShift))
            {
                _movementSpeed = _speedRan;
            }
            else
            {
                _movementSpeed = _walkingSpeed;
            }

            _characterController.Move(_movementSpeed * _direction * Time.deltaTime);
        }
    }
}