using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private Vector2 _movement = new Vector2(1, 0);

    [SerializeField]
    private float _velocity;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if (_rigidbody.position.x < -15.3f)
        {
            _rigidbody.MovePosition(new Vector2(_rigidbody.position.x + 0.1f, _rigidbody.position.y));
        }
        else if (_rigidbody.position.x > 15.3f)
        {
            _rigidbody.MovePosition(new Vector2(_rigidbody.position.x - 0.1f, _rigidbody.position.y));
        }
        else
        {
            _rigidbody.MovePosition(_rigidbody.position + _movement * (_velocity * Time.fixedDeltaTime));
        }
    }


}
