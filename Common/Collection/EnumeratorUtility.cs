/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  EnumeratorUtility.cs
 *  Description  :  Utility for enumerator.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  5/1/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Threading;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MGS.Common.Collection
{
    /// <summary>
    /// Utility for enumerator.
    /// </summary>
    public sealed class EnumeratorUtility
    {
        /// <summary>
        /// Collect progress states and complete event.
        /// </summary>
        /// <param name="enumerator">Source enumerator.</param>
        /// <param name="progress">Progress event.</param>
        /// <param name="complete">Complete event.</param>
        /// <returns>IEnumerator.</returns>
        public static IEnumerator Collect(IEnumerator enumerator,
            Action<object> progress = null, Action complete = null)
        {
            while (enumerator.MoveNext())
            {
                progress?.Invoke(enumerator.Current);
                yield return enumerator.Current;
            }

            complete?.Invoke();
        }

        /// <summary>
        /// Collect progress states and complete event.
        /// </summary>
        /// <param name="enumerators">IEnumerable of source enumerator.</param>
        /// <param name="progress">Progress event.</param>
        /// <param name="complete">Complete event.</param>
        /// <returns>IEnumerator.</returns>
        public static IEnumerator Collect(IEnumerable<IEnumerator> enumerators,
            Action<object> progress = null, Action complete = null)
        {
            foreach (var enumerator in enumerators)
            {
                while (enumerator.MoveNext())
                {
                    progress?.Invoke(enumerator.Current);
                    yield return enumerator.Current;
                }
            }

            complete?.Invoke();
        }

        /// <summary>
        /// Run the enumerator in a background thread.
        /// </summary>
        /// <param name="enumerator">Source enumerator will run in a background thread.</param>
        /// <returns>IEnumerator.</returns>
        public static IEnumerator RunAsync(IEnumerator enumerator)
        {
            var isDone = false;
            var results = new Queue<object>();
            ThreadUtility.RunAsync(() =>
            {
                while (enumerator.MoveNext())
                {
                    results.Enqueue(enumerator.Current);
                }

                isDone = true;
            });

            while (!isDone || results.Count > 0)
            {
                if (results.Count > 0)
                {
                    yield return results.Dequeue();
                }
                else
                {
                    yield return null;
                }
            }
        }
    }
}