using UnityEngine;


namespace DeBox.Unitoolz.Utils
{
    public static class VectorUtils
    {
        private const float UNITY_ROTATION_ANGLE_OFFSET = 90;
        private const float HALF_CIRCLE_DEGS = 180;
        private const float CIRCLE_DEGS = 360;
        
        
        public static Vector3 FromXZToXY(Vector3 xz)
        {
            return new Vector3(xz.x, xz.z, xz.y);
        }

        
        public static Vector3 FromXYToXZ(Vector3 xy)
        {
            return new Vector3(xy.x, xy.z, xy.y);
        }
        
        /// <summary>
        /// Returns a signed smallest delta angle between two vectors
        /// </summary>
        /// <returns>Signed delta angle.</returns>
        /// <param name="source">Source vector</param>
        /// <param name="dest">Target vector</param>
        public static float SmallestDeltaAngle(Vector2 source, Vector2 target)
        {
            var currentAngle = ToAngle(source);
            var targetAngle = ToAngle(target);
            var deltaAngle = currentAngle - targetAngle;
            if (Mathf.Abs(deltaAngle) > HALF_CIRCLE_DEGS)
            {
                deltaAngle = Mathf.Sign(deltaAngle)*((Mathf.Abs(deltaAngle) - CIRCLE_DEGS));
            }
            return deltaAngle;
        }

        /// <summary>
        /// Returns the angle;
        /// </summary>
        public static float ToAngle(Vector2 v)
        {
            return (CIRCLE_DEGS - UNITY_ROTATION_ANGLE_OFFSET + Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg) % CIRCLE_DEGS;
        }

        public static Vector2 FromAngle(float angle)
        {
            var radians = (angle + UNITY_ROTATION_ANGLE_OFFSET) * Mathf.Deg2Rad;
            var v = new Vector2();
            v.x = Mathf.Cos(radians);
            v.y = Mathf.Sin(radians);
            return v;
        }
    }
}




