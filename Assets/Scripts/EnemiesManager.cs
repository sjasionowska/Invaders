using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public event Action AllEnemiesDied;

    [SerializeField]
    [Range(1, 9)]
    private int _enemiesHorizontalCount;

    [SerializeField]
    [Range(1, 3)]
    private int _enemiesVerticalCount;

    private int _initialXEnemyPosition = -9;

    private int _initialYEnemyPosition = 7;

    [SerializeField]
    private GameObject _blueEnemy;

    [SerializeField]
    private GameObject _greenEnemy;

    [SerializeField]
    private GameObject _redEnemy;

    private int _enemiesCount;

    private void Start()
    {
        InstantiateEnemies();
    }

    private void InstantiateEnemies()
    {
        for (int i = 0; i < _enemiesHorizontalCount; i++)
        {
            for (int j = 0; j < _enemiesVerticalCount; j++)
            {
                int prefabNo = UnityEngine.Random.Range(0, 3);

                switch (prefabNo)
                {
                    case 0:
                        {
                            InstantiateEnemy(
                                _initialXEnemyPosition + i * 2,
                                _initialYEnemyPosition - 2 * j,
                                _blueEnemy);
                            break;
                        }

                    case 1:
                        {
                            InstantiateEnemy(
                                _initialXEnemyPosition + i * 2,
                                _initialYEnemyPosition - 2 * j,
                                _greenEnemy);
                            break;
                        }

                    case 2:
                        {
                            InstantiateEnemy(
                                _initialXEnemyPosition + i * 2,
                                _initialYEnemyPosition - 2 * j,
                                _redEnemy);
                            break;
                        }
                }
            }
        }

        // old way of counting enemies position
        //for (int x = -12; x <= 12; x += 2)
        //{
        //    for (int y = 7; y >= 3; y -= 2)
        //    {
        //        int prefabNo = Random.Range(0, 3);

        //        switch (prefabNo)
        //        {
        //            case 0:
        //                {
        //                    InstantiateEnemy(x, y, _blueEnemy);
        //                    break;
        //                }

        //            case 1:
        //                {
        //                    InstantiateEnemy(x, y, _greenEnemy);
        //                    break;
        //                }

        //            case 2:
        //                {
        //                    InstantiateEnemy(x, y, _redEnemy);
        //                    break;
        //                }
        //        }
        //    }
        //}
    }

    private void InstantiateEnemy(int x, int y, GameObject enemyPrefab)
    {
        var enemy = Instantiate(enemyPrefab, Vector2.zero, Quaternion.identity);
        enemy.transform.parent = transform;
        enemy.transform.localPosition = new Vector2(x, y);
        _enemiesCount++;
    }

    public void OnChildDied()
    {
        _enemiesCount--;
        if (_enemiesCount == 0)
            AllEnemiesDied?.Invoke();
    }
}
