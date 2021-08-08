/*************************************************************************
 *  Copyright (c) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIPanel.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/8/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace MGS.UGUI
{
    /// <summary>
    /// UI panel.
    /// </summary>
    public abstract class UIPanel : UIComponent
    {
        /// <summary>
        /// The Text component for tittle,
        /// </summary>
        [SerializeField]
        protected Text txt_Tittle;

        /// <summary>
        /// Tittle of panel.
        /// </summary>
        public string Tittle
        {
            set { txt_Tittle.text = value; }
            get { return txt_Tittle.text; }
        }
    }
}