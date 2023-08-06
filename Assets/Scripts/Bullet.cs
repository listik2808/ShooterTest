using Assets.Scripts.EnemyBot;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _target;

    private void Update()
    {
        transform.position += _target * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Enemy enemy))
        {
            enemy.Damage();
            gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }

    public void SetTarget(Vector3 target)
    {
        _target = target;
    }
}
