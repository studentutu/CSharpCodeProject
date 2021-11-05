/*************************************************************************
 *  Copyright (c) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIPointerTrigger.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/29/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.EventSystems;

namespace MGS.UGUI
{
    /// <summary>
    /// UI Pointer-Trigger.
    /// </summary>
    public class UIPointerTrigger : UITrigger, IPointerEnterHandler, IPointerExitHandler
    {
        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected UIPanel panel;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventData"></param>
        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            panel.gameObject.SetActive(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventData"></param>
        public virtual void OnPointerExit(PointerEventData eventData)
        {
            panel.gameObject.SetActive(false);
        }
    }
}