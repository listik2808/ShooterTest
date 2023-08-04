using UnityEngine;

namespace Input
{
    public interface IInputService
    {
        Vector2 Axis { get; }
        Vector2 AxisMouse { get; }
    }
}