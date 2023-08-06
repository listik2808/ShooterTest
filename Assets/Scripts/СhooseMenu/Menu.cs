using Scripts.HealthBar;
using Scripts.Hero;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Canvas _canvasAim;
    [SerializeField] private Canvas _menu;
    [SerializeField] private HeroMouseMove _heroMouse;

    private bool _gameISPaused = false;

    private void Awake()
    {
        _menu.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
        {
            if (_gameISPaused)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
    }

    private void Open()
    {
        _menu.gameObject.SetActive(true);
        _heroMouse.enabled= false;
        _canvasAim.gameObject.SetActive(false);
        Time.timeScale = 0;
        _gameISPaused = true;
    }

    public void Close()
    {
        _heroMouse.enabled = true;
        _canvasAim.gameObject.SetActive(true);
        Time.timeScale = 1;
        _gameISPaused = false;
        _menu.gameObject.SetActive(false);
    }
}
