using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UUtils;
using NaughtyAttributes;

public class ObjectsSpawner : MonoBehaviour
{
    [SerializeField] private Transform _holder;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _count;
    [SerializeField] private float _radius;
    [SerializeField] private float _minSpawnDistance;

    [SerializeField] private bool _display;

    private List<Vector3> _positions = new List<Vector3>();

    [Button("Spawn")]
    private void Spawn()
    {
        for (int i = 0; i < _count; i++)
        {
            Vector3 point = GeneratePoint();
            _positions.Add(point);
            GameObject obj = PrefabUtility.InstantiatePrefab(_prefab, transform) as GameObject;
            obj.transform.position = point.WithY(transform.position.y);
            obj.transform.rotation = Quaternion.identity;
        }
    }

    private Vector3 GeneratePoint()
    {
        Vector3 point = Vector3.zero;
        int iterations = 0;
        while(iterations < 1000)
        {
            iterations++;
            do
            {
                point = transform.position + Random.insideUnitSphere * GetRadius();
                point.y = 0;
            }
            while (_positions.Contains(point));

            if(NotTooClose(point))
            {
                break;
            }
        }
        return point;

    }

    private bool NotTooClose(Vector3 point)
    {
        for (int i = 0; i < _positions.Count; i++)
        {
            if (UUtils.MathUtils.InRange(point, _positions[i], _minSpawnDistance))
            {
                return false;
            }
        }

        return true;
    }

    private float GetRadius()
    {
        return Random.Range(0, _radius);
    }

    [Button("To Holder")]
    private void ToHolder()
    {
        MeshRenderer[] objects = GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].transform.parent = _holder;
        }
    }


    [Button("Clear")]
    private void Clear()
    {
        MeshRenderer[] objects = GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < objects.Length; i++)
        {
            DestroyImmediate(objects[i].gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        if(!_display)
        {
            return;
        }

        Gizmos.color = new Color(1, 1, 1, 0.2f);
        Gizmos.DrawSphere(transform.position, _radius);
    }
}
