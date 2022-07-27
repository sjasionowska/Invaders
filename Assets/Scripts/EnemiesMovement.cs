using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemiesMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    [SerializeField]
    private float _velocity;

    private Vector2 _movement = new(1, 0);

    private bool _movedLeft;

    private bool _movedRight;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        for (; ; )
        {
            if (!_movedLeft && !_movedRight)
            {
                _rigidbody.MovePosition(_rigidbody.position + _movement * (_velocity * Time.fixedDeltaTime));
                _movedRight = true;
            }

            else if (_movedLeft)
            {
                _rigidbody.MovePosition(_rigidbody.position + _movement * (_velocity * Time.fixedDeltaTime));
                _movedRight = true;
                _movedLeft = false;
            }

            else if (_movedRight)
            {
                _rigidbody.MovePosition(_rigidbody.position - _movement * (_velocity * Time.fixedDeltaTime));
                _movedRight = false;
                _movedLeft = true;
            }

            yield return new WaitForSeconds(1f);
        }
    }

}
