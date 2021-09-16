/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoBezierCurve.cs
 *  Description  :  Define mono curve base on cubic bezier curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  2/28/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Curve
{
    /// <summary>
    /// Mono curve base on cubic bezier curve.
    /// </summary>
    public class MonoBezierCurve : MonoCurve
    {
        /// <summary>
        /// Anchor points of mono curve.
        /// </summary>
        [SerializeField]
        [HideInInspector]
        protected BezierAnchor anchor = new BezierAnchor(
            new Vector3(1, 1),
            new Vector3(3, 3),
            new Vector3(0, 1),
            new Vector3(0, -1));

        /// <summary>
        /// From point of anchor.
        /// </summary>
        public Vector3 From
        {
            set { anchor.from = transform.InverseTransformPoint(value); }
            get { return transform.TransformPoint(anchor.from); }
        }

        /// <summary>
        /// To point of anchor.
        /// </summary>
        public Vector3 To
        {
            set { anchor.to = transform.InverseTransformPoint(value); }
            get { return transform.TransformPoint(anchor.to); }
        }

        /// <summary>
        /// From tangent vector based on point.
        /// </summary>
        public Vector3 FrTangent
        {
            set { anchor.frTangent = transform.InverseTransformVector(value); }
            get { return transform.TransformVector(anchor.frTangent); }
        }

        /// <summary>
        /// To tangent vector based on point.
        /// </summary>
        public Vector3 ToTangent
        {
            set { anchor.toTangent = transform.InverseTransformVector(value); }
            get { return transform.TransformVector(anchor.toTangent); }
        }

        /// <summary>
        /// Mono curve is close?
        /// </summary>
        public bool IsClose
        {
            get { return anchor.from == anchor.to; }
        }

        /// <summary>
        /// Length of mono curve.
        /// </summary>
        public override float Length { get { return length; } }

        /// <summary>
        /// Length of mono curve.
        /// </summary>
        protected float length;

        /// <summary>
        /// Curve for mono curve.
        /// </summary>
        protected override ITimeCurve Curve { get { return curve; } }

        /// <summary>
        /// Curve of mono curve.
        /// </summary>
        protected BezierCurve curve = new BezierCurve();

        /// <summary>
        /// Rebuild mono curve.
        /// </summary>
        public override void Rebuild()
        {
            curve.anchor = anchor;
            curve.anchor.frTangent = anchor.from + anchor.frTangent;
            curve.anchor.toTangent = anchor.to + anchor.toTangent;
            length = EvaluateLength();
            base.Rebuild();
        }
    }
}