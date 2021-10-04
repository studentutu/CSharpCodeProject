/*************************************************************************
 *  Copyright (C) 2017-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SpriteAnimation.cs
 *  Description  :  Define sequence frames animation base on
 *                  SpriteRenderer.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UAnimation
{
    /// <summary>
    /// Sequence frames animation base on SpriteRenderer.
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteAnimation : SpriteFrameAnimation
    {
        #region Field and Property
        /// <summary>
        /// SpriteRenderer of animation.
        /// </summary>
        protected SpriteRenderer sRenderer;
        #endregion

        #region Protected Method
        /// <summary>
        /// Awake animation.
        /// </summary>
        protected virtual void Awake()
        {
            sRenderer = GetComponent<SpriteRenderer>();
        }

        /// <summary>
        /// Set current frame to renderer.
        /// </summary>
        /// <param name="index">Index of frame.</param>
        protected override void SetFrame(int index)
        {
            sRenderer.sprite = frames[index];
        }
        #endregion
    }
}