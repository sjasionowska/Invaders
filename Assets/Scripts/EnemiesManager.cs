using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyType
{
    Blue,
    Green,
    Red
}

public class EnemiesManager : MonoBehaviour
{
    [SerializeField]
    private GameObject blueEnemy;

    [SerializeField]
    private GameObject greenEnemy;

    [SerializeField]
    private GameObject redEnemy;

    private void Start()
    {
        GenerateEnemies();
    }

    private void GenerateEnemies()
    {
        for (int x = -12; x <= 12;)
        {
            for (int y = 7; y >= 3;)
            {
                int prefabNo = Random.Range(0, 3);
                switch (prefabNo)
                {
                    case 0:
                        {
                            var enemy = Instantiate(blueEnemy, new Vector3(0, 0, 0), Quaternion.identity);
                            enemy.transform.parent = transform;
                            enemy.transform.localPosition = new Vector2(x, y);
                            break;
                        }

                    case 1:
                        {
                            var enemy = Instantiate(greenEnemy, new Vector3(0, 0, 0), Quaternion.identity);
                            enemy.transform.parent = transform;
                            enemy.transform.localPosition = new Vector2(x, y);
                            break;
                        }

                    case 2:
                        {
                            var enemy = Instantiate(redEnemy, new Vector3(0, 0, 0), Quaternion.identity);
                            enemy.transform.parent = transform;
                            enemy.transform.localPosition = new Vector2(x, y);
                            break;
                        }
                }

                y -= 2;
            }

            x += 2;
        }

    }

}
