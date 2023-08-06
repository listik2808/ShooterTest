using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Scripts.Inventory;

public class CustomPool :MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private int _countBullet;
    [SerializeField] private Bag _bag;

    private List<Bullet> _bullets = new List<Bullet>();

    private void Awake()
    {
        StartCoroutine(InitBullet(_countBullet));
    }

    public IEnumerator InitBullet(int count)
    {
        while(count > 0)
        {
            Bullet objectBullet = Instantiate(_bullet,transform.position,Quaternion.identity);
            objectBullet.gameObject.SetActive(false);
            _bullets.Add(objectBullet);
            count--;
            yield return null;
        }
    }

    public Bullet Get(Transform point)
    {
        if (_bag.Patron > 0 || _bag.Aboema > 0)
        {
            Bullet bullet = _bullets.FirstOrDefault(b => !b.isActiveAndEnabled);

            if (bullet == null)
                return null;
            _bag.UsePatron();
            bullet.transform.position = point.position;
            bullet.gameObject.SetActive(true);
            return bullet;
        }
        return null;
    }
}
