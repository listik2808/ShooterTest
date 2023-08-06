using Input;
using UnityEngine;

namespace Scripts.Hero
{
    public class HeroMove : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float MovementSpeed = 4.0f;
        [SerializeField] private float _jump;
        [SerializeField] private float _gravity;
        private IInputService _inputService;
        private Vector3 _direction;

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

            _characterController.Move(MovementSpeed * _direction * Time.deltaTime);
        }
    }
}