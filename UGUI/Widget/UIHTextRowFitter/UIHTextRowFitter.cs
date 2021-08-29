/*************************************************************************
 *  Copyright (c) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIHTextRowFitter.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/29/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.UGUI
{
    /// <summary>
    /// UI HText-Row-Fitter.
    /// </summary>
    public class UIHTextRowFitter : UIWidget
    {
        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected HTextRowItem item;
        /// <summary>
        /// 
        /// </summary>
        public float LeftMaxWidth = 100;
        /// <summary>
        /// 
        /// </summary>
        public float RightMaxWidth = 100;

        /// <summary>
        /// 
        /// </summary>
        protected List<HTextRowItem> items = new List<HTextRowItem>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datas"></param>
        public void Refresh(HTextRowData[] datas)
        {
            if (datas == null || datas.Length == 0)
            {
                foreach (var item in items)
                {
                    item.gameObject.SetActive(false);
                }
                return;
            }

            var count = items.Count;
            while (count < datas.Length)
            {
                items.Add(Instantiate(item, transform));
                count++;
            }
            while (count > items.Count)
            {
                items[count - 1].gameObject.SetActive(false);
            }

            var leftPrdWidth = 0f;
            var rightPrdWidth = 0f;
            for (int i = 0; i < datas.Length; i++)
            {
                items[i].gameObject.SetActive(true);
                items[i].ResetLayout();
                items[i].Refresh(datas[i]);

                leftPrdWidth = Mathf.Max(leftPrdWidth, items[i].leftText.preferredWidth);
                Debug.LogError(items[i].leftText.preferredWidth);
                rightPrdWidth = Mathf.Max(rightPrdWidth, items[i].rightText.preferredWidth);
            }

            leftPrdWidth = Mathf.Min(leftPrdWidth, LeftMaxWidth);
            rightPrdWidth = Mathf.Min(rightPrdWidth, RightMaxWidth);
            for (int i = 0; i < datas.Length; i++)
            {
                items[i].leftLayout.preferredWidth = leftPrdWidth;
                items[i].rightLayout.preferredWidth = rightPrdWidth;
            }
        }
    }
}