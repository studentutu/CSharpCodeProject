﻿/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoCurveRenderer.cs
 *  Description  :  Renderer for mono curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  9/15/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Curve
{
    /// <summary>
    /// Renderer for mono curve.
    /// </summary>
    [ExecuteInEditMode]
    public abstract class MonoCurveRenderer : MonoBehaviour, IMonoCurveRenderer
    {
        /// <summary>
        /// Detail settings of render.
        /// </summary>
        [SerializeField]
        protected RenderDetail detail = new RenderDetail(8, 12, 512);

        /// <summary>
        /// Detail settings of render.
        /// </summary>
        public RenderDetail Detail
        {
            set { detail = value; }
            get { return detail; }
        }

        /// <summary>
        /// Renderer component.
        /// </summary>
        public abstract Renderer Renderer { get; }

        /// <summary>
        /// On mono curve rebuild (Message from mono curve).
        /// </summary>
        /// <param name="curve"></param>
        private void OnMonoCurveRebuild(IMonoCurve curve)
        {
            Rebuild(curve);
        }

        /// <summary>
        /// Rebuild renderer base curve.
        /// </summary>
        /// <param name="curve"></param>
        public abstract void Rebuild(IMonoCurve curve);
    }
}