/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ICurveRoute.cs
 *  Description  :  Define interface of route that base on curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  2/28/2018
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.UCurve.Route
{
    /// <summary>
    /// Interface of curve route.
    /// </summary>
    public interface ICurveRoute : ITimeCurve
    {
        /// <summary>
        /// Length of route.
        /// </summary>
        float Length { get; }

        /// <summary>
        /// Rebuild route.
        /// </summary>
        void Rebuild();
    }
}