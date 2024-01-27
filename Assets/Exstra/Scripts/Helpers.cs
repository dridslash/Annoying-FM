using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Exstra
{
    public static class Helpers
    {
        private static Camera _camera;

        public static Camera Camera
        {
            get
            {
                if (_camera == null) _camera = Camera.main;
                return _camera;
            }
        }

        private static PointerEventData _eventDataCurrentPosition;
        private static List<RaycastResult> _results;
        public static bool IsOverUI()
        {
            _eventDataCurrentPosition = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
            _results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(_eventDataCurrentPosition, _results);
            return _results.Count > 0;
        }

        public static Vector2 GetWorldPositionOfCanvasElement(RectTransform element)
        {
            RectTransformUtility.ScreenPointToWorldPointInRectangle(element, element.position, Camera, out var result);
            return result;
        }

        public static void DeleteChildren(this Transform t)
        {
            foreach (Transform child in t)
            {
                Object.Destroy(child.gameObject);
            }
        }

        public static void AlignTo(this Transform t, Vector3 normal, bool inUpdate = false)
        {
            var rotation = t.rotation;
            var alignment = Quaternion.FromToRotation(t.up, normal) * rotation;
            var inverse = Quaternion.Inverse(rotation);
            var target = inverse * alignment;

            if (inUpdate)
            {
                // Calculate the Delta Align Rotation.
                var delta = Quaternion.Lerp(Quaternion.identity, target, Time.deltaTime * 5);
                t.rotation *= delta;
            }
            else
            {
                t.rotation = target;
            }
        }

        public static bool IsPositionInView(Vector3 worldPosition)
        {
            Vector3 viewportPosition = Camera.WorldToViewportPoint(worldPosition);

            return viewportPosition.z > 0 &&
                viewportPosition.x >= 0 && viewportPosition.x <= 1 &&
                viewportPosition.y >= 0 && viewportPosition.y <= 1;
        }
    }
}