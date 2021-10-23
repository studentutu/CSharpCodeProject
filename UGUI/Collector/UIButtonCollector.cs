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
using UnityEngine.UI;

namespace MGS.UGUI.Temp
{
    /// <summary>
    /// UI Button-Collector.
    /// </summary>
    public class UIButtonCollector : UICollector<Button, ButtonOptions>
    {
        /// <summary>
        /// On item click event (Index of item, text of item).
        /// </summary>
        public event Action<int, string> OnItemClickEvent;

        /// <summary>
        /// Create a new item from prefab.
        /// </summary>
        /// <returns></returns>
        protected override Button CreateItem()
        {
            var item = base.CreateItem();

            //Agreement: the prefab is under the container.
            var index = item.transform.GetSiblingIndex() - 1;
            var text = item.GetComponentInChildren<Text>();

            void onItemClick() => OnItemClick(index, text);
            item.onClick.AddListener(onItemClick);
            return item;
        }

        /// <summary>
        /// On item click event.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="text"></param>
        protected void OnItemClick(int index, Text text)
        {
            OnItemClickEvent?.Invoke(index, text.text);
        }

        /// <summary>
        /// Refresh item by options.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="options"></param>
        protected override void RefreshItem(Button item, ButtonOptions options)
        {
            item.GetComponentInChildren<Text>().text = options.text;
        }
    }

    /// <summary>
    /// Options for button.
    /// </summary>
    [Serializable]
    public struct ButtonOptions
    {
        /// <summary>
        /// Display text.
        /// </summary>
        public string text;
    }
}