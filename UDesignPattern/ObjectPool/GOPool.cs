/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GOPool.cs
 *  Description  :  Define GameObjectPool.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  2/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.DesignPattern
{
    /// <summary>
    /// Pool of gameobject.
    /// </summary>
    public class GOPool : ObjectPool<GameObject>
    {
        #region Field and Property
        /// <summary>
        /// Parent of gameobjects.
        /// </summary>
        public Transform Node { get; }

        /// <summary>
        /// Prefab to create clone.
        /// </summary>
        protected GameObject prefab;
        #endregion

        #region Public Method
        /// <summary>
        /// Create and initialize GameObjectPool.
        /// </summary>
        /// <param name="node">Parent of gameobjects.</param>
        /// <param name="prefab">Prefab to create clone.</param>
        /// <param name="maxCount">Max count limit of gameobjects in pool.</param>
        public GOPool(Transform node, GameObject prefab, int maxCount = 100) : base(maxCount)
        {
            Node = node;
            this.prefab = prefab;
        }

        /// <summary>
        /// Take a gameobject from pool.
        /// </summary>
        /// <param name="position">Position of new gameobject.</param>
        /// <param name="rotation">Rotation of new gameobject.</param>
        /// <returns>A gameobject.</returns>
        public virtual GameObject Take(Vector3 position, Quaternion rotation)
        {
            var obj = Take();
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.SetActive(true);
            return obj;
        }

        /// <summary>
        /// Take a gameobject from pool.
        /// </summary>
        /// <param name="parent">Parent of new gameobject.</param>
        /// <param name="localPosition">Local position of new gameobject.</param>
        /// <param name="localRotation">Local rotation of new gameobject.</param>
        /// <returns>A gameobject.</returns>
        public virtual GameObject Take(Transform parent, Vector3 localPosition, Quaternion localRotation)
        {
            var obj = Take();
            obj.transform.parent = parent;
            obj.transform.localPosition = localPosition;
            obj.transform.localRotation = localRotation;
            obj.SetActive(true);
            return obj;
        }
        #endregion

        #region Protected Method
        /// <summary>
        /// Create new gameobject.
        /// </summary>
        /// <returns></returns>
        protected override GameObject Create()
        {
            var clone = Object.Instantiate(prefab);
            clone.transform.parent = Node;
            return clone;
        }

        /// <summary>
        /// Reset the gameobject.
        /// </summary>
        /// <param name="obj"></param>
        protected override void Reset(GameObject obj)
        {
            obj.SetActive(false);

            obj.tag = prefab.tag;
            obj.layer = prefab.layer;

            obj.transform.position = prefab.transform.position;
            obj.transform.rotation = prefab.transform.rotation;

            obj.transform.parent = null;
            obj.transform.localScale = prefab.transform.localScale;
            obj.transform.parent = Node;
        }

        /// <summary>
        /// Dispose the gameobject.
        /// </summary>
        /// <param name="obj"></param>
        protected override void Dispose(GameObject obj)
        {
            Object.Destroy(obj);
        }
        #endregion
    }
}