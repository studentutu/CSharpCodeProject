/*************************************************************************
 *  Copyright (c) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIComponent.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/6/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.EventSystems;

namespace MGS.UGUI
{
    /// <summary>
    /// UI component.
    /// </summary>
    public abstract class UIComponent : UIBehaviour
    {
        /// <summary>
        /// RectTransform component.
        /// </summary>
        public RectTransform Rect
        {
            get { return transform as RectTransform; }
        }
    }
}