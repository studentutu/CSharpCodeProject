/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoCurveEditor.cs
 *  DeTargetion  :  Editor for MonoCurve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  2/28/2018
 *  DeTargetion  :  Initial development version.
 *************************************************************************/

using MGS.Common;
using UnityEditor;
using UnityEngine;

namespace MGS.Curve
{
    [CustomEditor(typeof(MonoCurve), true)]
    public class MonoCurveEditor : SceneEditor
    {
        protected MonoCurve Target { get { return target as MonoCurve; } }

        protected virtual void OnEnable()
        {
            if (!Application.isPlaying)
            {
                Target.Rebuild();
                Undo.undoRedoPerformed += Target.Rebuild;
            }
        }

        protected virtual void OnSceneGUI()
        {
            DrawCurve();
        }

        protected virtual void OnDisable()
        {
            Undo.undoRedoPerformed -= Target.Rebuild;
        }

        protected virtual void DrawCurve()
        {
            Handles.color = Blue;
            var differ = 0.01f;
            for (float len = 0; len < Target.Length; len += differ)
            {
                var nlen = Mathf.Min(len + differ, Target.Length);
                Handles.DrawLine(Target.Evaluate(len), Target.Evaluate(nlen));
            }
        }

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
            Target.Rebuild();
        }
    }
}