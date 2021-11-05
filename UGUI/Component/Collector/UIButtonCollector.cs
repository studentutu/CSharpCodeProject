/*************************************************************************
 *  Copyright (c) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIButtonCollector.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  10/20/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.UGUI.Temp
{
    /// <summary>
    /// UI button collector.
    /// </summary>
    public class UIButtonCollector : UICollector<UIButton, ButtonOptions>
    {
        /// <summary>
        /// On cell click event.
        /// </summary>
        public event Action<UIButton> OnCellClickEvent;

        /// <summary>
        /// Create a new cell from prefab.
        /// </summary>
        /// <returns></returns>
        protected override UIButton CreateCell()
        {
            var cell = base.CreateCell();
            cell.button.onClick.AddListener(() => OnCellClick(cell));
            return cell;
        }

        /// <summary>
        /// On cell click event.
        /// </summary>
        /// <param name="cell">Button cell.</param>
        protected void OnCellClick(UIButton cell)
        {
            OnCellClickEvent?.Invoke(cell);
        }
    }
}