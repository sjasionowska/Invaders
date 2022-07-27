using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private BulletPool _bulletPool;

    private int _damage;

    private bool _isEnemy;

    private bool _isPlayer;

    private void Start()
    {
        _bulletPool = (BulletPool)FindObjectOfType(typeof(BulletPool));
        if (_bulletPool == null) Debug.LogError("Could not find an object of type BulletPool.");

        _isEnemy = this.gameObject.CompareTag("Enemy");
        _isPlayer = this.gameObject.CompareTag("Player");
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