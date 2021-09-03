/*************************************************************************
 *  Copyright © 2017-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  HelixCurve.cs
 *  Description  :  Define helix curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/14/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UCurve
{
    /// <summary>
    /// Helix curve.
    /// </summary>
    public class HelixCurve : ITimeCurve
    {
        #region
        /// <summary>
        /// Args of curve lerp from.
        /// </summary>
        public EllipseArgs top;

        /// <summary>
        /// Args of curve lerp to.
        /// </summary>
        public EllipseArgs bottom;

        /// <summary>
        /// Altitude from bottom to top.
        /// </summary>
        public float altitude;

        /// <summary>
        /// Around radian.
        /// </summary>
        public float radian;

        /// <summary>
        /// Constructor.
        /// </summary>
        public HelixCurve() { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="top">Args of curve lerp from.</param>
        /// <param name="bottom">Args of curve lerp to.</param>
        public HelixCurve(EllipseArgs top, EllipseArgs bottom)
        {
            this.top = top;
            this.bottom = bottom;
        }

        /// <summary>
        /// Evaluate the curve at t.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public Vector3 Evaluate(float t)
        {
            var r = radian * t;
            return (Vector3)Evaluate(top, bottom, r, t) + Vector3.forward * altitude * t;
        }
        #endregion

        #region
        /// <summary>
        /// Evaluate the curve at radian and t.
        /// </summary>
        /// <param name="fr"></param>
        /// <param name="to"></param>
        /// <param name="r"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Vector2 Evaluate(EllipseArgs fr, EllipseArgs to, float r, float t)
        {
            var p0 = EllipseCurve.Evaluate(fr, r);
            var p1 = EllipseCurve.Evaluate(to, r);
            return Vector2.Lerp(p0, p1, t);
        }
        #endregion
    }
}