using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDirection : MonoBehaviour
{
    private float _speed = 5;

    public void ProcessMoveTo(Vector3 direction)
    {
        Vector3 normalizedDirection = direction.normalized;
        normalizedDirection.y = 0f;
        transform.Translate(normalizedDirection * _speed * Time.deltaTime);
    }
}
