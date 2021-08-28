/*************************************************************************
 *  Copyright (c) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIPositioner.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/21/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UGUI
{
    /// <summary>
    /// UI positioner.
    /// </summary>
    public class UIPositioner : UIHandler
    {
        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected Camera uiCamera;

        /// <summary>
        /// 
        /// </summary>
        protected override void Reset()
        {
            base.Reset();
            var canvas = transform.root.GetComponentInChildren<Canvas>();
            if (canvas != null && canvas.renderMode != RenderMode.ScreenSpaceOverlay)
            {
                uiCamera = canvas.worldCamera;
            }
        }

        /// <summary>
        /// Set position of RectTransform.
        /// </summary>
        /// <param name="screenPoint"></param>
        /// <param name="offset"></param>
        public void SetPosition(Vector2 screenPoint, Vector2 offset)
        {
            Rect.SetPosition(uiCamera, screenPoint, offset);
        }

        /// <summary>
        /// Set position of RectTransform.
        /// </summary>
        /// <param name="screenPoint"></param>
        /// <param name="offset"></param>
        /// <param name="anchor"></param>
        /// <param name="keepPivot"></param>
        public void SetPosition(Vector2 screenPoint, Vector2 offset,
            TextAnchor anchor = TextAnchor.MiddleCenter, bool keepPivot = false)
        {
            Rect.SetPosition(uiCamera, screenPoint, offset, anchor, keepPivot);
        }
    }
}