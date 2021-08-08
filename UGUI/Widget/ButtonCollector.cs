/*************************************************************************
 *  Copyright (c) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ButtonCollector.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/6/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;
using UnityEngine.UI;

namespace MGS.UGUI
{
    /// <summary>
    /// Collector base prefab for button
    /// </summary>
    public class ButtonCollector : UIWidget
    {
        /// <summary>
        /// Root of button items.
        /// </summary>
        [SerializeField]
        protected RectTransform root;

        /// <summary>
        /// Prefab for item clone.
        /// </summary>
        [SerializeField]
        protected Button prefab;

        /// <summary>
        /// On item click event (Index of item, value of item).
        /// </summary>
        public event Action<int, string> OnItemClickEvent
        {
            add { onItemClickEvent += value; }
            remove { onItemClickEvent -= value; }
        }
        /// <summary>
        /// 
        /// </summary>
        protected Action<int, string> onItemClickEvent;

        /// <summary>
        /// Refresh button item for data items.
        /// </summary>
        /// <param name="items"></param>
        public void Refresh(string[] items)
        {
            var itemCount = 0;
            if (items != null)
            {
                itemCount = items.Length;
            }

            var childCount = root.childCount;
            while (childCount > itemCount)
            {
                var lastItem = root.GetChild(childCount - 1).gameObject;
                Destroy(lastItem);
                childCount--;
            }
            while (childCount < itemCount)
            {
                var index = childCount;
                var value = items[index];
                var item = Instantiate(prefab, root);
                item.onClick.AddListener(() => Item_OnClick(index, value));
                item.gameObject.SetActive(true);
                childCount++;
            }

            for (int i = 0; i < itemCount; i++)
            {
                root.GetChild(i).GetComponentInChildren<Text>().text = items[i];
            }
        }

        private void Item_OnClick(int index, string value)
        {
            onItemClickEvent?.Invoke(index, value);
        }
    }
}