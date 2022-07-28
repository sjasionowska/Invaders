using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _velocity;

    private Vector2 _movement = new(0, 1);

    private int _damage = 1;

    private Rigidbody2D _rigidbody;

    private float _shootingFrequency = 0.1f;

    public float ShootingFrequency
    {
        get => _shootingFrequency;
        set
        {
            if (value == ShootingFrequency)
            {
                return;
            }
            else if (value < 0.01f)
            {
                Debug.LogError("Shooting frequency of a bullet can't be lower than 0.01.");
                return;
            }
            else if (value > 1000f)
            {
                Debug.LogError("Shooting frequency of a bullet can't be bigger than 1000.");
                return;
            }

            _shootingFrequency = value;
        }
    }

    public int _Damage
    {
        get => _damage;
        set
        {
            if (value == _Damage)
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

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Shoot()
    {
        StartCoroutine(nameof(ShootWithFrequency));
    }

    private IEnumerator ShootWithFrequency()
    {
        for (; ; )
        {
            _rigidbody.MovePosition(_rigidbody.position + _movement * (_velocity * Time.fixedDeltaTime));
            Debug.Log("_velocity " + _velocity);
            Debug.Log("seconds " + 1 / ShootingFrequency);
            yield return new WaitForSeconds(1/ShootingFrequency);
        }
    }
}


