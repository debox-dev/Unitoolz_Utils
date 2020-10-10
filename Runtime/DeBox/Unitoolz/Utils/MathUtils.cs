using UnityEngine;


namespace DeBox.Unitoolz.Utils
{
    public static class MathUtils
    {
        /// <summary>
        /// Takes a float clamped from 0 to 1 and returns a corresponding value from 0 to 1 and back to 0
        /// For example:
        /// 0 will translate to 0
        /// 0.5 will translate to 1
        /// 1 will translate back to 0
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static float Pyramid(float t)
        {
            return Reverse(Mathf.Abs((t * 2 - 1)));
        }

        /// <summary>
        /// Returns a reverse of a float clamped from 0 to 1
        /// 1 will return 0
        /// 0 will return 1
        /// 0.5 will return 0.5
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static float Reverse(float t)
        {
            return 1 - t;
        }

        /// <summary>
        /// Returns a 0 to 1 representation of the ratio of value in the given range
        /// if the range is from 6 to 8 and the value is 7, the result will be 0.5
        /// if the range is from 5 to 10 and the value is 5 - the result will be 0
        ///
        /// In a way - this is the "inverse" of the Mathf.Lerp function. Instead of giving the PCT you give the value
        /// and you get the PCT back
        ///
        /// Example:
        ///     var min = 1;
        ///     var max = 10;
        ///     var pct = 0.3f;
        ///     var value = Mathf.Lerp(min, max, pct);
        ///     GetRatio(value, min, max)    => will be 0.3f (pct)
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="rangeMin"></param>
        /// <param name="rangeMax"></param>
        /// <returns></returns>
        public static float GetRatio(float value, float rangeMin, float rangeMax)
        {
            var totalRange = rangeMax - rangeMin;
            var flatValue = value - rangeMin;
            return flatValue / totalRange;
        }
        
        /// <summary>
        /// It remaps value (that has an expected range of low1 to high1) into a target range of low2 to high2).
        /// </summary>
        /// <param name="value">the value you wish to remap to a different value</param>
        /// <param name="inMinMax">the minimum value you give =0 the max value you give =1</param>
        /// <returns></returns>
        public static float Remap(float value, Vector2 inMinMax)
        {
            return Remap(value, inMinMax, Vector2.up);
        }
        
        /// <summary>
        /// It remaps value (that has an expected range of low1 to high1) into a target range of low2 to high2).
        /// </summary>
        /// <param name="value">the value you wish to remap to a different value</param>
        /// <param name="inMinMax">the minimum value you give =0 the max value you give =1</param>
        /// <param name="outMinMax">outs a different range other then 01</param>
        /// <returns></returns>
        public static float Remap(float value, Vector2 inMinMax, Vector2 outMinMax)
        {
            return Mathf.Lerp(outMinMax.x, outMinMax.y, GetRatio(value, inMinMax.x, inMinMax.y));
        }
    }
}