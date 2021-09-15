/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  RenderDetail.cs
 *  Description  :  Detail settings of render.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  9/16/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.Curve
{
    /// <summary>
    /// Detail settings of render.
    /// </summary>
    [Serializable]
    public struct RenderDetail
    {
        /// <summary>
        /// Min detail.
        /// </summary>
        public int min;

        /// <summary>
        /// Normal detail.
        /// </summary>
        public int normal;

        /// <summary>
        /// Max detail.
        /// </summary>
        public int max;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="min">Min detail.</param>
        /// <param name="normal">Normal detail.</param>
        /// <param name="max">Max detail.</param>
        public RenderDetail(int min, int normal, int max)
        {
            this.min = min;
            this.normal = normal;
            this.max = max;
        }
    }
}