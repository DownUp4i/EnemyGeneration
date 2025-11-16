using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : IEnemyBehaviour
{
    private Transform _reactorTransform;
    private MovementDirection _direction;

    private List<Transform> _patrolTargets;

    private Queue<Vector3> _targetsQueue = new Queue<Vector3>();
    private Vector3 _currentTarget;

    private bool _isPatrolPointsLoaded;

    private float _minDistanceToChangeTarget = 0.6f;

    public PatrolBehaviour (Transform reactorTransform, List<Transform> patrolTargets, MovementDirection direction )
    {
        _reactorTransform = reactorTransform;
        _patrolTargets = patrolTargets;
        _direction = direction;
    }

    public void Execute()
    {
        if(_isPatrolPointsLoaded == false)
        {
            foreach (Transform patrolTarget in _patrolTargets)
            {
                _targetsQueue.Enqueue(patrolTarget.position);
            }
        }

        _isPatrolPointsLoaded = true;

        Vector3 patrolDirection = _currentTarget - _reactorTransform.position;

        if (patrolDirection.magnitude <= _minDistanceToChangeTarget)
            SwitchPatrolTarget();

        _direction.ProcessMoveTo(_reactorTransform, patrolDirection);
    }

    private void SwitchPatrolTarget()
    {
        _currentTarget = _targetsQueue.Dequeue();
        _targetsQueue.Enqueue(_currentTarget);
    }
}
