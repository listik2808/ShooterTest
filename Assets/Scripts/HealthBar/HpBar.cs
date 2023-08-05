using UnityEngine;
using UnityEngine.UI;

namespace Scripts.HealthBar
{
    public class HpBar : MonoBehaviour
    {
        [SerializeField] private Slider _imageCurrent;

        public void SetValue(float current, float max) => 
            _imageCurrent.value = current / max;
    }
}