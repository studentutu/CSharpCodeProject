/*************************************************************************
 *  Copyright (c) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIButton.cs
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
    /// UI button.
    /// </summary>
    public class UIButton : UICell<ButtonOptions>
    {
        /// <summary>
        /// Button component.
        /// </summary>
        public Button button;

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
            button = GetComponentInChildren<Button>(true);
            text = button?.GetComponentInChildren<Text>(true);
        }

        /// <summary>
        /// On refresh image.
        /// </summary>
        /// <param name="options">Options to refresh button.</param>
        protected override void OnRefresh(ButtonOptions options)
        {
            text.text = options.text;
        }
    }

    /// <summary>
    /// Options for button.
    /// </summary>
    [Serializable]
    public struct ButtonOptions
    {
        /// <summary>
        /// Display text.
        /// </summary>
        public string text;
    }
}