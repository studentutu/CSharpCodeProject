/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SinRoute.cs
 *  Description  :  Define route base on sin curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/21/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UCurve.Route
{
    /// <summary>
    /// Route base on sin curve.
    /// </summary>
    public class SinRoute : MonoCurveRoute
    {
        /// <summary>
        /// Args of sin route.
        /// </summary>
        public SinArgs args = new SinArgs(1, 1, 0);

        /// <summary>
        /// radian of sin route.
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
        protected SinCurve curve = new SinCurve();

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
            if (args.angular == 0)
            {
                return radian;
            }

            var halfPI = Mathf.PI * 0.5f;
            var angularAbs = Mathf.Abs(args.angular);
            var piece = Vector2.Distance(Vector2.zero, new Vector2(halfPI / angularAbs, args.amplitude));
            var pieces = piece * angularAbs;
            var segments = Mathf.RoundToInt(radian / halfPI);
            return pieces * segments;
        }
    }
}