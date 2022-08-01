using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Enemy : Shooter
{
    /// <summary>
    /// Indicates how likely it is for this enemy to shoot when it is loaded.
    /// </summary>
    [SerializeField]
    [Range(0, 100)]
    private int _shootingProbability;

    private void Start()
    {
        OnStart();
        StartCoroutine(nameof(EnemyShoot));
    }

    private IEnumerator EnemyShoot()
    {
        for (; ; )
        {
            int chanceWillShoot = UnityEngine.Random.Range(0, 101);

            if (chanceWillShoot <= _shootingProbability)
            {
                Shoot();
            }

            yield return new WaitForSeconds(1f);
        }
    }
}

