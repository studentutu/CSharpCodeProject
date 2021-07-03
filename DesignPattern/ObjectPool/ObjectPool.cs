/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ObjectPool.cs
 *  Description  :  Define ObjectPool.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  2/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;

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
    /// <typeparam name="T">Specified type of object.</typeparam>
    public class ObjectPool<T> where T : IResettable, new()
    {
        #region Field and Property
        /// <summary>
        /// Max count limit of objects in pool.
        /// </summary>
        public int MaxCount { set; get; }

        /// <summary>
        /// Current count of objects in pool.
        /// </summary>
        public int CurrentCount { get { return objectStack.Count; } }

        /// <summary>
        /// Stack store objects.
        /// </summary>
        protected Stack<T> objectStack = new Stack<T>();
        #endregion

        #region Public Method
        /// <summary>
        /// Constructor of ObjectPool.
        /// </summary>
        /// <param name="maxCount">Max count limit of objects in pool.</param>
        public ObjectPool(int maxCount = 100)
        {
            MaxCount = maxCount;
        }

        /// <summary>
        /// Take a object from pool.
        /// </summary>
        /// <returns>A object.</returns>
        public virtual T Take()
        {
            if (objectStack.Count > 0)
            {
                return objectStack.Pop();
            }

            return new T();
        }

        /// <summary>
        /// Recycle object to pool.
        /// </summary>
        /// <param name="obj">Object to recycle.</param>
        public virtual void Recycle(T obj)
        {
            //Null object do not need to recycle.
            if (obj == null)
            {
                return;
            }

            //Avoid repeated recycle. 
            if (objectStack.Contains(obj))
            {
                return;
            }

            if (objectStack.Count < MaxCount)
            {
                obj.Reset();
                objectStack.Push(obj);
            }
            else
            {
                obj.Dispose();
            }
        }

        /// <summary>
        /// Clear all objects.
        /// </summary>
        public virtual void Clear()
        {
            foreach (var obj in objectStack)
            {
                obj.Dispose();
            }
            objectStack.Clear();
        }
        #endregion
    }
}