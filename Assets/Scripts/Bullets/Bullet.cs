using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Bullet : MonoBehaviour, IBullet
{
    protected float _speed;
    protected float _damage;

    protected Rigidbody _rigidbody;
    protected Vector3 _direction;

    public Vector3 MoveDirection => _direction;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected virtual void FixedUpdate()
    {
        _rigidbody.velocity = _direction * _speed * Time.deltaTime;
        _rigidbody.rotation = Quaternion.LookRotation(_direction);
    }

    private void OnCollisionEnter(Collision collision)
    {
        IHealth health;
        if(collision.transform.TryGetComponent(out health))
        {
            health.TakeDamage(_damage, _direction);
        }

        Destroy();
    }

    protected virtual void Destroy()
    {
        Destroy(gameObject);
    }

    public void SetStats(float speed, float damage)
    {
        _speed = speed;
        _damage = damage;
    }

    public virtual void Release(Vector3 direction)
    {
        _direction = direction;
    }
}
