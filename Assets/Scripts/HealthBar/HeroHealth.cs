using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.HealthBar
{
    public class HeroHealth : MonoBehaviour
    {
        [SerializeField] private float _health;
        [SerializeField] private float _maxHealth;

        public float Current
        {
            get => _health;
            set
            {
                if(_health != value) 
                {
                    _health = value;
                    HealthChanged?.Invoke();
                }
            }
        }

        public float Max
        {
            get => _maxHealth;
            set => _maxHealth = value;
        }

        public Action HealthChanged;

        public void TakeDamage(int damage)
        {
            if(Current <= 0)
                return;

            Current -= damage;
        }
    }
}