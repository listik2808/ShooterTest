using UnityEngine;

namespace Input
{
    public abstract class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";
        protected const string MouseX = "Mouse X";
        protected const string MouseY = "Mouse Y";
        public abstract Vector2 Axis { get; }
        public abstract Vector2 AxisMouse { get; }

        protected static Vector2 SimpleInputAxis() => 
            new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
    }
}