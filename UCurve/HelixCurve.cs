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
        public EllipseArgs Top { set; get; }

        /// <summary>
        /// Args of curve lerp to.
        /// </summary>
        public EllipseArgs Bottom { set; get; }

        /// <summary>
        /// Altitude from bottom to top.
        /// </summary>
        public float Altitude { set; get; }

        /// <summary>
        /// Around radian.
        /// </summary>
        public float Radian { set; get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public HelixCurve()
        {
            Top = new EllipseArgs();
            Bottom = new EllipseArgs();
            Radian = Mathf.PI * 2;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="from">Args of curve lerp from.</param>
        /// <param name="to">Args of curve lerp to.</param>
        public HelixCurve(EllipseArgs from, EllipseArgs to)
        {
            Top = from;
            Bottom = to;
        }

        /// <summary>
        /// Evaluate the curve at t.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public Vector3 Evaluate(float t)
        {
            var r = Radian * t;
            return (Vector3)Evaluate(Top, Bottom, r, t) + Vector3.forward * Altitude * t;
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