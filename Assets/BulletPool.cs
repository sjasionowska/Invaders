using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    [SerializeField]
    private int _initialCount;

    [SerializeField]
    private GameObject _bulletPrefab;

    private int _currentCount;

    private List<GameObject> pool = new List<GameObject>();

    public int CurrentCount
    {
        get { return _currentCount; }
    }

    void Start()
    {
        CreatePool();
    }
    private void OnDestroy()
    {
        pool.Clear();
    }

    public GameObject GetObject()
    {
        var bullet = pool.FirstOrDefault(a => !a.activeSelf);

        if (bullet == null)
            bullet = CreateBullet(_bulletPrefab);

        bullet.SetActive(true);
        return bullet;
    }

    private void CreatePool()
    {
        for (int i = 0; i < _initialCount; i++)
        {
            var bullet = CreateBullet(_bulletPrefab);

        }
    }

    private GameObject CreateBullet(GameObject bulletPrefab)
    {
        var bullet = Instantiate(bulletPrefab, Vector2.zero, Quaternion.identity);
        bullet.SetActive(false);
        bullet.transform.parent = transform;
        bullet.transform.localPosition = Vector2.zero;
        _currentCount++;
        pool.Add(bullet);
        return bullet;
    }
}
