using Scripts.HealthBar;
using UnityEngine;

public class EnemyTriggerDamage : MonoBehaviour
{
    [SerializeField] private int _damage;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out HeroHealth heroHealth))
        {
            heroHealth.TakeDamage(_damage);
        }
    }
}
