using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int shootingDamage;

    [SerializeField]
    private float shootingFrequency;

    [SerializeField]
    private float reloadTime;

    private void Start()
    {
        
    }

}

