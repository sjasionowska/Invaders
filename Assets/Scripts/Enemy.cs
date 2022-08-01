using System;
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



}

