using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField]
    private GameObject blueEnemy;

    [SerializeField]
    private GameObject greenEnemy;

    [SerializeField]
    private GameObject redEnemy;

    private int enemiesCount;

    private void Start()
    {
        InstantiateEnemies();
    }

    private void InstantiateEnemies()
    {
        for (int x = -12; x <= 12; x += 2)
        {
            for (int y = 7; y >= 3; y -= 2)
            {
                int prefabNo = Random.Range(0, 3);

                switch (prefabNo)
                {
                    case 0:
                        {
                            InstantiateEnemy(x, y, blueEnemy);
                            break;
                        }

                    case 1:
                        {
                            InstantiateEnemy(x, y, greenEnemy);
                            break;
                        }

                    case 2:
                        {
                            InstantiateEnemy(x, y, redEnemy);
                            break;
                        }
                }
            }
        }
    }

    private void InstantiateEnemy(int x, int y, GameObject enemyPrefab)
    {
        var enemy = Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        enemy.transform.parent = transform;
        enemy.transform.localPosition = new Vector2(x, y);
        enemiesCount++;
    }
}
