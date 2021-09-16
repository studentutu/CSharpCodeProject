/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoCurveEditor.cs
 *  DeTargetion  :  Editor for MonoCurveRenderer.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  9/17/2021
 *  DeTargetion  :  Initial development version.
 *************************************************************************/

using MGS.Common;
using UnityEditor;

namespace MGS.Curve
{
    [CustomEditor(typeof(MonoCurveRenderer), true)]
    public class MonoCurveRendererEditor : SceneEditor
    {
        protected MonoCurveRenderer Target { get { return target as MonoCurveRenderer; } }

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
            Target.Rebuild(Target.GetComponent<IMonoCurve>());
        }
    }
}