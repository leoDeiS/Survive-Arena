using UnityEngine;

public interface IEnemyTarget
{
    Transform TargetTransform { get; }
    void OnReached();
}
