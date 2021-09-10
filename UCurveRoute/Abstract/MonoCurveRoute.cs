/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoCurveRoute.cs
 *  Description  :  Define route base on curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  2/28/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UCurve.Route
{
    /// <summary>
    /// Route base on curve.
    /// </summary>
    public abstract class MonoCurveRoute : MonoBehaviour, ICurveRoute
    {
        /// <summary>
        /// Length of route.
        /// </summary>
        public abstract float Length { get; }

        /// <summary>
        /// Curve for route.
        /// </summary>
        protected abstract ITimeCurve Curve { get; }

        /// <summary>
        /// Reset component.
        /// </summary>
        protected virtual void Reset()
        {
            Rebuild();
        }

        /// <summary>
        /// Awake component.
        /// </summary>
        protected virtual void Awake()
        {
            Rebuild();
        }

        /// <summary>
        /// Rebuild route.
        /// </summary>
        public abstract void Rebuild();

        /// <summary>
        /// Evaluate point on the route at time[0,1].
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual Vector3 Evaluate(float t)
        {
            return transform.TransformPoint(Curve.Evaluate(t));
        }

        /// <summary>
        /// Evaluate length of route.
        /// </summary>
        /// <param name="differ">Differentiation.</param>
        /// <returns></returns>
        protected virtual float EvaluateLength(float differ)
        {
            var length = 0f;
            var t = 0f;
            var p0 = Evaluate(t);
            while (t < 1.0f)
            {
                t = Mathf.Min(t + differ, 1.0f);
                var p1 = Evaluate(t);
                length += Vector3.Distance(p0, p1);
                p0 = p1;
            }
            return length;
        }
    }
}