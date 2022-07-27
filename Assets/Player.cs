using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Shooter
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Shoot();
        }
    }
}
