/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CurveRendererUtility.cs
 *  Description  :  Utility for curve renderer.
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
    /// Utility for curve renderer.
    /// </summary>
    public sealed class CurveRendererUtility
    {
        /// <summary>
        /// Rebuild renderer base mono curve.
        /// </summary>
        /// <param name="renderer"></param>
        /// <param name="curve"></param>
        /// <param name="detail"></param>
        public static void Rebuild(LineRenderer renderer, IMonoCurve curve, RenderDetail detail)
        {
            var minDiffer = curve.Length / detail.max;
            var maxDiffer = curve.Length / detail.min;

            var normalDiffer = 1.0f / (curve.Length * detail.normal);
            var differ = Mathf.Clamp(normalDiffer, minDiffer, maxDiffer);
            var posCount = (int)(curve.Length / differ) + 1;

            renderer.SetVertexCount(posCount);
            for (int i = 0; i < posCount; i++)
            {
                var pos = curve.Evaluate(i * differ);
                renderer.SetPosition(i, pos);
            }
        }
    }
}