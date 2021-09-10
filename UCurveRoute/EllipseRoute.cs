/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  EllipseRoute.cs
 *  Description  :  Define route base on ellipse curve.
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
    /// Route base on ellipse curve.
    /// </summary>
    public class EllipseRoute : MonoCurveRoute
    {
        /// <summary>
        /// Args of ellipse route.
        /// </summary>
        public EllipseArgs args = new EllipseArgs(1, 2);

        /// <summary>
        /// radian of ellipse route.
        /// </summary>
        public float radian = Mathf.PI * 2;

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
        protected EllipseCurve curve = new EllipseCurve();

        /// <summary>
        /// Rebuild route.
        /// </summary>
        public override void Rebuild()
        {
            curve.args = args;
            length = EvaluateLength();
        }

        /// <summary>
        /// Evaluate point on the route at time[0,1].
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public override Vector3 Evaluate(float t)
        {
            return base.Evaluate(radian * t);
        }

        /// <summary>
        /// Evaluate length of route.
        /// </summary>
        /// <returns></returns>
        protected virtual float EvaluateLength()
        {
            var ratio = Mathf.Abs(radian) / (Mathf.PI * 2);
            if (args.semiMinorAxis == 0 || args.semiMajorAxis == 0)
            {
                return 2 * Mathf.Abs(args.semiMinorAxis + args.semiMajorAxis) * ratio;
            }

            var minor = Mathf.Abs(args.semiMinorAxis);
            var major = Mathf.Abs(args.semiMajorAxis);
            var a = Mathf.Max(minor, major);
            var b = Mathf.Min(minor, major);
            return (2 * Mathf.PI * b + 4 * (a - b)) * ratio;
        }
    }
}