using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class CustomPool :MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private int _countBullet;

    private List<Bullet> _bullets = new List<Bullet>();

    private void Awake()
    {
        StartCoroutine(InitBullet(_countBullet));
    }

    public IEnumerator InitBullet(int count)
    {
        while(count > 0)
        {
            Bullet objectBullet = Instantiate(_bullet);
            objectBullet.gameObject.SetActive(false);
            _bullets.Add(objectBullet);
            count--;
            yield return null;
        }
    }

    public Bullet Get(Transform point)
    {
        Bullet bullet = _bullets.FirstOrDefault(b => !b.isActiveAndEnabled);

        if(bullet == null)
            return null;
        bullet.transform.position = point.position;
        bullet.gameObject.SetActive(true);
        return bullet;
    }
}
