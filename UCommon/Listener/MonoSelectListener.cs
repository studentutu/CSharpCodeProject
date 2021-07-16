/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoDragListener.cs
 *  Description  :  Event Listener for select.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/14/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MGS.Common.Listener
{
    /// <summary>
    ///Event Listener for select.
    /// </summary>
    public class MonoSelectListener : MonoBehaviour,
        ISelectHandler, IUpdateSelectedHandler, IDeselectHandler,
        ISubmitHandler, ICancelHandler
    {
        #region
        /// <summary>
        /// On select event.
        /// </summary>
        public event Action<BaseEventData> OnSelectEvent;

        /// <summary>
        /// On update selected event.
        /// </summary>
        public event Action<BaseEventData> OnUpdateSelectedEvent;

        /// <summary>
        /// On deselect event.
        /// </summary>
        public event Action<BaseEventData> OnDeselectEvent;

        /// <summary>
        /// On submit event.
        /// </summary>
        public event Action<BaseEventData> OnSubmitEvent;

        /// <summary>
        /// On cancel event.
        /// </summary>
        public event Action<BaseEventData> OnCancelEvent;
        #endregion

        #region
        /// <summary>
        /// On select.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnSelect(BaseEventData eventData)
        {
            OnSelectEvent?.Invoke(eventData);
        }

        /// <summary>
        /// On update selected.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnUpdateSelected(BaseEventData eventData)
        {
            OnUpdateSelectedEvent?.Invoke(eventData);
        }

        /// <summary>
        /// On deselect.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnDeselect(BaseEventData eventData)
        {
            OnDeselectEvent?.Invoke(eventData);
        }

        /// <summary>
        /// On submit.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnSubmit(BaseEventData eventData)
        {
            OnSubmitEvent?.Invoke(eventData);
        }

        /// <summary>
        /// On cancel.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnCancel(BaseEventData eventData)
        {
            OnCancelEvent?.Invoke(eventData);
        }
        #endregion
    }
}