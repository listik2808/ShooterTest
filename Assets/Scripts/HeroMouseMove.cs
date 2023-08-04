using Input;
using Scripts;
using UnityEngine;

public class HeroMouseMove : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _hero;

    private IInputService _inputService;
    private float _xRotation;
    private float _yRotation;

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
        _xRotation += _inputService.AxisMouse.x;
        _yRotation += _inputService.AxisMouse.y;
        _yRotation = Mathf.Clamp(_yRotation,-90, 90);

       _camera.transform.rotation = Quaternion.Euler(-_yRotation, _xRotation,0f);
        _hero.transform.rotation = Quaternion.Euler(0,_xRotation,0);
    }
}
