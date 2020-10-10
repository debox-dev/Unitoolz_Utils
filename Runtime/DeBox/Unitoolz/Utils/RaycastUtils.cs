using System.Collections.Generic;
using UnityEngine;


namespace DeBox.Unitoolz.Utils
{
    public static class RaycastUtils
    {
        public static IEnumerable<RaycastHit2D> RaycastCone2D(Vector2 position, Vector2 direction, float distance, float coneAngle, int rayCount, float skipDistance = 0)
        {
            foreach (var segmentDirection in GetConeDirections2D(direction, coneAngle, rayCount))
            {            
                var hit = Physics2D.Raycast(position + segmentDirection * skipDistance, segmentDirection, distance * 2);
                if (hit.collider != null && hit.distance <= distance)
                {
                    yield return hit;
                }
            }
        }
        
        public static IEnumerable<Vector3> GetFlatConeDirections3D(Vector3 direction, Vector3 up, float coneAngle, int segmentCount)
        {
            var rotation = Quaternion.LookRotation(direction, up);
            foreach (var directionXY in GetConeDirections2D(Vector2.up, coneAngle, segmentCount))
            {
                yield return rotation * VectorUtils.FromXYToXZ(directionXY);
            }
        }

        public static IEnumerable<Vector2> GetConeDirections2D(Vector2 direction, float coneAngle, int segmentCount)
        {
            var halfConeAngle = coneAngle * 0.5f;
            var centerAngle = VectorUtils.ToAngle(direction);
            var startAngle = centerAngle - halfConeAngle;
            var endAngle = centerAngle + halfConeAngle;
            for (int i = 0; i < segmentCount; i++)
            {
                var progress = (float)i / (segmentCount - 1);
                var segmentAngle = Mathf.Lerp(startAngle, endAngle, progress);
                var segmentDirection = VectorUtils.FromAngle(segmentAngle);
                yield return segmentDirection;
            }
        }
    }
}