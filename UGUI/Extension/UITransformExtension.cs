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
        /// <summary>
        /// Set position of RectTransform.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="uiCamera"></param>
        /// <param name="screenPoint"></param>
        /// <param name="offset"></param>
        public static void SetPosition(this RectTransform rect, Camera uiCamera, Vector2 screenPoint, Vector2 offset)
        {
            var localPoint = Vector2.zero;
            var parentRect = rect.parent as RectTransform;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRect, screenPoint, uiCamera, out localPoint);
            localPoint += offset;
            rect.localPosition = localPoint;
        }

        /// <summary>
        /// Set position of RectTransform.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="uiCamera"></param>
        /// <param name="screenPoint"></param>
        /// <param name="offset"></param>
        /// <param name="anchor"></param>
        /// <param name="keepPivot"></param>
        public static void SetPosition(this RectTransform rect, Camera uiCamera, Vector2 screenPoint, Vector2 offset,
            TextAnchor anchor = TextAnchor.MiddleCenter, bool keepPivot = false)
        {
            var pivot = Text.GetTextAnchorPivot(anchor);
            if (keepPivot)
            {
                var pivotOffset = rect.pivot - pivot;
                offset += new Vector2(rect.rect.width * pivotOffset.x, rect.rect.height * pivotOffset.y);
            }
            else
            {
                rect.pivot = pivot;
            }
            SetPosition(rect, uiCamera, screenPoint, offset);
        }
    }
}