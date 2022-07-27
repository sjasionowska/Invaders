using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int _damage = 1;

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

    public void Shoot()
    {

    }
}
