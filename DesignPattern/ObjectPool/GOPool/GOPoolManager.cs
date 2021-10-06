/*************************************************************************
 *  Copyright (C) 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GOPoolManager.cs
 *  Description  :  Manager of gameobject pool.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  2/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.DesignPattern
{
    /// <summary>
    /// Manager of gameobject pool.
    /// </summary>
    public sealed class GOPoolManager : Singleton<GOPoolManager>
    {
        /// <summary>
        /// Dictionary store pools info(name and pool).
        /// </summary>
        private Dictionary<string, GOPool> poolsInfo = new Dictionary<string, GOPool>();

        /// <summary>
        /// Root transform for pools.
        /// </summary>
        private readonly Transform poolRoot;

        /// <summary>
        /// Constructor.
        /// </summary>
        private GOPoolManager()
        {
            //Create root for pools.
            poolRoot = new GameObject(GetType().Name).transform;
            Object.DontDestroyOnLoad(poolRoot);
        }

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
                return null;
            }

            if (poolsInfo.ContainsKey(name))
            {
                return null;
            }

            if (prefab == null)
            {
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
            return null;
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
        }
    }
}