using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private void Start()
    {
        MouseDeactivate();
    }

    public void MouseActivate()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void MouseDeactivate() 
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
