using System;
using UnityEngine;

namespace Scripts.Inventory
{
    public class Bag : MonoBehaviour
    {
        [SerializeField] private int _patron;
        private int _starPatron;
        private int _aboema = 2;
        private int _maxAboema =6;
        private int _patrons;

        public int Patrons => _patrons;
        public int Aboema => _aboema;
        public int Patron => _patron;

        public Action PatronChanged;

        private void Awake()
        {
            _starPatron = _patron;
            CountPatrons();
        }
        private void Start()
        {
            PatronChanged?.Invoke();
        }

        private void Update()
        {
            if(UnityEngine.Input.GetKey(KeyCode.R))
            {
                if(_aboema > 0 && _patron != _starPatron)
                    Recharge();
                PatronChanged?.Invoke();
            }
        }

        public void UsePatron()
        {
            if (_patron > 0)
            {
                _patron--;
                if (_patron == 0 & _aboema > 0)
                {
                    Recharge();
                }
                PatronChanged?.Invoke();
            }
        }

        public void AddAboema(int aboema)
        {
            if(_aboema != _maxAboema)
            {
                SetAboema(aboema);
                if (_patron == 0)
                {
                    Recharge();
                }
                CountPatrons();
                PatronChanged?.Invoke();
            }
            
        }

        private void SetAboema(int aboema)
        {
            int count = _aboema;
            count += aboema;
            if(count >= _maxAboema)
                _aboema = _maxAboema;
            else
                _aboema += aboema;
        }

        private void CountPatrons()
        {
            _patrons = _aboema * _starPatron;
        }

        private void Recharge()
        {
            _aboema--;
            _patron = _starPatron;
            CountPatrons();
        }
    }
}