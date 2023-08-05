using Scripts.HealthBar;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    [SerializeField] private int _hp;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out HeroHealth heroHealth))
        {
            heroHealth.UpHealth(_hp);
        }
    }
}
