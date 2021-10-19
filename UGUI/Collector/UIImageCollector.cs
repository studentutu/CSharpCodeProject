/*************************************************************************
 *  Copyright (c) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIImageCollector.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  10/20/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace MGS.UGUI
{
    /// <summary>
    /// UI Image-Collector.
    /// </summary>
    public class UIImageCollector : UICollector<Image, Sprite>
    {
        /// <summary>
        /// Refresh item by sprite.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="sprite"></param>
        protected override void RefreshItem(Image item, Sprite sprite)
        {
            item.sprite = sprite;
        }
    }
}