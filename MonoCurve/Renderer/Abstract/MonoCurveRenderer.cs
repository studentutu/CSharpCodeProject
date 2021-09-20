/*************************************************************************
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
        /// Detail length for renderer.
        /// </summary>
        [SerializeField]
        protected float segment = 0.25f;

        /// <summary>
        /// Segment length of mono curve.
        /// </summary>
        public float Segment
        {
            set { segment = value; }
            get { return segment; }
        }

        /// <summary>
        /// Renderer component.
        /// </summary>
        public abstract Renderer Renderer { get; }

        /// <summary>
        /// Reset component.
        /// </summary>
        protected virtual void Reset()
        {
            Rebuild(GetComponent<IMonoCurve>());
        }

        /// <summary>
        /// [MESSAGE] On mono curve rebuild.
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