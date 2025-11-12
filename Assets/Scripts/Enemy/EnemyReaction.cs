using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class EnemyReaction : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathEffect;
    [SerializeField] private TriggerZone _triggerZone;

    private Enemy _enemy;
    private EnemyOptions _enemyOptions;
    private EnemyDirection _enemyDirection;

    private bool _isDead = false;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _enemyDirection = GetComponent<EnemyDirection>();
    }

    private void Start()
    {
        _enemyOptions = _enemy.GetOptions;
    }

    public void Aggro()
    {
        Vector3 direction = _enemyOptions.Target.position - transform.position;
        _enemyDirection.ProcessMoveTo(direction);
    }
    public void Escape()
    {
        Vector3 direction = transform.position - _enemyOptions.Target.position;
        _enemyDirection.ProcessMoveTo(direction);
    }
    public void Death()
    {
        if (_isDead == false)
        {
            ParticleSystem deathEffect = Instantiate(_deathEffect, _enemy.transform.position, Quaternion.identity);
            deathEffect.Play();
            Destroy(_enemy.gameObject);
            _isDead = true;
        }
    }
}
