/*************************************************************************
 *  Copyright (c) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UITextCollector.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  10/20/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine.UI;

namespace MGS.UGUI
{
    /// <summary>
    /// UI Text-Collector.
    /// </summary>
    public class UITextCollector : UICollector<Text, string>
    {
        /// <summary>
        /// Refresh item by text.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="text"></param>
        protected override void RefreshItem(Text item, string text)
        {
            item.text = text;
        }
    }
}