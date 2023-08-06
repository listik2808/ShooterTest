using UnityEngine;
using UnityEngine.UI;

namespace Scripts.HealthBar
{
    public abstract class Bar : MonoBehaviour
    {
        [SerializeField] private Slider _imageCurrent;
        public void SetValue(float current, float max) =>
            _imageCurrent.value = current / max;
    }
}