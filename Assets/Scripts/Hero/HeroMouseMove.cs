using Input;
using Scripts;
using UnityEngine;

namespace Scripts.Hero
{
    public class HeroMouseMove : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private GameObject _hero;
        [SerializeField] private float _sensivity = 5;

        private IInputService _inputService;
        private float _smoothTime = 0.1f;
        private float _xRotation;
        private float _yRotation;
        private float _currenVelocityX;
        private float _currenVelocityY;
        private float _xRotationVelocity;
        private float _yRotationVelocity;

        private void Awake()
        {
            _inputService = Game.InputService;
        }

        private void Update()
        {
            MouseMove();
        }

        private void MouseMove()
        {
            _xRotation += _inputService.AxisMouse.x * _sensivity;
            _yRotation += _inputService.AxisMouse.y * _sensivity;
            _yRotation = Mathf.Clamp(_yRotation, -90, 90);

            _xRotationVelocity = Mathf.SmoothDamp(_xRotationVelocity, _xRotation, ref _currenVelocityX, _smoothTime);
            _yRotationVelocity = Mathf.SmoothDamp(_yRotationVelocity, _yRotation, ref _currenVelocityX, _smoothTime);
            _camera.transform.rotation = Quaternion.Euler(-_yRotation, _xRotation, 0f);
            _hero.transform.rotation = Quaternion.Euler(0, _xRotation, 0);
        }
    }
}