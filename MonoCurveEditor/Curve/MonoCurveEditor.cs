﻿/*************************************************************************
 *  Copyright (C) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoCurveEditor.cs
 *  DeTargetion  :  Editor for MonoCurve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  2/28/2018
 *  DeTargetion  :  Initial development version.
 *************************************************************************/

using MGS.Common.UEditor;
using UnityEditor;
using UnityEngine;

namespace MGS.Curve.UEditor
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

        protected virtual void OnDisable()
        {
            Undo.undoRedoPerformed -= Target.Rebuild;
        }

        protected virtual void OnSceneGUI()
        {
            DrawCurve();
        }

        protected virtual void DrawCurve()
        {
            if (Target.Length > 0)
            {
                Handles.color = Color.white;
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
        }

        public override void OnInspectorGUI()
        {
            DrawCaptionInspector();
            EditorGUI.BeginChangeCheck();
            DrawDefaultInspector();
            if (EditorGUI.EndChangeCheck())
            {
                OnInspectorChanged();
            }
        }

        protected virtual void DrawCaptionInspector()
        {
            var caption = CollectCaption();
            if (!string.IsNullOrEmpty(caption))
            {
                EditorGUILayout.HelpBox(caption, MessageType.Info);
            }
        }

        protected virtual string CollectCaption()
        {
            return string.Format("Length: {0}", Target.Length.ToString("f2"));
        }

        protected virtual void OnInspectorChanged()
        {
            Target.Rebuild();
        }
    }
}