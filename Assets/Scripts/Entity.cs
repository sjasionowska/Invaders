using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Entity : MonoBehaviour
{
    [SerializeField]
    private int _initialLifesCount;

    private int _currentLifesCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("on trigger enter " + collision.gameObject);
    }
}
