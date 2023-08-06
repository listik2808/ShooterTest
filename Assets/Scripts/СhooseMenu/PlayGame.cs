using UnityEngine;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    [SerializeField] private Menu _menu;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(_menu.Close);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(_menu.Close);
    }
}
