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
using UnityEngine.UI;

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
        /// <param name="worldPos"></param>
        /// <param name="offset"></param>
        /// <param name="alignment"></param>
        public void SetPosition(Vector3 worldPos, Vector2 offset, TextAnchor alignment = TextAnchor.MiddleCenter)
        {
            //Set pivot.
            var originPivot = RectTrans.pivot;
            var tempPivot = Text.GetTextAnchorPivot(alignment);
            RectTrans.pivot = tempPivot;

            //Set position and offset.
            transform.position = worldPos;
            var anchorPos = RectTrans.anchoredPosition;
            anchorPos += offset;
            RectTrans.anchoredPosition = anchorPos;

            //Revert pivot.
            RectTrans.pivot = originPivot;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="screenPos"></param>
        /// <param name="offset"></param>
        /// <param name="alignment"></param>
        public void SetPosition(Camera camera, Vector3 screenPos, Vector2 offset, TextAnchor alignment = TextAnchor.MiddleCenter)
        {
            //Convert to world position.
            var worldPos = camera.ScreenToWorldPoint(screenPos);
            SetPosition(worldPos, offset, alignment);
        }
    }
}