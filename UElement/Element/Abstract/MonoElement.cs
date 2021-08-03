/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoElement.cs
 *  Description  :  Define MonoElement.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  9/22/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Element
{
    /// <summary>
    /// Electronic element.
    /// </summary>
    public abstract class MonoElement : MonoBehaviour, IElement
    {
        #region Field and Property
        /// <summary>
        /// The element is enabled to control?
        /// </summary>
        [Tooltip("The element is enabled to control?")]
        [SerializeField]
        protected bool isEnabled = true;

        /// <summary>
        /// The element is enabled to control?
        /// </summary>
        public virtual bool Enabled
        {
            set { isEnabled = value; }
            get { return isEnabled; }
        }
        #endregion
    }
}