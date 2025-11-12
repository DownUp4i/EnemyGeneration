using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOptions : MonoBehaviour
{
    [SerializeField] private float _speedMovement;
    public float SpeedMovement => _speedMovement;

    [SerializeField] private List<Transform> _patrolTargets;
    public List<Transform> PatrolTargets => _patrolTargets;


    [SerializeField] private Transform _target;
    public Transform Target => _target;
}
