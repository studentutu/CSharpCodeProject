/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoEventTrigger.cs
 *  Description  :  Event trigger for UI behaviour.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  8/30/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MGS.Common.Event
{
    /// <summary>
    /// Event trigger for UI behaviour.
    /// </summary>
    [AddComponentMenu("MGS/Common/MonoEventTrigger")]
    public class MonoEventTrigger : MonoBehaviour, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler,
        IPointerClickHandler, IBeginDragHandler, IInitializePotentialDragHandler, IDragHandler, IEndDragHandler,
        IDropHandler, IScrollHandler, IUpdateSelectedHandler, ISelectHandler, IDeselectHandler, IMoveHandler, ISubmitHandler, ICancelHandler
    {
        #region Field and Property
        /// <summary>
        /// On pointer enter event.
        /// </summary>
        public event Action<PointerEventData> OnPointerEnterEvent;

        /// <summary>
        /// On pointer exit event.
        /// </summary>
        public event Action<PointerEventData> OnPointerExitEvent;

        /// <summary>
        /// On pointer down event.
        /// </summary>
        public event Action<PointerEventData> OnPointerDownEvent;

        /// <summary>
        /// On pointer up event.
        /// </summary>
        public event Action<PointerEventData> OnPointerUpEvent;

        /// <summary>
        /// On pointer click event.
        /// </summary>
        public event Action<PointerEventData> OnPointerClickEvent;

        /// <summary>
        /// On begin drag event.
        /// </summary>
        public event Action<PointerEventData> OnBeginDragEvent;

        /// <summary>
        /// On initialize potential drag event.
        /// </summary>
        public event Action<PointerEventData> OnInitializePotentialDragEvent;

        /// <summary>
        /// On drag event.
        /// </summary>
        public event Action<PointerEventData> OnDragEvent;

        /// <summary>
        /// On end drag event.
        /// </summary>
        public event Action<PointerEventData> OnEndDragEvent;

        /// <summary>
        /// On drop event.
        /// </summary>
        public event Action<PointerEventData> OnDropEvent;

        /// <summary>
        /// On scroll event.
        /// </summary>
        public event Action<PointerEventData> OnScrollEvent;

        /// <summary>
        /// On update selected event.
        /// </summary>
        public event Action<BaseEventData> OnUpdateSelectedEvent;

        /// <summary>
        /// On select event.
        /// </summary>
        public event Action<BaseEventData> OnSelectEvent;

        /// <summary>
        /// On deselect event.
        /// </summary>
        public event Action<BaseEventData> OnDeselectEvent;

        /// <summary>
        /// On move event.
        /// </summary>
        public event Action<AxisEventData> OnMoveEvent;

        /// <summary>
        /// On submit event.
        /// </summary>
        public event Action<BaseEventData> OnSubmitEvent;

        /// <summary>
        /// On cancel event.
        /// </summary>
        public event Action<BaseEventData> OnCancelEvent;
        #endregion

        #region Public Method
        /// <summary>
        /// On pointer enter.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnPointerEnter(PointerEventData eventData)
        {
            OnPointerEnterEvent?.Invoke(eventData);
        }

        /// <summary>
        /// On pointer exit.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnPointerExit(PointerEventData eventData)
        {
            OnPointerExitEvent?.Invoke(eventData);
        }

        /// <summary>
        /// On pointer down.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnPointerDown(PointerEventData eventData)
        {
            OnPointerDownEvent?.Invoke(eventData);
        }

        /// <summary>
        /// On pointer up.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnPointerUp(PointerEventData eventData)
        {
            OnPointerUpEvent?.Invoke(eventData);
        }

        /// <summary>
        /// On pointer click.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnPointerClick(PointerEventData eventData)
        {
            OnPointerClickEvent?.Invoke(eventData);
        }

        /// <summary>
        /// On begin drag.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnBeginDrag(PointerEventData eventData)
        {
            OnBeginDragEvent?.Invoke(eventData);
        }

        /// <summary>
        /// On initialize potential drag.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnInitializePotentialDrag(PointerEventData eventData)
        {
            OnInitializePotentialDragEvent?.Invoke(eventData);
        }

        /// <summary>
        /// On drag.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnDrag(PointerEventData eventData)
        {
            OnDragEvent?.Invoke(eventData);
        }

        /// <summary>
        /// On end drag.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnEndDrag(PointerEventData eventData)
        {
            OnEndDragEvent?.Invoke(eventData);
        }

        /// <summary>
        /// On drop.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnDrop(PointerEventData eventData)
        {
            OnDropEvent?.Invoke(eventData);
        }

        /// <summary>
        /// On scroll.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnScroll(PointerEventData eventData)
        {
            OnScrollEvent?.Invoke(eventData);
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
        /// On select.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnSelect(BaseEventData eventData)
        {
            OnSelectEvent?.Invoke(eventData);
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
        /// On move.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnMove(AxisEventData eventData)
        {
            OnMoveEvent?.Invoke(eventData);
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