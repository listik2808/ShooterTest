using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(ExitScene);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ExitScene);
    }

    private void ExitScene()
    {
       Application.Quit();
    }
}
