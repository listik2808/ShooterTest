using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponAKM : MonoBehaviour, Weapon
{
    [SerializeField] private Camera _camera;
    [SerializeField] private CustomPool _customPool;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _distance;

    private Bullet _bullet;

    private void Update()
    {
        if (UnityEngine.Input.GetMouseButtonDown(0))
        {
            Shot();
        }
    }

    private void Shot()
    {
        Ray ray = new Ray(_camera.transform.position, transform.forward);
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(_camera.transform.position, _spawnPoint.forward, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(100);

        Vector3 direction = targetPoint - _spawnPoint.position;
        _bullet = _customPool.Get(_spawnPoint);
        if (_bullet != null)
        {
            _bullet.transform.forward = direction.normalized;
            _bullet.SetTarget(direction);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        var ray = new Ray(_spawnPoint.position, transform.forward);

        if (Physics.Raycast(ray, out var hitInfo, _distance))
        {
            DrawRay(ray, hitInfo.point, hitInfo.distance, Color.red);
        }
        else
        {
            var hitPosition = ray.origin + ray.direction * _distance;
            DrawRay(ray, hitPosition, _distance, Color.green);
        }
    }

    private void DrawRay(Ray ray, Vector3 hitPosition, float distance, Color color)
    {
        const float hitPositionRadius = 0.15f;

        Debug.DrawRay(ray.origin, ray.direction * distance, color);
        Gizmos.color = color;
        Gizmos.DrawSphere(hitPosition, hitPositionRadius);
    }
#endif
}
