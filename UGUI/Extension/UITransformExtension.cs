/*************************************************************************
 *  Copyright (c) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UITransformExtension.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/27/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace MGS.UGUI
{
    /// <summary>
    /// Extension UI transform.
    /// </summary>
    public static class UITransformExtension
    {
        #region Screen To UI Local Position
        /// <summary>
        /// Get local position in parent RectTransform.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="uiCamera"></param>
        /// <param name="screenPoint"></param>
        public static Vector2 GetLocalPosition(this RectTransform rect, Camera uiCamera, Vector2 screenPoint)
        {
            var localPoint = Vector2.zero;
            var parentRect = rect.parent as RectTransform;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRect, screenPoint, uiCamera, out localPoint);
            return localPoint;
        }

        /// <summary>
        /// Get local position in parent RectTransform.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="uiCamera"></param>
        /// <param name="screenPoint"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static Vector2 GetLocalPosition(this RectTransform rect, Camera uiCamera, Vector2 screenPoint, Vector2 offset)
        {
            return GetLocalPosition(rect, uiCamera, screenPoint) + offset;
        }

        /// <summary>
        /// Get local position in parent RectTransform.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="uiCamera"></param>
        /// <param name="screenPoint"></param>
        /// <param name="offset"></param>
        /// <param name="anchor"></param>
        /// <returns></returns>
        public static Vector2 GetLocalPosition(this RectTransform rect, Camera uiCamera, Vector2 screenPoint, Vector2 offset, TextAnchor anchor)
        {
            var pivot = Text.GetTextAnchorPivot(anchor);
            var pivotOffset = rect.pivot - pivot;
            offset += new Vector2(rect.rect.width * pivotOffset.x, rect.rect.height * pivotOffset.y);
            return GetLocalPosition(rect, uiCamera, screenPoint, offset);
        }

        /// <summary>
        /// Set position in parent RectTransform.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="uiCamera"></param>
        /// <param name="screenPoint"></param>
        public static void SetPosition(this RectTransform rect, Camera uiCamera, Vector2 screenPoint)
        {
            rect.localPosition = GetLocalPosition(rect, uiCamera, screenPoint);
        }

        /// <summary>
        /// Set position in parent RectTransform.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="uiCamera"></param>
        /// <param name="screenPoint"></param>
        /// <param name="offset"></param>
        public static void SetPosition(this RectTransform rect, Camera uiCamera, Vector2 screenPoint, Vector2 offset)
        {
            rect.localPosition = GetLocalPosition(rect, uiCamera, screenPoint, offset);
        }

        /// <summary>
        /// Set position in parent RectTransform.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="uiCamera"></param>
        /// <param name="screenPoint"></param>
        /// <param name="offset"></param>
        /// <param name="anchor"></param>
        public static void SetPosition(this RectTransform rect, Camera uiCamera, Vector2 screenPoint, Vector2 offset, TextAnchor anchor)
        {
            rect.localPosition = GetLocalPosition(rect, uiCamera, screenPoint, offset, anchor);
        }
        #endregion

        #region Clamp Position In Parent
        /// <summary>
        /// Get local position of RectTransform clamp in paren.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="padding"></param>
        /// <returns></returns>
        public static Vector3 GetLocalPositionClamp(this RectTransform rect, RectOffset padding)
        {
            return GetLocalPositionClamp(rect, rect.localPosition, padding);
        }

        /// <summary>
        /// Get local position of RectTransform clamp in paren.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="localPoint"></param>
        /// <param name="padding"></param>
        /// <returns></returns>
        public static Vector3 GetLocalPositionClamp(this RectTransform rect, Vector3 localPoint, RectOffset padding)
        {
            var parentRect = rect.parent as RectTransform;
            localPoint.x = Mathf.Clamp(localPoint.x, -parentRect.rect.width * parentRect.pivot.x + rect.rect.width * rect.pivot.x + padding.left, parentRect.rect.width * (1 - parentRect.pivot.x) - rect.rect.width * (1 - rect.pivot.x) - padding.right);
            localPoint.y = Mathf.Clamp(localPoint.y, -parentRect.rect.height * parentRect.pivot.y + rect.rect.height * rect.pivot.y + padding.bottom, parentRect.rect.height * (1 - parentRect.pivot.y) - rect.rect.height * (1 - rect.pivot.y) - padding.top);
            return localPoint;
        }

        /// <summary>
        /// Set position of RectTransform clamp in paren.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="padding"></param>
        public static void SetPositionClamp(this RectTransform rect, RectOffset padding)
        {
            rect.localPosition = GetLocalPositionClamp(rect, padding);
        }

        /// <summary>
        /// Set position of RectTransform clamp in paren.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="localPoint"></param>
        /// <param name="padding"></param>
        public static void SetPositionClamp(this RectTransform rect, Vector3 localPoint, RectOffset padding)
        {
            rect.localPosition = GetLocalPositionClamp(rect, localPoint, padding);
        }
        #endregion
    }
}