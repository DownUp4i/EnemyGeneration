using UnityEngine;

public class DeathReaction : MonoBehaviour, IEnemyBehaviour
{
    private Transform _targetTransform;
    private Transform _reactorTransform;
    private MovementDirection _direction;

    private ParticleSystem _deathEffect;
    private bool _isDead = false;

    public DeathReaction(ParticleSystem deathEffect, Transform reactorTransform)
    {
        _deathEffect = deathEffect;
        _reactorTransform = reactorTransform;
    }

    public void Execute()
    {
        if(_isDead == false)
        {
            ParticleSystem deathEffect = Instantiate(_deathEffect, _reactorTransform.position, Quaternion.identity);
            deathEffect.Play();
            Destroy(_reactorTransform.gameObject);
            _isDead = true;
        }
    }
}
