using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] TriggerZone _triggerZone;

    private IEnemyBehaviour _idleBehaviour;
    private IEnemyBehaviour _reactionBehaviour;

    private EnemySpawner _spawner;

    public void Initialize(EnemySpawner spawner, IEnemyBehaviour idleBehaviour, IEnemyBehaviour reactionBehaviour)
    {
        _spawner = spawner;
        _idleBehaviour = idleBehaviour;
        _reactionBehaviour = reactionBehaviour;
    }   

    private void Update()
    {
        if (_triggerZone.IsSafeZone == true)
            _idleBehaviour.Execute();
        else
            _reactionBehaviour.Execute();
    }
}
