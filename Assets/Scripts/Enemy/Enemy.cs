using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] TriggerZone _triggerZone;

    private EnemySpawner _spawner;
    private EnemyOptions _options;

    private EnemyIdle _enemyIdle;
    private EnemyReaction _enemyReaction;

    private EnemyDirection _enemyMovement;

    private const float Speed = 5f;

    public void Initialize(EnemySpawner spawner, EnemyOptions enemyOptions)
    {
        _spawner = spawner;
        _options = enemyOptions;
    }

    public EnemyOptions GetOptions => _options;

    private void Awake()
    {
        _enemyMovement = GetComponent<EnemyDirection>();

        _enemyIdle = GetComponent<EnemyIdle>();
        _enemyReaction = GetComponent<EnemyReaction>();
    }

    private void Update()
    {
        if (_triggerZone.IsSafeZone == true)
        {
            switch (_spawner.GetBehaviourIdleType())
            {
                case BehaviourIdleType.ChangePositionPerSecond:
                    _enemyIdle.ChangePositionPerSecond();
                    break;

                case BehaviourIdleType.Patrol:
                    _enemyIdle.Patrol(_options.PatrolTargets);
                    break;

                case BehaviourIdleType.Idle:
                    _enemyIdle.Idle();
                    break;

                default:
                    _enemyIdle.Idle();
                    break;
            }
        }

        if (_triggerZone.IsSafeZone == false)
        {
            switch (_spawner.GetBehaviourReactionType())
            {
                case BehaviourReactionType.Aggro:
                    _enemyReaction.Aggro();
                    break;

                case BehaviourReactionType.Escape:
                    _enemyReaction.Escape();
                    break;

                case BehaviourReactionType.Death:
                    _enemyReaction.Death();
                    break;

                default:
                    _enemyReaction.Aggro();
                    break;
            }
        }
    }
}
