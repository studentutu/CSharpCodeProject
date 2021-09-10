/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  HermiteRoute.cs
 *  Description  :  Define curve route base on anchors.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  2/28/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.UCurve.Route
{
    /// <summary>
    /// Route base on anchors.
    /// </summary>
    public class HermiteRoute : MonoCurveRoute
    {
        /// <summary>
        /// Route curve is close?
        /// </summary>
        public bool close = false;

        /// <summary>
        /// Route curve is smooth?
        /// </summary>
        public bool smooth = true;

        /// <summary>
        /// Anchors of route curve.
        /// </summary>
        [SerializeField]
        [HideInInspector]
        protected List<Vector3> anchors = new List<Vector3>()
        {
            new Vector3(1, 0, 1),
            new Vector3(1, 1, 2),
            new Vector3(3, 1, 2),
            new Vector3(3, 0, 3)
        };

        /// <summary>
        /// Count of route curve anchors.
        /// </summary>
        public int AnchorsCount { get { return anchors.Count; } }

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
        protected HermiteCurve curve = new HermiteCurve();

        /// <summary>
        /// Rebuild route.
        /// </summary>
        public override void Rebuild()
        {
            curve.ClearFrames();
            if (anchors.Count > 0)
            {
                var time = 0f;
                var last = anchors[0];
                foreach (var anchor in anchors)
                {
                    time += Vector3.Distance(last, anchor);
                    curve.AddFrame(time, anchor);
                    last = anchor;
                }

                if (close)
                {
                    time += Vector3.Distance(last, anchors[0]);
                    curve.AddFrame(time, anchors[0]);
                }

                if (smooth)
                {
                    curve.SmoothTangents();
                }
            }
            length = EvaluateLength(0.01f);
        }

        /// <summary>
        /// Evaluate point on the route at time[0,1].
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public override Vector3 Evaluate(float t)
        {
            if (curve.FramesCount > 0)
            {
                return base.Evaluate(curve[curve.FramesCount - 1].time * t);
            }
            return Vector3.zero;
        }

        /// <summary>
        /// Add anchor item.
        /// </summary>
        /// <param name="anchor">Anchor item.</param>
        public void AddAnchor(Vector3 anchor)
        {
            anchors.Add(transform.InverseTransformPoint(anchor));
        }

        /// <summary>
        /// Insert Anchor item at index.
        /// </summary>
        /// <param name="index">Index of anchor.</param>
        /// <param name="anchor">Anchor item.</param>
        public void InsertAnchor(int index, Vector3 anchor)
        {
            anchors.Insert(index, transform.InverseTransformPoint(anchor));
        }

        /// <summary>
        /// Set the anchor item at index.
        /// </summary>
        /// <param name="index">Index of anchor.</param>
        /// <param name="anchor">Anchor item.</param>
        public void SetAnchor(int index, Vector3 anchor)
        {
            anchors[index] = transform.InverseTransformPoint(anchor);
        }

        /// <summary>
        /// Get the anchor item at index.
        /// </summary>
        /// <param name="index">Anchor index.</param>
        /// <returns>Anchor item.</returns>
        public Vector3 GetAnchor(int index)
        {
            return transform.TransformPoint(anchors[index]);
        }

        /// <summary>
        /// Remove the anchor item.
        /// </summary>
        /// <param name="anchor">Anchor item.</param>
        public void RemoveAnchor(Vector3 anchor)
        {
            anchors.Remove(anchor);
        }

        /// <summary>
        /// Remove the anchor item at index.
        /// </summary>
        /// <param name="index">Anchor index.</param>
        public void RemoveAnchor(int index)
        {
            anchors.RemoveAt(index);
        }

        /// <summary>
        /// Clear all anchor items.
        /// </summary>
        public void ClearAnchors()
        {
            anchors.Clear();
        }
    }
}