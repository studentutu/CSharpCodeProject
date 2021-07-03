/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GOPoolManager.cs
 *  Description  :  Manager of gameobject pool.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  2/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Logger;
using System.Collections.Generic;
using UnityEngine;

namespace MGS.DesignPattern
{
    /// <summary>
    /// Manager of gameobject pool.
    /// </summary>
    public sealed class GOPoolManager : Singleton<GOPoolManager>
    {
        #region Field and Property
        /// <summary>
        /// Dictionary store pools info(name and pool).
        /// </summary>
        private Dictionary<string, GOPool> poolsInfo = new Dictionary<string, GOPool>();

        /// <summary>
        /// Root transform for pools.
        /// </summary>
        private readonly Transform poolRoot;
        #endregion

        #region Private Method
        /// <summary>
        /// Constructor.
        /// </summary>
        private GOPoolManager()
        {
            //Create root for pools.
            poolRoot = new GameObject(GetType().Name).transform;
            Object.DontDestroyOnLoad(poolRoot);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Create a pool in this manager.
        /// </summary>
        /// <param name="name">Name of GameObjectPool.</param>
        /// <param name="prefab">Prefab of GameObjectPool.</param>
        /// <param name="maxCount">Max count limit of gameobjects in pool.</param>
        /// <returns>Pool created base on parameters.</returns>
        public GOPool CreatePool(string name, GameObject prefab, int maxCount = 100)
        {
            if (string.IsNullOrEmpty(name))
            {
                LogUtility.LogError("Create pool error: The pool name can not be null or empty.");
                return null;
            }

            if (poolsInfo.ContainsKey(name))
            {
                LogUtility.LogWarning("Create pool cancelled: The pool that name is \"{0}\" already exist in this manager.", name);
                return poolsInfo[name];
            }

            if (prefab == null)
            {
                LogUtility.LogError("Create pool error: The prefab of pool can not be null.");
                return null;
            }

            //Create new gameobject for pool.
            var poolNode = new GameObject(name).transform;
            poolNode.parent = poolRoot;

            //Create new pool.
            var newPool = new GOPool(poolNode, prefab, maxCount);
            poolsInfo.Add(name, newPool);
            return newPool;
        }

        /// <summary>
        /// Find GameObjectPool by name.
        /// </summary>
        /// <param name="name">Name of GameObjectPool.</param>
        /// <returns>Name match GameObjectPool.</returns>
        public GOPool FindPool(string name)
        {
            if (poolsInfo.ContainsKey(name))
            {
                return poolsInfo[name];
            }
            else
            {
                LogUtility.LogWarning("Find pool error: The pool that name is \"{0}\" does not exist in this manager.", name);
                return null;
            }
        }

        /// <summary>
        /// Delete GameObjectPool by name.
        /// </summary>
        /// <param name="name">Name of GameObjectPool.</param>
        public void DeletePool(string name)
        {
            if (poolsInfo.ContainsKey(name))
            {
                var pool = poolsInfo[name];
                pool.Clear();

                Object.Destroy(pool.Node.gameObject);
                poolsInfo.Remove(name);
            }
            else
            {
                LogUtility.LogWarning("Delete pool error: The pool that name is \"{0}\" does not exist in this manager.", name);
            }
        }
        #endregion
    }
}