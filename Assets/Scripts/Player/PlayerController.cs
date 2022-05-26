using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UUtils;

[RequireComponent(typeof(MovementController), typeof(PlayerWeaponController), typeof(PlayerHealth))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask _mouseCollisionLayer;

    private Camera _camera;

    private PlayerAnimator _animator;
    private MovementController _movement;
    private PlayerHealth _health;

    private void Awake()
    {
        _camera = Camera.main;
        _animator = GetComponentInChildren<PlayerAnimator>();
        _movement = GetComponent<MovementController>();
        InitializeHealth();
    }

    private void Update()
    {
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");

        Vector3 moveVector = new Vector3(xMove, 0, yMove);

        Vector3 mouseDirection = GetMouseDirection();
        if(mouseDirection != Vector3.zero)
        {
            _movement.RotateDirection(GetMouseDirection());
        }

        _movement.Move(moveVector);

        _animator.SetVelocity(GetVelocity(_movement.Velocity));
    }

    private void InitializeHealth()
    {
        _health = GetComponent<PlayerHealth>();
        _health.OnDeath += Die;
    }

    private Vector3 GetVelocity(Vector3 direction)
    {
        return Quaternion.Inverse( Quaternion.LookRotation(transform.forward)) * direction;
    }

    private Vector3 GetMouseDirection()
    {
        Vector3 mousePoint = CameraUtils.GetMouseHitPosition(_camera, _mouseCollisionLayer);
        return (mousePoint - transform.position).WithY(0);
    }

    private void Die()
    {

    }
}
