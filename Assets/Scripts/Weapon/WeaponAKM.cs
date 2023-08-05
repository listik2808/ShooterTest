using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponAKM : MonoBehaviour,Weapon
{
    [SerializeField] private Camera _camera;
    [SerializeField] private CustomPool _customPool;
    [SerializeField] private Transform _spawnPoint;

    private Bullet _bullet;

    private void Update()
    {
        if(UnityEngine.Input.GetMouseButtonDown(0))
        {
            Shot();
        }
    }

    private void Shot()
    {
        Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Debug.DrawRay(transform.position,transform.forward,Color.red);

        Vector3 targetPoint;
        if(Physics.Raycast(ray,out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(100);
            
        Vector3 direction = targetPoint - _spawnPoint.position;
        _bullet = _customPool.Get(_spawnPoint);
        if(_bullet!= null)
        {
            _bullet.transform.forward = direction.normalized;
            _bullet.SetTarget(direction);
        }
    }
}
