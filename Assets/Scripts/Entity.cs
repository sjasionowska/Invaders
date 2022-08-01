using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Entity : MonoBehaviour
{
    [SerializeField]
    private int _initialLifesCount;

    private int _currentLifesCount;

    private bool _isEnemy;

    private bool _isPlayer;

    public event Action<int> LivesCountUpdated;

    private EnemiesManager _enemiesManager;

    private void Awake()
    {
        LivesCountUpdated += OnLivesCountUpdated;
    }

    private void OnDestroy()
    {
        LivesCountUpdated -= OnLivesCountUpdated;
    }

    private void Start()
    {
        _isEnemy = this.gameObject.CompareTag("Enemy");
        if (!_isEnemy) _isPlayer = this.gameObject.CompareTag("Player");

        if (!_isEnemy && !_isPlayer)
        {
            Debug.LogError("Entity has to be attached to an Enemy or a Player.");
        }

        _currentLifesCount = _initialLifesCount;

        if (!_isEnemy) return;

        _enemiesManager = GetComponentInParent<EnemiesManager>();
        if (_enemiesManager == null) Debug.LogError("Enemy couldn't find EnemiesManager in its parents.");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var bullet = collision.gameObject.GetComponent<Bullet>();

        if (bullet == null) return;

        if ((bullet.ShotByPlayer && _isEnemy) || (bullet.ShotByEnemy && _isPlayer))
        {
            _currentLifesCount -= bullet.Damage;
            LivesCountUpdated?.Invoke(_currentLifesCount);
            Debug.Log("[debug] Current lives count: " + this.gameObject + ": " + _currentLifesCount);
        }
    }

    private void OnLivesCountUpdated(int currentLifesCount)
    {
        if (currentLifesCount <= 0) Die();
    }

    private void Die()
    {
        if (_isEnemy) _enemiesManager.OnChildDied();
        Destroy(this.gameObject);
    }
}
