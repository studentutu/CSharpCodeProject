/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoCurveLineRenderer.cs
 *  Description  :  Line renderer for mono curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  9/16/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Curve
{
    /// <summary>
    /// Line renderer for mono curve.
    /// </summary>
    [RequireComponent(typeof(LineRenderer))]
    public class MonoCurveLineRenderer : MonoCurveRenderer
    {
        /// <summary>
        /// Renderer component.
        /// </summary>
        [HideInInspector]
        [SerializeField]
        protected LineRenderer lineRenderer;

        /// <summary>
        /// Renderer component.
        /// </summary>
        public override Renderer Renderer { get { return lineRenderer; } }

        /// <summary>
        /// Reset component.
        /// </summary>
        protected override void Reset()
        {
            lineRenderer = GetComponent<LineRenderer>();
            base.Reset();
        }

        /// <summary>
        /// Rebuild renderer base curve.
        /// </summary>
        /// <param name="curve"></param>
        public override void Rebuild(IMonoCurve curve)
        {
            if (curve == null)
            {
                lineRenderer.SetVertexCount(0);
                return;
            }

            var vertexCount = MonoCurveUtility.GetDetailCount(curve, detail, out float differ) + 1;
            lineRenderer.SetVertexCount(vertexCount);
            for (int i = 0; i < vertexCount; i++)
            {
                var pos = curve.Evaluate(i * differ);
                lineRenderer.SetPosition(i, pos);
            }
        }
    }
}