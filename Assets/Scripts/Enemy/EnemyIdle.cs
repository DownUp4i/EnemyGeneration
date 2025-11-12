using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : MonoBehaviour
{
    private Enemy _enemy;
    private EnemyOptions _enemyOptions;
    private EnemyDirection _enemyDirection;

    private Queue<Vector3> _targetsQueue = new Queue<Vector3>();
    private Vector3 _currentTarget;

    Vector3 randomPosition;

    private bool _isPatrolArrayDone = false;

    private float _minDistanceToChangeTarget = 0.6f;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _enemyDirection = GetComponent<EnemyDirection>();

        _enemyOptions = _enemy.GetOptions;

        SwitchRandomPosition();
    }

    public void Idle() { }

    public void ChangePositionPerSecond()
    {

        Vector3 direction = randomPosition - _enemy.transform.position;

        if (direction.magnitude <= _minDistanceToChangeTarget)
        {
            SwitchRandomPosition();
        }

        _enemyDirection.ProcessMoveTo(direction);
    }

    private void SwitchRandomPosition()
    {
        int randomVectorX = Random.Range(-20, 20);
        int randomVectorZ = Random.Range(-20, 20);
        randomPosition = new Vector3(randomVectorX, 0, randomVectorZ);
    }

    public void Patrol(List<Transform> patrolTargets)
    {
        if (_isPatrolArrayDone == false)
        {
            foreach (Transform patrolTarget in patrolTargets)
            {
                _targetsQueue.Enqueue(patrolTarget.position);
            }
        }

        _isPatrolArrayDone = true;

        Vector3 patrolDirection = _currentTarget - _enemy.transform.position;

        if (patrolDirection.magnitude <= _minDistanceToChangeTarget)
            SwitchPatrolTarget();

        _enemyDirection.ProcessMoveTo(patrolDirection);
    }

    private void SwitchPatrolTarget()
    {
        _currentTarget = _targetsQueue.Dequeue();
        _targetsQueue.Enqueue(_currentTarget);
    }
}
