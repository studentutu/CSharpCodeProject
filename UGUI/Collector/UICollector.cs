/*************************************************************************
 *  Copyright (c) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UICollector.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  10/19/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.UGUI
{
    /// <summary>
    /// UI collector.
    /// </summary>
    /// <typeparam name="T">Type of item.</typeparam>
    /// <typeparam name="K">Type of info for item.</typeparam>
    public abstract class UICollector<T, K> : UIComponent where T : Component
    {
        /// <summary>
        /// Container of items.
        /// </summary>
        public RectTransform container;

        /// <summary>
        /// Prefab of item to clone.
        /// </summary>
        public T item;

        /// <summary>
        /// Refresh items by infos.
        /// </summary>
        /// <param name="infos">Infos to refresh items.</param>
        public virtual void Refresh(ICollection<K> infos)
        {
            if (infos == null || infos.Count == 0)
            {
                RequireItems(0);
                return;
            }

            RequireItems(infos.Count);

            //Agreement: the prefab is under the container.
            var index = 1;
            foreach (var info in infos)
            {
                var item = container.GetChild(index).GetComponent<T>();
                item.gameObject.SetActive(true);
                RefreshItem(item, info);
                index++;
            }
        }

        /// <summary>
        /// Require the number of items.
        /// </summary>
        /// <param name="count"></param>
        protected virtual void RequireItems(int count)
        {
            //Agreement: the prefab is under the container.
            count += 1;
            var childCount = container.childCount;
            while (childCount > count)
            {
                DisposeItem(container.GetChild(childCount - 1).GetComponent<T>());
                childCount--;
            }
            while (childCount < count)
            {
                CreateItem();
                childCount++;
            }
        }

        /// <summary>
        /// Create a new item from prefab.
        /// </summary>
        /// <returns></returns>
        protected virtual T CreateItem()
        {
            return Instantiate(item, container);
        }

        /// <summary>
        /// Dispose the item from container.
        /// </summary>
        /// <param name="item">Child index of item.</param>
        protected virtual void DisposeItem(T item)
        {
            item.gameObject.SetActive(false);
        }

        /// <summary>
        /// Refresh item by info.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="info"></param>
        protected abstract void RefreshItem(T item, K info);
    }
}