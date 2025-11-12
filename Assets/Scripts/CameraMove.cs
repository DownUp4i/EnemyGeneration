using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed = 8f;

    private void LateUpdate()
    {
        Vector3 targetPosition = _player.transform.position + _offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, _speed * Time.deltaTime);
    }
}
