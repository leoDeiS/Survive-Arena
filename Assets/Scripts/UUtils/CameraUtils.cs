using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UUtils
{

    public static class CameraUtils
    {
        public static bool InFieldOfView(Camera cam, Transform target)
        {
            Vector3 screenPoint = cam.WorldToScreenPoint(target.position);

            return screenPoint.x <= 0
                || screenPoint.x >= Screen.width
                || screenPoint.y <= 0
                || screenPoint.y >= Screen.height;
        }
        public static bool RayToClickPoint(Camera camera, out Vector3 point, LayerMask layerMask)
        {
            RaycastHit hit = GetRaycastHit(camera, layerMask);
            if (hit.point != Vector3.zero)
            {
                point = hit.point;
                return true;
            }
            else
            {
                point = Vector3.zero;
                return false;
            }
        }

        public static Vector3 GetMouseHitPosition(Camera camera, LayerMask layermask)
        {
            RaycastHit hit = GetRaycastHit(camera, layermask);
            return hit.point;
        }

        public static RaycastHit GetRaycastHit(Camera camera, LayerMask layerMask)
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10000, layerMask))
            {
                return hit;
            }

            return new RaycastHit();
        }
        public static void SendRay(Camera camera, LayerMask layerMask, Action<RaycastHit> onHitAction)
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000, layerMask))
            {
                onHitAction?.Invoke(hit);
            }
        }

        public static Vector3 GetMouseClickPosition(Camera camera, float distance = 10)
        {
            Vector3 targetPosition = Input.mousePosition;
            targetPosition.z = distance;
            return camera.ScreenToWorldPoint(targetPosition);
        }
    }
}
