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
    [Range(0f, 2f)]
    protected float _reloadTime;

    private BulletPool _bulletPool;

    private bool _isEnemy;

    private bool _isPlayer;

    private bool _loaded;

    private Color _defaultColor;

    private void Start()
    {
        _bulletPool = (BulletPool)FindObjectOfType(typeof(BulletPool));

        if (_bulletPool == null) Debug.LogError("Could not find an object of type BulletPool.");

        _isEnemy = this.gameObject.CompareTag("Enemy");
        _isPlayer = this.gameObject.CompareTag("Player");

        _loaded = true;

        _defaultColor = this.gameObject.GetComponent<SpriteRenderer>().color;
    }

    protected void Shoot()
    {
        if (!_loaded) return;

        var bulletGameObject = _bulletPool.GetObject();
        bulletGameObject.transform.position = Vector2.zero;
        bulletGameObject.transform.localPosition = this.transform.position;
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

        _loaded = false;
        SetUnloadedColor();

        StartCoroutine(nameof(Load));
    }

    private void SetUnloadedColor()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(_defaultColor.r, _defaultColor.b, _defaultColor.g, 0.5f);
    }

    private void SetLoadedColor()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(_defaultColor.r, _defaultColor.b, _defaultColor.g, _defaultColor.a);
    }

    private IEnumerator Load()
    {
        if(_loaded) yield return null;

        yield return new WaitForSeconds(_reloadTime);

        _loaded = true;
        SetLoadedColor();
    }
}
