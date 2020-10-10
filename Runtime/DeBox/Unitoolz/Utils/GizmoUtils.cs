using UnityEngine;

namespace DeBox.Unitoolz.Utils
{
    public static class GizmoUtils 
    {
        public static void DrawCircle2D(Vector3 position, float radius, Color color, int segmentationFactor = 4, int maxSegments = 15)
        {
            Gizmos.color = color;
            var segmentCount = Mathf.Max((int)radius * segmentationFactor, maxSegments);
            var euler = new Vector3 ();
            var points = new Vector3 [segmentCount];

            for (int i = 0; i < segmentCount; i++) {
                euler.z = (i / (float)segmentCount) * 360;
                var directionFromCenter = Quaternion.Euler (euler) * Vector3.up;
                var point = directionFromCenter.normalized * radius + position;
                points [i] = point;
            }

            for (int i = 1; i < segmentCount; i++) {
                Gizmos.DrawLine (points [i], points [i - 1]);
            }
            Gizmos.DrawLine (points [segmentCount - 1], points [0]);
        }
    }
}