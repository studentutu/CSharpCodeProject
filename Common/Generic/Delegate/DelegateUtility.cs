/*************************************************************************
 *  Copyright © 2021-2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  DelegateUtility.cs
 *  Description  :  Utility for delegate.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  6/4/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Logger;
using System;

namespace MGS.Common.Generic
{
    /// <summary>
    /// Utility for delegate.
    /// </summary>
    public sealed class DelegateUtility
    {
        /// <summary>
        /// Invoke action and try catch exception.
        /// </summary>
        /// <param name="action"></param>
        public static void Invoke(Action action)
        {
            if (action == null)
            {
                return;
            }

            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                LogUtility.LogException(ex);
            }
        }

        /// <summary>
        /// Invoke action and try catch exception.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <param name="arg"></param>
        public static void Invoke<T>(Action<T> action, T arg)
        {
            if (action == null)
            {
                return;
            }

            try
            {
                action.Invoke(arg);
            }
            catch (Exception ex)
            {
                LogUtility.LogException(ex);
            }
        }

        /// <summary>
        /// Invoke action and try catch exception.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        public static void Invoke<T1, T2>(Action<T1, T2> action, T1 arg1, T2 arg2)
        {
            if (action == null)
            {
                return;
            }

            try
            {
                action.Invoke(arg1, arg2);
            }
            catch (Exception ex)
            {
                LogUtility.LogException(ex);
            }
        }
    }
}