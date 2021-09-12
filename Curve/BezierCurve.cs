/*************************************************************************
 *  Copyright (c) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  BezierCurve.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/18/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;

namespace MGS.Curve
{
    /// <summary>
    /// Cubic bezier curve.
    /// </summary>
    public class BezierCurve : ITimeCurve
    {
        #region
        /// <summary>
        /// Anchor settings of curve.
        /// </summary>
        public BezierAnchor anchor;
        #endregion

        #region
        /// <summary>
        /// Constructor.
        /// </summary>
        public BezierCurve() { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="anchor">Anchor settings of curve.</param>
        public BezierCurve(BezierAnchor anchor)
        {
            this.anchor = anchor;
        }

        /// <summary>
        /// Evaluate the curve at t.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public Vector3 Evaluate(float t)
        {
            return Evaluate(anchor, t);
        }
        #endregion

        #region
        /// <summary>
        /// Evaluate the curve at anchor and time.
        /// </summary>
        /// <param name="anchor"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Vector3 Evaluate(BezierAnchor anchor, float t)
        {
            return Mathf.Pow(1 - t, 3) * anchor.from + 3 * t * Mathf.Pow(1 - t, 2) * anchor.frTangent +
                3 * (1 - t) * Mathf.Pow(t, 2) * anchor.toTangent + Mathf.Pow(t, 3) * anchor.to;
        }
        #endregion
    }

    /// <summary>
    /// Anchor settings of cubic bezier curve.
    /// </summary>
    [Serializable]
    public struct BezierAnchor
    {
        #region
        /// <summary>
        /// From point of anchor.
        /// </summary>
        public Vector3 from;

        /// <summary>
        /// To point of anchor.
        /// </summary>
        public Vector3 to;

        /// <summary>
        /// From tangent point of anchor.
        /// </summary>
        public Vector3 frTangent;

        /// <summary>
        /// To tangent point of anchor.
        /// </summary>
        public Vector3 toTangent;
        #endregion

        #region
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="from">From point of anchor.</param>
        /// <param name="to">To point of anchor.</param>
        /// <param name="frTangent">From tangent point of anchor.</param>
        /// <param name="toTangent">To tangent point of anchor.</param>
        public BezierAnchor(Vector3 from, Vector3 to, Vector3 frTangent, Vector3 toTangent)
        {
            this.from = from;
            this.to = to;
            this.frTangent = frTangent;
            this.toTangent = toTangent;
        }
        #endregion
    }
}