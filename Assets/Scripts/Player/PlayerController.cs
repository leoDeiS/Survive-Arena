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
    private PlayerWeaponController _weaponController;
    private PlayerHealth _health;

    private void Awake()
    {
        _camera = Camera.main;
        _animator = GetComponentInChildren<PlayerAnimator>();
        _movement = GetComponent<MovementController>();
        _weaponController = GetComponent<PlayerWeaponController>();
        InitializeHealth();
    }

    private void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");

        Vector3 moveVector = new Vector3(xMove, 0, yMove).normalized;

        MoveAndRotate(moveVector);

        if (Input.GetMouseButton(0))
        {
            _weaponController.Shoot(GetMouseDirection().normalized);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            _weaponController.Reload();
        }
    }

    private void InitializeHealth()
    {
        _health = GetComponent<PlayerHealth>();
        _health.OnDeath += Die;
    }

    private void MoveAndRotate(Vector3 moveVector)
    {
        Vector3 mouseDirection = GetMouseDirection();
        if (mouseDirection != Vector3.zero)
        {
            _movement.RotateDirection(GetMouseDirection().WithY(0));
        }

        _movement.Move(moveVector);

        _animator.SetVelocity(GetVelocity(_movement.Velocity));
    }

    private Vector3 GetVelocity(Vector3 direction)
    {
        return Quaternion.Inverse( Quaternion.LookRotation(transform.forward)) * direction;
    }

    private Vector3 GetMouseDirection()
    {
        Vector3 mousePoint = CameraUtils.GetMouseHitPosition(_camera, _mouseCollisionLayer);
        return mousePoint - transform.position;
    }

    private void Die()
    {
        _animator.SetDeath();
        _weaponController.enabled = false;
        enabled = false;
    }
}
