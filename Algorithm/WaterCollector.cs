/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  WaterCollector.cs
 *  Description  :  Utility for collect water.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/16/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;

namespace MGS.Algorithm
{
    /// <summary>
    /// Utility for collect water.
    /// </summary>
    public sealed class WaterCollector
    {
        /// <summary>
        /// Collect water base the pillars.
        /// </summary>
        /// <param name="ps">Pillars array.</param>
        /// <returns>Water volume.</returns>
        public static long CollectWater(int[] ps)
        {
            /*
             * Designed by Mogoson.
             * 
             *       hj_0
             * i_0    __
             *  __   |  |   __
             * |  |__|  |__|  |
             * --------------------
             *        i_1  hj_1
             */

            var v = 0L;
            for (int i = 0; i < ps.Length; i++)
            {
                int hj = i + 1;
                for (int j = i + 1; j < ps.Length; j++)
                {
                    if (ps[j] > ps[hj])
                    {
                        hj = j;
                    }

                    if (ps[j] >= ps[i])
                    {
                        break;
                    }
                }

                if (hj - i > 1)
                {
                    int h = i;
                    if (ps[hj] < ps[h])
                    {
                        h = hj;
                    }
                    for (int lj = i + 1; lj < hj; lj++)
                    {
                        v += ps[h] - ps[lj];
                    }
                }

                i = hj - 1;
            }
            return v;
        }

        /// <summary>
        /// Collect waters base the pillars.
        /// </summary>
        /// <param name="ps">Pillars array.</param>
        /// <returns>Waters info (index, volume).</returns>
        public static Dictionary<int, int> CollectWaters(int[] ps)
        {
            /*
             * Designed by Mogoson.
             * 
             *       hj_0
             * i_0    __
             *  __   |  |   __
             * |  |__|  |__|  |
             * --------------------
             *        i_1  hj_1
             */

            var ws = new Dictionary<int, int>();
            for (int i = 0; i < ps.Length; i++)
            {
                int hj = i + 1;
                for (int j = i + 1; j < ps.Length; j++)
                {
                    if (ps[j] > ps[hj])
                    {
                        hj = j;
                    }

                    if (ps[j] >= ps[i])
                    {
                        break;
                    }
                }

                if (hj - i > 1)
                {
                    int h = i;
                    if (ps[hj] < ps[h])
                    {
                        h = hj;
                    }
                    for (int lj = i + 1; lj < hj; lj++)
                    {
                        var v = ps[h] - ps[lj];
                        ws.Add(lj, v);
                    }
                }

                i = hj - 1;
            }
            return ws;
        }
    }
}