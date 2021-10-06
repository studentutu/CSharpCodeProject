/*************************************************************************
 *  Copyright (C) 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IElement.cs
 *  Description  :  Interface for electronic element.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  9/22/2018
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Element
{
    /// <summary>
    /// Interface for electronic element.
    /// </summary>
    public interface IElement
    {
        #region Property
        /// <summary>
        /// The element is enabled to control?
        /// </summary>
        bool Enabled { set; get; }
        #endregion
    }
}