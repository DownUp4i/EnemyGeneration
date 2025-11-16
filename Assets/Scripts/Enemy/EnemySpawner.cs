using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    [SerializeField] private BehaviourIdleType _behaviourIdleType;
    [SerializeField] private BehaviourReactionType _behaviourReactionType;

    private Enemy _enemy;

    private IEnemyBehaviour _behaviourIdle;
    private IEnemyBehaviour _behaviourReaction;

    private EnemyOptions _enemyOptions;

    private void Awake()
    {
        _enemyOptions = GetComponent<EnemyOptions>();

        _enemy = Instantiate(_enemyPrefab, this.transform);

        IEnemyBehaviour idleBehaviour = CreateIdleBehaviour(_behaviourIdleType);
        IEnemyBehaviour reactionBehaviour = CreateReactionBehaviour(_behaviourReactionType, _enemy);

        _enemy.Initialize(this, idleBehaviour, reactionBehaviour);
    }

    private IEnemyBehaviour CreateIdleBehaviour(BehaviourIdleType idleType)
    {
        switch (idleType)
        {
            case BehaviourIdleType.Idle:
                return new IdleBehaviour();

            case BehaviourIdleType.Patrol:
                return new PatrolBehaviour(_enemy.transform, _enemyOptions.PatrolTargets, _enemyOptions.Direction);

            case BehaviourIdleType.ChangePositionPerSecond:
                return new ChangePositionBehaviour(_enemy.transform, _enemyOptions.Direction);

            default:
                throw new System.ArgumentOutOfRangeException(nameof(idleType), idleType, "Idle Type doesn't support");
        }
    }

    private IEnemyBehaviour CreateReactionBehaviour(BehaviourReactionType idleType, Enemy enemy)
    {
        switch (idleType)
        {
            case BehaviourReactionType.Aggro:
                return new AggroReaction(_enemyOptions.Target, enemy.transform, _enemyOptions.Direction);

            case BehaviourReactionType.Escape:
                return new EscapeReaction(_enemyOptions.Target, enemy.transform, _enemyOptions.Direction);

            case BehaviourReactionType.Death:
                return new DeathReaction(_enemyOptions.DeathEffect, enemy.transform);

            default:
                throw new System.ArgumentOutOfRangeException(nameof(idleType), idleType, "Idle Type doesn't support");
        }
    }
}
