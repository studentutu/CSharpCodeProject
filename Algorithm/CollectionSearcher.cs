/*************************************************************************
 *  Copyright (C) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CollectionSearcher.cs
 *  Description  :  Utility for collection search.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/23/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.Algorithm
{
    /// <summary>
    /// Utility for collection search.
    /// </summary>
    public sealed class CollectionSearcher
    {
        /// <summary>
        /// Binary search the item from array that match the key.
        /// </summary>
        /// <typeparam name="T">Type of array item.</typeparam>
        /// <typeparam name="K">Type of key.</typeparam>
        /// <param name="array">Source array (Ordered by key).</param>
        /// <param name="key">Key to match item.</param>
        /// <param name="compare">Func to compare item and key; return 0 if equal, 1 if greater, -1 if less.</param>
        /// <returns>The match item or default of type T if not match.</returns>
        public static T BinarySearch<T, K>(T[] array, K key, Func<T, K, int> compare)
        {
            var from = 0;
            var to = array.Length;
            while (from <= to)
            {
                var middle = (from + to) / 2;
                var result = compare.Invoke(array[middle], key);
                if (result == 0)
                {
                    return array[middle];
                }
                else if (result < 0)
                {
                    from = middle + 1;
                }
                else
                {
                    to = middle - 1;
                }
            }
            return default(T);
        }
    }
}