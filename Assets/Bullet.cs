using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Bullet : MonoBehaviour
{
    private float _velocity;

    private Vector2 _movement = new(0, 1);

    private int _damage = 1;

    private Rigidbody2D _rigidbody;

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
    }

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private IEnumerator ShootWithFrequency()
    {
        for (; ; )
        {
            _rigidbody.MovePosition(_rigidbody.position + _movement * _velocity * Time.fixedDeltaTime);
            yield return new WaitForSeconds(0.001f);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("on trigger enter bullet with " + collision.gameObject);
    }
}


