/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoCurveCollider.cs
 *  Description  :  Capsule collider for mono curve.
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
    /// Capsule collider for mono curve.
    /// </summary>
    public class MonoCurveCapsuleCollider : MonoCurveCollider
    {
        /// <summary>
        /// Rebuild collider base curve.
        /// </summary>
        /// <param name="curve"></param>
        public override void Rebuild(IMonoCurve curve)
        {
            if (curve == null)
            {
                ClearChildren();
                return;
            }

            Segments = MonoCurveUtility.GetSegmentCount(curve, segment, out float differ);
            RequireCapsules(Segments);
            SetCapsules(curve, Segments, differ);
        }

        /// <summary>
        /// Set capsule colliders.
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="segments"></param>
        /// <param name="differ"></param>
        protected virtual void SetCapsules(IMonoCurve curve, int segments, float differ)
        {
            for (int i = 0; i < segments; i++)
            {
                var node = transform.GetChild(i);
                node.localPosition = curve.LocalEvaluate((i + 0.5f) * differ);
                var tangent = (curve.Evaluate((i + 1) * differ) - curve.Evaluate(i * differ));
                node.LookAt(node.position + tangent);

                var capsule = node.GetComponent<CapsuleCollider>();
                capsule.center = Vector3.zero;
                capsule.direction = 2;
                capsule.height = differ + radius * 2;
                capsule.radius = radius;
                capsule.isTrigger = isTrigger;
                capsule.material = material;
            }
        }

        /// <summary>
        /// Require the count of capsule colliders.
        /// </summary>
        /// <param name="count"></param>
        protected virtual void RequireCapsules(int count)
        {
            var childCount = transform.childCount;
            while (childCount < count)
            {
                var name = string.Format("Collider {0}", childCount);
                var newCollider = new GameObject(name, typeof(CapsuleCollider));
                newCollider.transform.parent = transform;
                childCount++;
            }
            while (childCount > count)
            {
                Destroy(transform.GetChild(childCount - 1).gameObject);
                childCount--;
            }
        }
    }
}