using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private float _runningSpeed = 10f;
    [SerializeField] private float _rotationSpeed = 500f;
    private float _currentSpeed;

    private float _deadZone = 0.1f;

    private CharacterController _controller;

    private const string HorizontalInput = "Horizontal";
    private const string VerticalInput = "Vertical";

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            _currentSpeed = _runningSpeed;
        else
            _currentSpeed = _movementSpeed;

        Vector3 direction = new Vector3(Input.GetAxisRaw(HorizontalInput), 0, Input.GetAxisRaw(VerticalInput));
        _controller.Move(direction.normalized * _currentSpeed * Time.deltaTime);

        if (direction.magnitude <= _deadZone)
            return;

        Quaternion lookRotation =  Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, _rotationSpeed * Time.deltaTime);
    }
}
