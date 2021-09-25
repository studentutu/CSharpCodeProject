/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoCurveEditor.cs
 *  DeTargetion  :  Editor for MonoCurveCollider.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  9/17/2021
 *  DeTargetion  :  Initial development version.
 *************************************************************************/

using MGS.Common;
using UnityEditor;
using UnityEngine;

namespace MGS.Curve
{
    [CustomEditor(typeof(MonoCurveCollider), true)]
    public class MonoCurveColliderEditor : SceneEditor
    {
        protected MonoCurveCollider Target { get { return target as MonoCurveCollider; } }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            DrawDefaultInspector();
            if (EditorGUI.EndChangeCheck())
            {
                OnInspectorChange();
            }
        }

        protected virtual void OnInspectorChange()
        {
            Target.Segment = Mathf.Max(Target.Segment, 0);
            Target.Radius = Mathf.Max(Target.Radius, 0);
            Target.Rebuild(Target.GetComponent<IMonoCurve>());
        }
    }
}