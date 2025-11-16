using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOptions : MonoBehaviour
{
    [SerializeField] private List<Transform> _patrolTargets;
    public List<Transform> PatrolTargets => _patrolTargets;


    [SerializeField] private Transform _target;
    public Transform Target => _target;


    [SerializeField] private MovementDirection _direction;
    public MovementDirection Direction => _direction;


    [SerializeField] private ParticleSystem _deathEffect;
    public ParticleSystem DeathEffect => _deathEffect;
}
