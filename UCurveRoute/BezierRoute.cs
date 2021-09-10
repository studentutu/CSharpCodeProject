/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  BezierRoute.cs
 *  Description  :  Define route base on cubic bezier curve.
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
    /// Route base on cubic bezier curve.
    /// </summary>
    public class BezierRoute : MonoCurveRoute
    {
        #region Field and Property
        /// <summary>
        /// Anchor points of route curve.
        /// </summary>
        [SerializeField]
        [HideInInspector]
        protected BezierAnchor anchor = new BezierAnchor(
            new Vector3(1, 1, 1),
            new Vector3(3, 1, 3),
            new Vector3(1, 1, 2),
            new Vector3(3, 1, 2));

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
        protected BezierCurve curve = new BezierCurve();
        #endregion

        #region Public Method
        /// <summary>
        /// Rebuild route.
        /// </summary>
        public override void Rebuild()
        {
            curve.anchor = anchor;
            length = EvaluateLength(0.01f);
        }
        #endregion
    }
}