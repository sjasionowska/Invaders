using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private BulletPool _bulletPool;

    [SerializeField]
    private int _damage;

    private void Start()
    {
        _bulletPool = (BulletPool)FindObjectOfType(typeof(BulletPool));
        if (_bulletPool == null) Debug.LogError("Could not find an object of type BulletPool.");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        var bulletGameObject = _bulletPool.transform.GetChild(0).gameObject;
        bulletGameObject.transform.localPosition = this.transform.position;
        bulletGameObject.SetActive(true);
        bulletGameObject.GetComponent<Bullet>()._Damage = _damage;
    }

  

}
