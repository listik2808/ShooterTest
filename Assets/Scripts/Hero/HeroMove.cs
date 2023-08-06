using Input;
using UnityEngine;

namespace Scripts.Hero
{
    public class HeroMove : MonoBehaviour
    {
        public CharacterController CharacterController;
        public float MovementSpeed = 4.0f;
        private IInputService _inputService;
        private Camera _camera;
        private Vector3 _direction;

        private void Awake()
        {
            _inputService = Game.InputService;
        }

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            _direction = Vector3.zero;

            if (_inputService.Axis.sqrMagnitude > 0.003f)
            {
                _direction = new Vector3(_inputService.Axis.x, 0f, _inputService.Axis.y);
                _direction = transform.TransformDirection(_direction);
                _direction.y = 0f;
            }

            _direction += Physics.gravity;

            CharacterController.Move(MovementSpeed * _direction * Time.deltaTime);
        }
    }
}