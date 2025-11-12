using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    [SerializeField] private BehaviourIdleType _behaviourIdleType;
    [SerializeField] private BehaviourReactionType _behaviourReactionType;

    private EnemyOptions _enemyOptions;

    private void Awake()
    {
        _enemyOptions = GetComponent<EnemyOptions>();

        Enemy enemy = Instantiate(_enemyPrefab, this.transform);
        enemy.Initialize(this, _enemyOptions);
    }

    public BehaviourIdleType GetBehaviourIdleType()
    {
        return _behaviourIdleType;
    }

    public BehaviourReactionType GetBehaviourReactionType()
    {
        return _behaviourReactionType;
    }
}
