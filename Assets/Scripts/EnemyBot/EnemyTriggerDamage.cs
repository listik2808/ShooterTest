using Scripts.HealthBar;
using UnityEngine;

public class EnemyTriggerDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out HeroHealth heroHealth))
        {
            heroHealth.TakeDamage(1);
        }
    }
}
