using UnityEngine;

public interface IBullet
{
    public Vector3 MoveDirection { get; }
    void Release(Vector3 direction);
}
