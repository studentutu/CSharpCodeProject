/*************************************************************************
 *  Copyright (c) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIImage.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  10/24/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;
using UnityEngine.UI;

namespace MGS.UGUI
{
    /// <summary>
    /// UI image.
    /// </summary>
    public class UIImage : UICell<ImageOptions>
    {
        /// <summary>
        /// Image component.
        /// </summary>
        public Image image;

        /// <summary>
        /// Reset component.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();
            image = GetComponentInChildren<Image>(true);
        }

        /// <summary>
        /// On refresh image.
        /// </summary>
        /// <param name="options">Options to refresh image.</param>
        protected override void OnRefresh(ImageOptions options)
        {
            image.sprite = options.sprite;
        }
    }

    /// <summary>
    /// Options for image.
    /// </summary>
    [Serializable]
    public struct ImageOptions
    {
        /// <summary>
        /// Display sprite.
        /// </summary>
        public Sprite sprite;
    }
}