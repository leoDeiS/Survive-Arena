using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UUtils
{
    public static class GUtils
    {
        public static Transform[] GetTransfroms<T>(T[] array) where T : MonoBehaviour
        {
            Transform[] transforms = new Transform[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                transforms[i] = array[i].transform;
            }

            return transforms;
        }

        public static List<Transform> GetTransfroms<T>(List<T> list) where T : MonoBehaviour
        {
            List<Transform> transforms = new List<Transform>();
            for (int i = 0; i < list.Count; i++)
            {
                transforms.Add(list[i].transform);
            }

            return transforms;
        }

        public static void SetCoroutine(this MonoBehaviour mono, ref IEnumerator current, IEnumerator next)
        {
            if(current != null)
            {
                mono.StopCoroutine(current);
            }
            current = next;
            mono.StartCoroutine(current);
        }

        public static Vector3 GetRaycastPoint(Vector3 origin, Vector3 direction, LayerMask layerMask)
        {
            Ray ray = new Ray(origin, direction);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 1000, layerMask))
            {
                return hit.point;
            }
            else
            {
                return Vector3.zero;
            }
        }

        public static Vector3 GetRaycastPoint(Vector3 origin, Vector3 direction)
        {
            return GetRaycastPoint(origin, direction, ~0);
        }

        public static int GetParentsCount(this Transform transform)
        {
            var count = 0;
            var currentTransform = transform;

            while (currentTransform.parent != null)
            {
                count++;
                currentTransform = currentTransform.parent;
            }

            return count;
        }

        public static Vector3 WithY(this Vector3 vector3, float y)
        {
            return new Vector3 (vector3.x, y, vector3.z);
        }
    }
}
