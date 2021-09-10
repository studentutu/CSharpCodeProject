/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  HelixRoute.cs
 *  Description  :  Define route base on helix curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/14/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UCurve.Route
{
    /// <summary>
    /// Route base on helix curve.
    /// </summary>
    public class HelixRoute : MonoCurveRoute
    {
        /// <summary>
        /// Top ellipse args of curve.
        /// </summary>
        public EllipseArgs top = new EllipseArgs(1.0f, 1.0f);

        /// <summary>
        /// Bottom ellipse args of curve.
        /// </summary>
        public EllipseArgs bottom = new EllipseArgs(2.0f, 2.0f);

        /// <summary>
        /// Altitude from bottom to top.
        /// </summary>
        public float altitude = 2;

        /// <summary>
        /// Around radian.
        /// </summary>
        public float radian = Mathf.PI * 4;

        /// <summary>
        /// Length of route.
        /// </summary>
        public override float Length { get { return length; } }

        /// <summary>
        /// Length of route.
        /// </summary>
        protected float length;

        /// <summary>
        /// Curve for route.
        /// </summary>
        protected override ITimeCurve Curve { get { return curve; } }

        /// <summary>
        /// Curve of route.
        /// </summary>
        protected HelixCurve curve = new HelixCurve();

        /// <summary>
        /// Rebuild route.
        /// </summary>
        public override void Rebuild()
        {
            curve.top = top;
            curve.bottom = bottom;
            curve.altitude = altitude;
            curve.radian = radian;
            length = EvaluateLength(0.01f);
        }
    }
}