using UnityEngine;

public class EscapeReaction : IEnemyBehaviour 
{
    private Transform _targetTransform;
    private Transform _reactorTransform;
    private MovementDirection _direction;

    public EscapeReaction(Transform targetTransform, Transform reactorTransform, MovementDirection direction)
    {
        _targetTransform = targetTransform;
        _reactorTransform = reactorTransform;
        _direction = direction;
    }

    public void Execute()
    {
        Vector3 directionFrom = _reactorTransform.position - _targetTransform.position;
        _direction.ProcessMoveTo(_reactorTransform, directionFrom);
    }
}
