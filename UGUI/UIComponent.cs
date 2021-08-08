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

using UnityEngine.EventSystems;

namespace MGS.UGUI
{
    /// <summary>
    /// UI component.
    /// </summary>
    public abstract class UIComponent : UIBehaviour
    {
        /// <summary>
        /// The local active state of this GameObject. (Read Only)
        /// </summary>
        public bool IsGOActive
        {
            get { return gameObject.activeSelf; }
        }

        /// <summary>
        /// Activates/Deactivates the GameObject.
        /// </summary>
        /// <param name="isActive"></param>
        public virtual void SetGOActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}