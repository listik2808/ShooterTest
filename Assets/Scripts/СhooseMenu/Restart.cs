using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    [SerializeField] private Button _botton;
    [SerializeField] private Menu _menu;

    private const string Main = "Main";

    private void OnEnable()
    {
        _botton.onClick.AddListener(Load);
    }

    private void OnDisable()
    {
        _botton.onClick.RemoveListener(Load);
    }

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void Load()
    {
        SceneManager.LoadScene("Main");
    }
}
