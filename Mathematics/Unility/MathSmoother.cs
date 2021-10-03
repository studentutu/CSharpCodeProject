/*************************************************************************
 *  Copyright (C) 2016-2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MathSmoother.cs
 *  Description  :  Math smoother base mathematical methods.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  6/21/2016
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Mathematics.Unility
{
    /// <summary>
    /// Math smoother base mathematical methods.
    /// </summary>
    public sealed class MathSmoother
    {
        #region Linear
        /// <summary>
        /// Three point linear smooth.
        /// </summary>
        /// <param name="s">Data source.</param>
        /// <returns>Smooth result.</returns>
        public static double[] ThreePointLinear(double[] s)
        {
            var n = s.Length;
            var r = new double[n];
            if (n < 3)
            {
                for (int i = 0; i < n; i++)
                {
                    r[i] = s[i];
                }
            }
            else
            {
                r[0] = (5 * s[0] + 2 * s[1] - s[2]) / 6;
                for (int i = 1; i < n - 1; i++)
                {
                    r[i] = (s[i - 1] + s[i] + s[i + 1]) / 3;
                }
                r[n - 1] = (5 * s[n - 1] + 2 * s[n - 2] - s[n - 3]) / 6;
            }
            return r;
        }

        /// <summary>
        /// Five point linear smooth.
        /// </summary>
        /// <param name="s">Data source.</param>
        /// <returns>Smooth result.</returns>
        public static double[] FivePointLinear(double[] s)
        {
            var n = s.Length;
            var r = new double[n];
            if (n < 5)
            {
                for (int i = 0; i < n; i++)
                {
                    r[i] = s[i];
                }
            }
            else
            {
                r[0] = (3 * s[0] + 2 * s[1] + s[2] - s[4]) / 5;
                r[1] = (4 * s[0] + 3 * s[1] + 2 * s[2] + s[3]) / 10;
                for (int i = 2; i < n - 2; i++)
                {
                    r[i] = (s[i - 2] + s[i - 1] + s[i] + s[i + 1] + s[i + 2]) / 5;
                }
                r[n - 2] = (4 * s[n - 1] + 3 * s[n - 2] + 2 * s[n - 3] + s[n - 4]) / 10;
                r[n - 1] = (3 * s[n - 1] + 2 * s[n - 2] + s[n - 3] - s[n - 5]) / 5;
            }
            return r;
        }

        /// <summary>
        /// Seven point linear smooth.
        /// </summary>
        /// <param name="s">Data source.</param>
        /// <returns>Smooth result.</returns>
        public static double[] SevenPointLinear(double[] s)
        {
            var n = s.Length;
            var r = new double[n];
            if (n < 7)
            {
                for (int i = 0; i < n; i++)
                {
                    r[i] = s[i];
                }
            }
            else
            {
                r[0] = (13 * s[0] + 10 * s[1] + 7 * s[2] + 4 * s[3] + s[4] - 2 * s[5] - 5 * s[6]) / 28;
                r[1] = (5 * s[0] + 4 * s[1] + 3 * s[2] + 2 * s[3] + s[4] - s[6]) / 14;
                r[2] = (7 * s[0] + 6 * s[1] + 5 * s[2] + 4 * s[3] + 3 * s[4] + 2 * s[5] + s[6]) / 28;
                for (int i = 3; i < n - 3; i++)
                {
                    r[i] = (s[i - 3] + s[i - 2] + s[i - 1] + s[i] + s[i + 1] + s[i + 2] + s[i + 3]) / 7;
                }
                r[n - 3] = (7 * s[n - 1] + 6 * s[n - 2] + 5 * s[n - 3] + 4 * s[n - 4] + 3 * s[n - 5] + 2 * s[n - 6] + s[n - 7]) / 28;
                r[n - 2] = (5 * s[n - 1] + 4 * s[n - 2] + 3 * s[n - 3] + 2 * s[n - 4] + s[n - 5] - s[n - 7]) / 14;
                r[n - 1] = (13 * s[n - 1] + 10 * s[n - 2] + 7 * s[n - 3] + 4 * s[n - 4] + s[n - 5] - 2 * s[n - 6] - 5 * s[n - 7]) / 28;
            }
            return r;
        }
        #endregion

        #region Quadratic
        /// <summary>
        /// Five point quadratic smooth.
        /// </summary>
        /// <param name="s">Data source.</param>
        /// <returns>Smooth result.</returns>
        public static double[] FivePointQuadratic(double[] s)
        {
            var n = s.Length;
            var r = new double[n];
            if (n < 5)
            {
                for (int i = 0; i < n; i++)
                {
                    r[i] = s[i];
                }
            }
            else
            {
                r[0] = (31 * s[0] + 9 * s[1] - 3 * s[2] - 5 * s[3] + 3 * s[4]) / 35;
                r[1] = (9 * s[0] + 13 * s[1] + 12 * s[2] + 6 * s[3] - 5 * s[4]) / 35;
                for (int i = 2; i < n - 2; i++)
                {
                    r[i] = (-3 * (s[i - 2] + s[i + 2]) +
                              12 * (s[i - 1] + s[i + 1]) + 17 * s[i]) / 35;
                }
                r[n - 2] = (9 * s[n - 1] + 13 * s[n - 2] + 12 * s[n - 3] + 6 * s[n - 4] - 5 * s[n - 5]) / 35;
                r[n - 1] = (31 * s[n - 1] + 9 * s[n - 2] - 3 * s[n - 3] - 5 * s[n - 4] + 3 * s[n - 5]) / 35;
            }
            return r;
        }

        /// <summary>
        /// Seven point quadratic smooth.
        /// </summary>
        /// <param name="s">Data source.</param>
        /// <returns>Smooth result.</returns>
        public static double[] SevenPointQuadratic(double[] s)
        {
            var n = s.Length;
            var r = new double[n];
            if (n < 7)
            {
                for (int i = 0; i < n; i++)
                {
                    r[i] = s[i];
                }
            }
            else
            {
                r[0] = (32 * s[0] + 15 * s[1] + 3 * s[2] - 4 * s[3] - 6 * s[4] - 3 * s[5] + 5 * s[6]) / 42;
                r[1] = (5 * s[0] + 4 * s[1] + 3 * s[2] + 2 * s[3] + s[4] - s[6]) / 14;
                r[2] = (s[0] + 3 * s[1] + 4 * s[2] + 4 * s[3] + 3 * s[4] + s[5] - 2 * s[6]) / 14;
                for (int i = 3; i < n - 3; i++)
                {
                    r[i] = (-2 * (s[i - 3] + s[i + 3]) + 3 * (s[i - 2] + s[i + 2]) + 6 * (s[i - 1] + s[i + 1]) + 7 * s[i]) / 21;
                }
                r[n - 3] = (s[n - 1] + 3 * s[n - 2] + 4 * s[n - 3] + 4 * s[n - 4] + 3 * s[n - 5] + s[n - 6] - 2 * s[n - 7]) / 14;
                r[n - 2] = (5 * s[n - 1] + 4 * s[n - 2] + 3 * s[n - 3] + 2 * s[n - 4] + s[n - 5] - s[n - 7]) / 14;
                r[n - 1] = (32 * s[n - 1] + 15 * s[n - 2] + 3 * s[n - 3] - 4 * s[n - 4] - 6 * s[n - 5] - 3 * s[n - 6] + 5 * s[n - 7]) / 42;
            }
            return r;
        }
        #endregion

        #region Cubic
        /// <summary>
        /// Five point cubic smooth.
        /// </summary>
        /// <param name="s">Data source.</param>
        /// <returns>Smooth result.</returns>
        public static double[] FivePointCubic(double[] s)
        {
            var n = s.Length;
            var r = new double[n];
            if (n < 5)
            {
                for (int i = 0; i < n; i++)
                {
                    r[i] = s[i];
                }
            }
            else
            {
                r[0] = (69 * s[0] + 4 * s[1] - 6 * s[2] + 4 * s[3] - s[4]) / 70;
                r[1] = (2 * s[0] + 27 * s[1] + 12 * s[2] - 8 * s[3] + 2 * s[4]) / 35;
                for (int i = 2; i < n - 2; i++)
                {
                    r[i] = (-3 * (s[i - 2] + s[i + 2]) + 12 * (s[i - 1] + s[i + 1]) + 17 * s[i]) / 35;
                }
                r[n - 2] = (2 * s[n - 5] - 8 * s[n - 4] + 12 * s[n - 3] + 27 * s[n - 2] + 2 * s[n - 1]) / 35;
                r[n - 1] = (-s[n - 5] + 4 * s[n - 4] - 6 * s[n - 3] + 4 * s[n - 2] + 69 * s[n - 1]) / 70;
            }
            return r;
        }

        /// <summary>
        /// Seven point cubic smooth.
        /// </summary>
        /// <param name="s">Data source.</param>
        /// <returns>Smooth result.</returns>
        public static double[] SevenPointCubic(double[] s)
        {
            var n = s.Length;
            var r = new double[n];
            if (n < 7)
            {
                for (int i = 0; i < n; i++)
                {
                    r[i] = s[i];
                }
            }
            else
            {
                r[0] = (39 * s[0] + 8 * s[1] - 4 * s[2] - 4 * s[3] + s[4] + 4 * s[5] - 2 * s[6]) / 42;
                r[1] = (8 * s[0] + 19 * s[1] + 16 * s[2] + 6 * s[3] - 4 * s[4] - 7 * s[5] + 4 * s[6]) / 42;
                r[2] = (-4 * s[0] + 16 * s[1] + 19 * s[2] + 12 * s[3] + 2 * s[4] - 4 * s[5] + s[6]) / 42;
                for (int i = 3; i <= n - 4; i++)
                {
                    r[i] = (-2 * (s[i - 3] + s[i + 3]) + 3 * (s[i - 2] + s[i + 2]) + 6 * (s[i - 1] + s[i + 1]) + 7 * s[i]) / 21;
                }
                r[n - 3] = (-4 * s[n - 1] + 16 * s[n - 2] + 19 * s[n - 3] + 12 * s[n - 4] + 2 * s[n - 5] - 4 * s[n - 6] + s[n - 7]) / 42;
                r[n - 2] = (8 * s[n - 1] + 19 * s[n - 2] + 16 * s[n - 3] + 6 * s[n - 4] - 4 * s[n - 5] - 7 * s[n - 6] + 4 * s[n - 7]) / 42;
                r[n - 1] = (39 * s[n - 1] + 8 * s[n - 2] - 4 * s[n - 3] - 4 * s[n - 4] + s[n - 5] + 4 * s[n - 6] - 2 * s[n - 7]) / 42;
            }
            return r;
        }
        #endregion
    }
}