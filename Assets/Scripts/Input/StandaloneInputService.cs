using UnityEngine;

namespace Input
{
    public class StandaloneInputService : InputService
    {
        public override Vector2 Axis
        {
            get
            {
                Vector2 axis = SimpleInputAxis();
                if (axis == Vector2.zero)
                {
                    axis = UnityAxis();
                }
                return axis;
            }
        }

        public override Vector2 AxisMouse 
        { 
            get
            {
                Vector2 axisMouse = Vector2.zero;
                if(axisMouse == Vector2.zero)
                {
                    axisMouse = UnityAxisMouse();
                }
                return axisMouse;
            }
        }

        private static Vector2 UnityAxisMouse() =>
            new Vector2(UnityEngine.Input.GetAxis(MouseX), UnityEngine.Input.GetAxis(MouseY));

        private static Vector2 UnityAxis() => 
            new Vector2(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));
    }
}