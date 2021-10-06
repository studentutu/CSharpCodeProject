/*************************************************************************
 *  Copyright (C) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GenericPool.cs
 *  Description  :  Generic object pool.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/4/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.DesignPattern
{
    /// <summary>
    /// Interface for resettable object.
    /// </summary>
    public interface IResettable : IDisposable
    {
        /// <summary>
        /// Reset object.
        /// </summary>
        void Reset();
    }

    /// <summary>
    /// Generic object pool.
    /// </summary>
    public class GenericPool<T> : ObjectPool<T> where T : IResettable, new()
    {
        /// <summary>
        /// Constructor of GenericPool.
        /// </summary>
        /// <param name="maxCount">Max count limit of objects in pool.</param>
        public GenericPool(int maxCount = 100) : base(maxCount) { }

        /// <summary>
        /// Create a new object.
        /// </summary>
        /// <returns></returns>
        protected override T Create()
        {
            return new T();
        }

        /// <summary>
        /// Reset this object.
        /// </summary>
        /// <param name="obj"></param>
        protected override void Reset(T obj)
        {
            obj.Reset();
        }

        /// <summary>
        /// Dispose this object.
        /// </summary>
        /// <param name="obj"></param>
        protected override void Dispose(T obj)
        {
            obj.Dispose();
        }
    }
}