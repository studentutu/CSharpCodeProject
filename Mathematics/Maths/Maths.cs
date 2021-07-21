/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Maths.cs
 *  Description  :  Define mathematical concepts and methods.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/29/2018
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Mathematics
{
    /// <summary>
    /// Mathematical concepts and methods.
    /// </summary>
    public sealed class Maths
    {
        #region Interpolation
        /// <summary>
        /// Interpolate between a and b by t.
        /// </summary>
        /// <param name="from">Start value of interpolate value.</param>
        /// <param name="to">End value of interpolate value.</param>
        /// <param name="t">t is between 0 and 1.</param>
        /// <returns></returns>
        public static double Lerp(double from, double to, double t)
        {
            return from + (to - from) * t;
        }

        /// <summary>
        /// Hermite interpolate between t0 and t1 by t.
        /// </summary>
        /// <param name="t0">Time of t0.</param>
        /// <param name="v0">Value of t0.</param>
        /// <param name="m0">Micro quotient value of t0.</param>
        /// <param name="t1">Time of t1.</param>
        /// <param name="v1">Value of t1.</param>
        /// <param name="m1">Micro quotient value of t1.</param>
        /// <param name="t">t is between t0 and t1.</param>
        /// <returns></returns>
        public static double Hermite(double t0, double v0, double m0, double t1, double v1, double m1, double t)
        {
            /*  Hermite Polynomial Structure
             *  Base: H(t) = v0a0(t) + v1a1(t) + m0b0(t) + m1b1(t)
             * 
             *                     t-t0    t-t1  2
             *        a0(t) = (1+2------)(------)
             *                     t1-t0   t0-t1
             *                    
             *                     t-t1    t-t0  2
             *        a1(t) = (1+2------)(------)
             *                     t0-t1   t1-t0
             * 
             *                        t-t1  2
             *        b0(t) = (t-t0)(------)
             *                        t0-t1
             * 
             *                        t-t0  2
             *        b1(t) = (t-t1)(------)
             *                        t1-t0
             * 
             *  Let:  d0 = t-t0, d1 = t-t1, d = t0-t1
             * 
             *              d0          d1
             *        q0 = ---- , q1 = ----
             *              d           d
             * 
             *               t-t1  2     d1  2     2          t-t0  2     d0  2     2
             *        p0 = (------)  = (----)  = q1  , p1 = (------)  = (----)  = q0
             *               t0-t1       d                    t1-t0       -d
             * 
             *  Get:  H(t) = (1-2q0)v0p0 + (1+2q1)v1p1 + mod0p0 + m1d1p1
             */

            var d0 = t - t0;
            var d1 = t - t1;
            var d = t0 - t1;

            var q0 = d0 / d;
            var q1 = d1 / d;

            var p0 = q1 * q1;
            var p1 = q0 * q0;

            return (1 - 2 * q0) * v0 * p0 + (1 + 2 * q1) * v1 * p1 + m0 * d0 * p0 + m1 * d1 * p1;
        }
        #endregion
    }
}