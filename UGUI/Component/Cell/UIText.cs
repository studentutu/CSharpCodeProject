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
using UnityEngine.UI;

namespace MGS.UGUI
{
    /// <summary>
    /// UI text.
    /// </summary>
    public class UIText : UICell<TextOptions>
    {
        /// <summary>
        /// Text component.
        /// </summary>
        public Text text;

        /// <summary>
        /// Reset component.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();
            text = GetComponentInChildren<Text>(true);
        }

        /// <summary>
        /// On refresh text.
        /// </summary>
        /// <param name="options">Options to refresh text.</param>
        protected override void OnRefresh(TextOptions options)
        {
            text.text = options.text;
        }
    }

    /// <summary>
    /// Options for text.
    /// </summary>
    [Serializable]
    public struct TextOptions
    {
        /// <summary>
        /// Display text.
        /// </summary>
        public string text;
    }
}