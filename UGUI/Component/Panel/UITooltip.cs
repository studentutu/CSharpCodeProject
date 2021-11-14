/*************************************************************************
 *  Copyright (c) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UITooltip.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  11/14/2021
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.UGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UITooltip : UIRefreshable<string>
    {
        /// <summary>
        /// 
        /// </summary>
        public UIText text;

        /// <summary>
        /// 
        /// </summary>
        public float MaxWidth
        {
            set { text.maxWidth = value; }
            get { return text.maxWidth; }
        }

        /// <summary>
        /// 
        /// </summary>
        public float MaxHeight
        {
            set { text.maxHeight = value; }
            get { return text.maxHeight; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void Reset()
        {
            base.Reset();
            text = GetComponentInChildren<UIText>(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        protected override void OnRefresh(string info)
        {
            text.text = info;
        }
    }
}