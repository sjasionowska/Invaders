using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField]
    private int _initialCount;

    [SerializeField]
    private GameObject _bulletPrefab;

    private int _currentCount;

    void Start()
    {
        CreatePool();
    }

    private void CreatePool()
    {
        for (int i = 0; i < _initialCount; i++) InstantiateBullet(_bulletPrefab);
    }

    private void InstantiateBullet(GameObject bulletPrefab)
    {
        var enemy = Instantiate(bulletPrefab, Vector2.zero, Quaternion.identity);
        enemy.SetActive(false);
        enemy.transform.parent = transform;
        enemy.transform.localPosition = Vector2.zero;
        _currentCount++;
    }
}
