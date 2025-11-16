using UnityEngine;

public class AggroReaction : IEnemyBehaviour
{
    private Transform _targetTransform;
    private Transform _reactorTransform;
    private MovementDirection _direction;

    public AggroReaction (Transform targetTransform, Transform reactorTransform, MovementDirection direction)
    {
        _targetTransform = targetTransform;
        _reactorTransform = reactorTransform;
        _direction = direction;
    }

    public void Execute ()
    {
        Vector3 direction = _targetTransform.position - _reactorTransform.position;
        _direction.ProcessMoveTo(_reactorTransform, direction);
    }
}
