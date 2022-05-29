using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UUtils;

[RequireComponent(typeof(CharacterController))]
public class MovementController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private float _gravity = 25f;
    private float _verticalVelocity;

    private CharacterController _cController;
    private Camera _camera;

    private Vector3 _moveDirection;


    public Vector3 Velocity { get => _cController.velocity; }

    private void Awake()
    {
        _cController = GetComponent<CharacterController>();
        _camera = Camera.main;
    }

    private Vector3 HandleGravity(Vector3 moveVector)
    {
        float groundedGravity = -0.5f;
        if (_cController.isGrounded)
        {
            _verticalVelocity = groundedGravity;
        }
        else
        {
            _verticalVelocity -= _gravity * Time.deltaTime;
        }
        moveVector.y = _verticalVelocity;
        return moveVector;
    }

    private Vector3 AdjustToCamera(Vector3 direction)
    {
        Vector3 forward = _camera.transform.forward;
        Vector3 right = _camera.transform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        return forward * direction.z + right * direction.x;
    }

    public void Move(Vector3 direction)
    {
        _moveDirection = AdjustToCamera(direction);
        Vector3 moveVector = _moveDirection * _moveSpeed;
        moveVector = HandleGravity(moveVector);
        _cController.Move(moveVector * Time.deltaTime);
    }

    public void RotateDirection(Vector3 direction)
    {
        transform.rotation = Quaternion.LookRotation(direction).normalized;
    }
}
