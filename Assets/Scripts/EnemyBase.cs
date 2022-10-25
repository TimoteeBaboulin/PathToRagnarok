using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public abstract class EnemyBase : MonoBehaviour
{
    public Transform target;
    public int healthPoint;
    public int damage;
    public float lookRadius;
    public abstract void Attack();
}
