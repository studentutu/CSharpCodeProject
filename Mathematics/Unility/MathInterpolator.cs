/*************************************************************************
 *  Copyright © 2018-2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MathInterpolator.cs
 *  Description  :  Interpolator base mathematical methods.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/29/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.Mathematics
{
    /// <summary>
    /// Interpolator base mathematical methods.
    /// </summary>
    public sealed class MathInterpolator
    {
        /// <summary>
        /// Interpolate between p0 and p1 by t.
        /// </summary>
        /// <param name="p0">Start value of interpolate value.</param>
        /// <param name="p1">End value of interpolate value.</param>
        /// <param name="t">t is between 0 and 1.</param>
        /// <returns></returns>
        public static double Lerp(double p0, double p1, double t)
        {
            return p0 + (p1 - p0) * t;
        }

        /// <summary>
        /// Linear bezier interpolate from p0 to p1 by t.
        /// </summary>
        /// <param name="p0">Start value of interpolate value.</param>
        /// <param name="p1">End value of interpolate value.</param>
        /// <param name="t">t is between 0 and 1.</param>
        /// <returns></returns>
        public static double Bezier(double p0, double p1, double t)
        {
            return (1 - t) * p0 + t * p1;
        }

        /// <summary>
        /// Quadratic bezier interpolate from p0 to p1 base t0 by t.
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <param name="t0"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static double Bezier(double p0, double p1, double t0, double t)
        {
            /*
             *      2                  2
             * (1-t) p1 + 2t(1-t)t0 + t p1
             */

            return Math.Pow(1 - t, 2) * p1 + 2 * t * (1 - t) * t0 + Math.Pow(t, 2) * p1;
        }

        /// <summary>
        /// Cubic bezier interpolate from p0 to p1 base t0 and t1 by t.
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <param name="t0"></param>
        /// <param name="t1"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static double Bezier(double p0, double p1, double t0, double t1, double t)
        {
            /*
             *      3            2            2      3
             * (1-t) p0 + 3t(1-t) t0 + 3(1-t)t t1 + t p1
             */

            return Math.Pow(1 - t, 3) * p0 + 3 * t * Math.Pow(1 - t, 2) * t0 + 3 * (1 - t) * Math.Pow(t, 2) * t1 + Math.Pow(t, 3) * p1;
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
    }
}