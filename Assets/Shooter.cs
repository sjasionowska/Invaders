using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    protected int shootingDamage;

    [SerializeField]
    protected float bulletVelocity;

    [SerializeField]
    protected float reloadTime;

    private BulletPool _bulletPool;

    private bool _isEnemy;

    private bool _isPlayer;

    private void Start()
    {
        _bulletPool = (BulletPool)FindObjectOfType(typeof(BulletPool));

        if (_bulletPool == null) Debug.LogError("Could not find an object of type BulletPool.");

        _isEnemy = this.gameObject.CompareTag("Enemy");
        _isPlayer = this.gameObject.CompareTag("Player");
    }

    protected void Shoot()
    {
        var bulletGameObject = _bulletPool.transform.GetChild(0).gameObject;
        bulletGameObject.transform.position = Vector2.zero;
        bulletGameObject.transform.localPosition = this.transform.position;
        bulletGameObject.SetActive(true);
        bulletGameObject.GetComponent<Bullet>().Damage = shootingDamage;
        bulletGameObject.GetComponent<Bullet>().Velocity = bulletVelocity;

        if (_isEnemy) bulletGameObject.GetComponent<Bullet>().ShotByEnemy = true;
        else if (_isPlayer) bulletGameObject.GetComponent<Bullet>().ShotByPlayer = true;
        else
        {
            Debug.LogError("Bullet can be shot only by a player or an enemy.");
            return;
        }

        bulletGameObject.GetComponent<Bullet>().Shoot();

    }
}
