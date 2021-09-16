﻿/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoCurveUtility.cs
 *  Description  :  Utility for mono curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  9/15/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;

namespace MGS.Curve
{
    /// <summary>
    /// Utility for mono curve.
    /// </summary>
    public sealed class MonoCurveUtility
    {
        /// <summary>
        /// Get detail count of mono curve.
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="detail"></param>
        /// <param name="differ">Differentiation.</param>
        /// <returns>Detail count of mono curve.</returns>
        public static int GetDetailCount(IMonoCurve curve, MonoCurveDetail detail, out float differ)
        {
            //AwayFromZero means that 12.5 -> 13
            var units = (int)Math.Round(curve.Length * detail.unit, MidpointRounding.AwayFromZero);
            var count = Mathf.Clamp(units, detail.min, detail.max);
            differ = curve.Length / count;
            return count;
        }
    }
}