/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoCurveCollider.cs
 *  Description  :  Collider for mono curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  9/15/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Curve
{
    /// <summary>
    /// Collider for mono curve.
    /// </summary>
    [ExecuteInEditMode]
    public abstract class MonoCurveCollider : MonoBehaviour, IMonoCurveCollider
    {
        /// <summary>
        /// Detail length for renderer.
        /// </summary>
        [SerializeField]
        protected float segment = 0.5f;

        /// <summary>
        /// Radius of collider.
        /// </summary>
        [SerializeField]
        protected float radius = 0.1f;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected bool isTrigger;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected PhysicMaterial material;

        /// <summary>
        /// Segment length of mono curve.
        /// </summary>
        public float Segment
        {
            set { segment = value; }
            get { return segment; }
        }
        
        /// <summary>
        /// Radius of collider.
        /// </summary>
        public float Radius
        {
            set { radius = value; }
            get { return radius; }
        }

        /// <summary>
        /// Collider is trigger?
        /// </summary>
        public bool IsTrigger
        {
            set { isTrigger = value; }
            get { return isTrigger; }
        }

        /// <summary>
        /// PhysicMaterial of collider.
        /// </summary>
        public PhysicMaterial Material
        {
            set { material = value; }
            get { return material; }
        }

        /// <summary>
        /// Reset component.
        /// </summary>
        protected virtual void Reset()
        {
            Rebuild(GetComponent<IMonoCurve>());
        }

        /// <summary>
        /// [MESSAGE] On mono curve rebuild.
        /// </summary>
        /// <param name="curve"></param>
        private void OnMonoCurveRebuild(IMonoCurve curve)
        {
            Rebuild(curve);
        }

        /// <summary>
        /// Rebuild collider base curve.
        /// </summary>
        /// <param name="curve"></param>
        public abstract void Rebuild(IMonoCurve curve);

        /// <summary>
        /// On destroy component.
        /// </summary>
        protected virtual void OnDestroy()
        {
            ClearChildren();
        }

        /// <summary>
        /// Clear children in this transform.
        /// </summary>
        protected virtual void ClearChildren()
        {
            var childCount = transform.childCount;
            while (childCount > 0)
            {
                Destroy(transform.GetChild(0).gameObject);
                childCount--;
            }
        }

        /// <summary>
        /// Destroy object.
        /// </summary>
        /// <param name="obj"></param>
        protected new void Destroy(Object obj)
        {
            if (Application.isPlaying)
            {
                Object.Destroy(obj);
            }
            else
            {
                DestroyImmediate(obj);
            }
        }
    }
}