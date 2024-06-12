using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : Singleton<BulletPool>
{
    [Header("BulletPrefab")]
    [SerializeField] private GameObject _bulletPrefab;

    [Header("PoolPosition")]
    [SerializeField] private Transform _poolTransform;

    [Header("BulletCount")]
    [SerializeField] private int _bulletCount;

    private Queue<GameObject> _bulletPool = new Queue<GameObject>();

    private void Start()
    {
        CreateBullet();
    }

    private void CreateBullet()
    {
        for(int i = 0; i < _bulletCount; i++)
        {
            GameObject bullet = Instantiate(_bulletPrefab, _poolTransform);
            bullet.SetActive(false);
            _bulletPool.Enqueue(bullet);
        }
    }

    public GameObject GetBullet()
    {
        GameObject bullet = _bulletPool.Dequeue();
        _bulletPool.Enqueue(bullet);
        bullet.SetActive(true);
        return bullet;
    }
}
