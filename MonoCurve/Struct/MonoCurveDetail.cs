/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoCurveDetail.cs
 *  Description  :  Detail settings of mono curve.
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
    /// Detail settings of mono curve.
    /// </summary>
    [Serializable]
    public struct MonoCurveDetail
    {
        /// <summary>
        /// Min detail.
        /// </summary>
        public int min;

        /// <summary>
        /// Unit detail.
        /// </summary>
        public int unit;

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
        public MonoCurveDetail(int min, int normal, int max)
        {
            this.min = min;
            this.unit = normal;
            this.max = max;
        }
    }
}