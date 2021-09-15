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
        [SerializeField]
        protected LineRenderer lineRenderer;

        /// <summary>
        /// Renderer component.
        /// </summary>
        public override Renderer Renderer { get { return lineRenderer; } }

        /// <summary>
        /// Reset component.
        /// </summary>
        protected virtual void Reset()
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        /// <summary>
        /// Rebuild renderer base curve.
        /// </summary>
        /// <param name="curve"></param>
        public override void Rebuild(IMonoCurve curve)
        {
            CurveRendererUtility.Rebuild(lineRenderer, curve, detail);
        }
    }
}