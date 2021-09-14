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
        protected const int DETAILS_MAX = 2048;
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
            var len = 0f;
            var p0 = Target.Evaluate(len);
            var differ = Mathf.Max(Target.Length / DETAILS_MAX, GetHandleSize(Target.transform.position) * 0.1f);
            while (len < Target.Length)
            {
                len = Mathf.Min(len + differ, Target.Length);
                var p1 = Target.Evaluate(len);
                Handles.DrawLine(p0, p1);
                p0 = p1;
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