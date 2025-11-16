using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePositionBehaviour : IEnemyBehaviour
{
    private Transform _targetTransform;
    private Transform _reactorTransform;
    private MovementDirection _direction;

    private Vector3 _randomPosition;
    private float _minDistanceToChangeTarget = 0.6f;

    public ChangePositionBehaviour(Transform reactorTransform, MovementDirection direction)
    {
        _reactorTransform = reactorTransform;
        _direction = direction;
    }

    public void Execute()
    {
        Vector3 direction = _randomPosition - _reactorTransform.position;

        if (direction.magnitude <= _minDistanceToChangeTarget)
        {
            SwitchRandomPosition();
        }

        _direction.ProcessMoveTo(_reactorTransform, direction);
    }

    private void SwitchRandomPosition()
    {
        int randomVectorX = Random.Range(-20, 20);
        int randomVectorZ = Random.Range(-20, 20);
        _randomPosition = new Vector3(randomVectorX, 0, randomVectorZ);
    }
}
