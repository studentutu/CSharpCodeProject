/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IKeyCurve.cs
 *  Description  :  Define key curve interface.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/24/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UCurve
{
    /// <summary>
    /// Interface of key curve.
    /// </summary>
    public interface IKeyCurve : ICurve
    {
        /// <summary>
        /// Evaluate the curve at key.
        /// </summary>
        /// <param name="k">The key within the curve you want to evaluate (the horizontal axis in the curve graph).</param>
        /// <returns>The value of the curve, at the point in key specified.</returns>
        Vector3 Evaluate(float k);
    }
}