/*************************************************************************
 *  Copyright (C) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SingleBehaviour.cs
 *  Description  :  Generic single behaviour.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/11/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.DesignPattern
{
    /// <summary>
    /// Generic single behaviour.
    /// Auto create the generic instance, do not add this component to any GameObject by yourself.
    /// </summary>
    public sealed class SingleBehaviour : SingleComponent<SingleBehaviour>
    {
        #region
        /// <summary>
        /// Event on application focus.
        /// </summary>
        public event Action<bool> OnApplicationFocusEvent;

        /// <summary>
        /// Event on application pause.
        /// </summary>
        public event Action<bool> OnApplicationPauseEvent;

        /// <summary>
        /// Event on application quit.
        /// </summary>
        public event Action OnApplicationQuitEvent;
        #endregion

        #region
        /// <summary>
        /// On application focus.
        /// </summary>
        /// <param name="hasFocus"></param>
        void OnApplicationFocus(bool hasFocus)
        {
            OnApplicationFocusEvent?.Invoke(hasFocus);
        }

        /// <summary>
        /// On application pause.
        /// </summary>
        /// <param name="pauseStatus"></param>
        void OnApplicationPause(bool pauseStatus)
        {
            OnApplicationPauseEvent?.Invoke(pauseStatus);
        }

        /// <summary>
        /// On application quit.
        /// </summary>
        void OnApplicationQuit()
        {
            OnApplicationQuitEvent?.Invoke();
        }
        #endregion
    }
}