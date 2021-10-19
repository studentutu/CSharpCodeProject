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
        protected Camera uiCamera;

        /// <summary>
        /// 
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            var canvas = transform.root.GetComponentInChildren<Canvas>(true);
            if (canvas != null && canvas.renderMode != RenderMode.ScreenSpaceOverlay)
            {
                uiCamera = canvas.worldCamera;
            }
        }

        #region Screen To UI Local Position
        /// <summary>
        /// Get local position in parent RectTransform.
        /// </summary>
        /// <param name="screenPoint"></param>
        public Vector2 GetLocalPosition(Vector2 screenPoint)
        {
            return (transform as RectTransform).GetLocalPosition(uiCamera, screenPoint);
        }

        /// <summary>
        /// Get local position in parent RectTransform.
        /// </summary>
        /// <param name="screenPoint"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public Vector2 GetLocalPosition(Vector2 screenPoint, Vector2 offset)
        {
            return (transform as RectTransform).GetLocalPosition(uiCamera, screenPoint, offset);
        }

        /// <summary>
        /// Get local position in parent RectTransform.
        /// </summary>
        /// <param name="screenPoint"></param>
        /// <param name="offset"></param>
        /// <param name="anchor"></param>
        /// <returns></returns>
        public Vector2 GetLocalPosition(Vector2 screenPoint, Vector2 offset, TextAnchor anchor)
        {
            return (transform as RectTransform).GetLocalPosition(uiCamera, screenPoint, offset, anchor);
        }

        /// <summary>
        /// Set position in parent RectTransform.
        /// </summary>
        /// <param name="screenPoint"></param>
        public void SetPosition(Vector2 screenPoint)
        {
            (transform as RectTransform).SetPosition(uiCamera, screenPoint);
        }

        /// <summary>
        /// Set position in parent RectTransform.
        /// </summary>
        /// <param name="screenPoint"></param>
        /// <param name="offset"></param>
        public void SetPosition(Vector2 screenPoint, Vector2 offset)
        {
            (transform as RectTransform).SetPosition(uiCamera, screenPoint, offset);
        }

        /// <summary>
        /// Set position in parent RectTransform.
        /// </summary>
        /// <param name="screenPoint"></param>
        /// <param name="offset"></param>
        /// <param name="anchor"></param>
        public void SetPosition(Vector2 screenPoint, Vector2 offset, TextAnchor anchor)
        {
            (transform as RectTransform).SetPosition(uiCamera, screenPoint, offset, anchor);
        }
        #endregion

        #region Clamp Position In Parent
        /// <summary>
        /// Get local position of RectTransform clamp in paren.
        /// </summary>
        /// <param name="padding"></param>
        /// <returns></returns>
        public Vector3 GetLocalPositionClamp(RectOffset padding)
        {
            return (transform as RectTransform).GetLocalPositionClamp(padding);
        }

        /// <summary>
        /// Get local position of RectTransform clamp in paren.
        /// </summary>
        /// <param name="localPoint"></param>
        /// <param name="padding"></param>
        /// <returns></returns>
        public Vector3 GetLocalPositionClamp(Vector3 localPoint, RectOffset padding)
        {
            return (transform as RectTransform).GetLocalPositionClamp(localPoint, padding);
        }

        /// <summary>
        /// Set position of RectTransform clamp in paren.
        /// </summary>
        /// <param name="padding"></param>
        public void SetPositionClamp(RectOffset padding)
        {
            (transform as RectTransform).SetPositionClamp(padding);
        }

        /// <summary>
        /// Set position of RectTransform clamp in paren.
        /// </summary>
        /// <param name="localPoint"></param>
        /// <param name="padding"></param>
        public void SetPositionClamp(Vector3 localPoint, RectOffset padding)
        {
            (transform as RectTransform).SetPositionClamp(localPoint, padding);
        }
        #endregion
    }
}