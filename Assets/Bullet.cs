using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _setInactiveAfterSeconds;

    private float _velocity;

    private int _damage = 1;

    private Rigidbody2D _rigidbody;

    private bool _shotByPlayer;

    private bool _shotByEnemy;

    private bool _canMove;

    public bool ShotByEnemy
    {
        get; set;
    }

    public bool ShotByPlayer
    {
        get; set;
    }

    private Vector2 Movement
    {
        get
        {
            if (!ShotByPlayer && !ShotByEnemy)
            {
                Debug.LogError("Movement vector of a bullet can be only get for a Player or an Enemy.");
                return Vector2.zero;
            }

            if (ShotByPlayer) return new(0, 1);
            
            return new(0, -1);
        }

    }

    public int Damage
    {
        get => _damage;
        set
        {
            if (value == Damage)
            {
                return;
            }
            else if (value <= 0)
            {
                Debug.LogError("Damage of a bullet can't be lower than 1.");
                return;
            }
            else if (value > 5)
            {
                Debug.LogError("Damage of a bullet can't be bigger than 5.");
                return;
            }

            _damage = value;
        }
    }

    public float Velocity
    {
        get => _velocity;
        set
        {
            if (value < 0.1f)
            {
                Debug.LogError("Velocity of a bullet can't be lower than 0.1f.");
                return;
            }

            _velocity = value;
        }
    }

    public void Shoot()
    {
        StartCoroutine(nameof(ShootWithFrequency));
        StartCoroutine(nameof(StopMovingAfterTime));
    }

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private IEnumerator ShootWithFrequency()
    {
        if (!_canMove) yield return null;

        for (; ; )
        {
            _rigidbody.MovePosition(_rigidbody.position + Movement * _velocity * Time.fixedDeltaTime);
            yield return new WaitForSeconds(0.001f);
        }
    }

    private IEnumerator StopMovingAfterTime()
    {
        yield return new WaitForSeconds(_setInactiveAfterSeconds);

        _canMove = false;
        this.gameObject.SetActive(false);
        StopCoroutine(nameof(ShootWithFrequency));
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((ShotByPlayer && collision.CompareTag("Enemy")
            || (ShotByEnemy && collision.CompareTag("Player"))))
            this.gameObject.SetActive(false);
    }
}


