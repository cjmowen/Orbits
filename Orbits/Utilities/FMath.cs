using System;

namespace Orbits.Utilities
{
    /// <summary>
    /// A wrapper class for System.Math that supports operations with floats.
    /// </summary>
    static class FMath
    {
        public static float Sin(float radians)
        {
            return (float) Math.Sin(radians);
        }

        public static float Cos(float radians)
        {
            return (float) Math.Cos(radians);
        }

        public static float Tan(float radians)
        {
            return (float) Math.Tan(radians);
        }
    }
}
