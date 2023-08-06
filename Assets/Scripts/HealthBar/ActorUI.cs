using Scripts.Hero;
using UnityEngine;

namespace Scripts.HealthBar
{
    public class ActorUI : MonoBehaviour
    {
        [SerializeField] private HpBar _hpBar;
        [SerializeField] private HeroHealth _heroHealth;

        private void OnEnable()
        {
            _heroHealth.HealthChanged += UpdateHpBar;
        }

        private void OnDisable()
        {
            _heroHealth.HealthChanged -= UpdateHpBar;
        }

        private void UpdateHpBar()
        {
            _hpBar.SetValue(_heroHealth.Current, _heroHealth.Max);
        }
    }
}