using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

namespace UUtils
{
    public enum Axis
    {
        Up, Down, Left, Right, Forward, Back
    }

    public static class MathUtils
    {
        #region Fields
        public static readonly Dictionary<Axis, Vector3> Axis = new Dictionary<Axis, Vector3>()
        {
            { UUtils.Axis.Up, Vector3.up }, { UUtils.Axis.Down, Vector3.down }, { UUtils.Axis.Forward, Vector3.forward },
            { UUtils.Axis.Back, Vector3.back }, { UUtils.Axis.Left, Vector3.left }, { UUtils.Axis.Right, Vector3.right },
        };
        #endregion

        #region Arithmetic
        public static bool Even(int value)
        {
            return value % 2 == 0 ? true : false;
        }

        public static int Random(int min, int max)
        {
            int value = UnityEngine.Random.Range(min, max);
            return value;
        }

        public static int Random(int min, int max, ref int prevValue)
        {
            if(min == max)
            {
                throw new InvalidOperationException("Min value must be less than max");
            }    
            int value;
            do
            {
                value = Random(min, max);
            }
            while (value == prevValue);
            prevValue = value;
            return value;
        }

        public static float Random(float min, float max)
        {
            float value = UnityEngine.Random.Range(min, max);
            return value;
        }

        public static float Random(float min, float max, ref float prevValue)
        {
            if (min == max)
            {
                throw new InvalidOperationException("Min value must be less than max");
            }
            float value;
            do
            {
                value = Random(min, max);
            }
            while (value == prevValue);
            prevValue = value;
            return value;
        }

        public static T RandomArrayElement<T>(T[] array, int minIndex = 0)
        {
            int i = Random(minIndex, array.Length);
            return array[i];
        }

        public static T RandomElement<T>(IEnumerable<T> collection, int minIndex = 0)
        {
            int i = Random(minIndex, collection.Count());
            return collection.ElementAt(i);
        }

        public static float Percent(float value, float percent)
        {
            return (value * percent) / 100;
        }

        public static int NumberLength(int number)
        {
            return Mathf.FloorToInt(Mathf.Log10(Mathf.Abs(number)) + 1);
        }

        public static bool Dividible(int dividable, int divider)
        {
            return dividable % divider == 0;
        }

        public static int Lowest(int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if(array[i] < min)
                {
                    min = array[i];
                }
            }

            return min;
        }
        #endregion

        #region Physics
        public static Vector3 Velocity(Vector3 origin, Vector3 target, float time)
        {
            Vector3 distance = target - origin;
            Vector3 distanceXZ = distance;
            distanceXZ.y = 0f;

            float sY = distance.y;
            float sXZ = distanceXZ.magnitude;

            float Vxz = sXZ / time;
            float Vy = sY / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

            Vector3 result = distanceXZ.normalized;
            result *= Vxz;
            result.y = Vy;

            return result;
        }

        #endregion

        #region Vectors
        public static float SqrDistance(Vector3 from, Vector3 to)
        {
            return (from - to).sqrMagnitude;
        }

        public static bool InRange(Vector3 from, Vector3 to, float distance)
        {
            return SqrDistance(from, to) < distance * distance;
        }

        public static Transform GetClosest(Transform from, Transform[] targets)
        {
            Transform closest = targets[0];
            float closestDistance = SqrDistance(from.position, targets[0].position);
            for (int i = 1; i < targets.Length; i++)
            {
                float distance = SqrDistance(from.position, targets[i].position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closest = targets[i];
                }
            }

            return closest;
        }
        public static T GetClosest<T>(Transform from, T[] targets) where T : MonoBehaviour
        {
            T closest = targets[0];
            float closestDistance = SqrDistance(from.position, targets[0].transform.position);
            for (int i = 1; i < targets.Length; i++)
            {
                float distance = SqrDistance(from.position, targets[i].transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closest = targets[i];
                }
            }

            return closest;
        }

        public static Vector3 RandomAxis()
        {
            int index = Random(0, Axis.Count - 1);
            return Axis[(Axis)index];
        }

        public static Vector3 RandomIncludeAxis(Axis[] include)
        {
            Axis axis = RandomArrayElement(include);
            return Axis[axis];
        }

        public static Vector3 RandomAxis(Axis[] nonInclude)
        {
            Vector3 direction;
            Axis key = UUtils.Axis.Back;
            do
            {
                direction = RandomAxis();
                foreach (var d in Axis)
                {
                    if (d.Value == direction)
                    {
                        key = d.Key;
                    }
                }
            }
            while (nonInclude.Contains(key));

            return direction;
        }

        public static Vector3 RandomTransformAxis(this Transform transform)
        {
            Vector3 direction = RandomAxis();
            direction = transform.InverseTransformDirection(direction);
            return direction;
        }
        public static Vector3 RandomTransformAxis(this Transform transform, Axis[] nonInclude)
        {
            Vector3 direction = RandomAxis(nonInclude);
            direction = transform.InverseTransformDirection(direction);
            return direction;
        }

        public static Vector3 RandomDirection()
        {
            Vector3 dir = UnityEngine.Random.insideUnitSphere.normalized;
            dir = new Vector3(Mathf.Sign(dir.x), Mathf.Sign(dir.y), Mathf.Sign(dir.z));
            return dir;
        }

        public static Vector3 RandomDirection(Vector3 inculdeAxis)
        {
            Vector3 direction = RandomDirection();
            return Vector3.Scale(direction, inculdeAxis);
        }

        public static Vector3 RandomDirection(Axis[] inculdeAxis)
        {
            var validAxis = Axis.Where(a => inculdeAxis.Contains(a.Key)).ToDictionary(p => p.Key, p => p.Value);
            Vector3[] directions = new Vector3[validAxis.Count];
            directions = validAxis.Values.ToArray();
            return RandomArrayElement(directions);
        }

        public static Vector3 RandomTransformDirection(this Transform transform)
        {
            Vector3 direction = RandomDirection();
            direction = transform.InverseTransformDirection(direction);
            return direction;
        }

        public static Vector3 RandomTransformDirection(this Transform transform, Vector3 includeAxis)
        {
            Vector3 direction = RandomDirection(includeAxis);
            direction = transform.InverseTransformDirection(direction);
            return direction;
        }

        public static Vector3 Parabola(Vector3 start, Vector3 end, float height, float t)
        {
            Func<float, float> f = x => -4 * height * x * x + 4 * height * x;

            var mid = Vector3.Lerp(start, end, t);

            return new Vector3(mid.x, f(t) + Mathf.Lerp(start.y, end.y, t), mid.z);
        }
        #endregion

        #region Quaternions
        public static Quaternion LookRotation(Vector3 from, Vector3 to)
        {
            Vector3 dir = from - to;
            return Quaternion.LookRotation(dir);
        }
        #endregion
    }
}
