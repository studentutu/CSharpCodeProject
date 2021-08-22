/*************************************************************************
 *  Copyright (c) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIBehaviourExtension.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/22/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MGS.UGUI
{
    /// <summary>
    /// UI behaviour extension.
    /// </summary>
    public static class UIBehaviourExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ui"></param>
        /// <returns></returns>
        public static T RequireComponent<T>(this UIBehaviour ui) where T : Component
        {
            var mpnt = ui.GetComponent<T>();
            if (mpnt == null)
            {
                mpnt = ui.gameObject.AddComponent<T>();
            }
            return mpnt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ui"></param>
        /// <returns></returns>
        public static UIPointerListener RequirePointerListener(this UIBehaviour ui)
        {
            return RequireComponent<UIPointerListener>(ui);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ui"></param>
        /// <returns></returns>
        public static UIDragListener RequireDragListener(this UIBehaviour ui)
        {
            return RequireComponent<UIDragListener>(ui);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ui"></param>
        /// <returns></returns>
        public static UISelectListener RequireSelectListener(this UIBehaviour ui)
        {
            return RequireComponent<UISelectListener>(ui);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ui"></param>
        /// <param name="overrideSorting"></param>
        /// <param name="sortingOrder"></param>
        public static void RequireCanvasRaycasterGroup(this UIBehaviour ui, bool overrideSorting = true, int sortingOrder = 3000)
        {
            var canvas = RequireComponent<Canvas>(ui);
            canvas.overrideSorting = overrideSorting; //Do not working in Unity 5.6?
            canvas.sortingOrder = sortingOrder;

            RequireComponent<GraphicRaycaster>(ui);
            RequireComponent<CanvasGroup>(ui);
        }
    }
}