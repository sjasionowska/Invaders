using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Enemy : Shooter
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("on trigger enter enemy");
    }
}

