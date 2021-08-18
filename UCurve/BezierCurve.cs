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

namespace MGS.UCurve
{
    /// <summary>
    /// Cubic bezier curve.
    /// </summary>
    public class BezierCurve : IKeyCurve
    {
        #region
        /// <summary>
        /// Anchor settings of curve.
        /// </summary>
        public BezierAnchor Anchor { set; get; }
        #endregion

        #region
        /// <summary>
        /// Constructor.
        /// </summary>
        public BezierCurve()
        {
            Anchor = new BezierAnchor();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="anchor">Anchor settings of curve.</param>
        public BezierCurve(BezierAnchor anchor)
        {
            Anchor = anchor;
        }

        /// <summary>
        /// Evaluate the curve at k.
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public Vector3 Evaluate(float k)
        {
            return Evaluate(Anchor, k);
        }
        #endregion

        #region
        /// <summary>
        /// Evaluate the curve at anchor and key.
        /// </summary>
        /// <param name="anchor"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static Vector3 Evaluate(BezierAnchor anchor, float k)
        {
            return Mathf.Pow(1 - k, 3) * anchor.from + 3 * k * Mathf.Pow(1 - k, 2) * anchor.inTangent +
                3 * (1 - k) * Mathf.Pow(k, 2) * anchor.outTangent + Mathf.Pow(k, 3) * anchor.to;
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
        /// Start point.
        /// </summary>
        public Vector3 from;

        /// <summary>
        /// End point.
        /// </summary>
        public Vector3 to;

        /// <summary>
        /// In tangent.
        /// </summary>
        public Vector3 inTangent;

        /// <summary>
        /// Out tangent.
        /// </summary>
        public Vector3 outTangent;
        #endregion

        #region
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="from">Start point.</param>
        /// <param name="to">End point.</param>
        /// <param name="inTangent">In tangent.</param>
        /// <param name="outTangent">Out tangent.</param>
        public BezierAnchor(Vector3 from, Vector3 to, Vector3 inTangent, Vector3 outTangent)
        {
            this.from = from;
            this.to = to;
            this.inTangent = inTangent;
            this.outTangent = outTangent;
        }
        #endregion
    }
}