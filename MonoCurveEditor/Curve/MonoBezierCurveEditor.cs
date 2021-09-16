/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoBezierCurveEditor.cs
 *  Description  :  Editor for MonoBezierCurve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/3/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEditor;
using UnityEngine;

namespace MGS.Curve
{
    [CustomEditor(typeof(MonoBezierCurve), true)]
    [CanEditMultipleObjects]
    public class MonoBezierCurveEditor : MonoCurveEditor
    {
        protected new MonoBezierCurve Target { get { return target as MonoBezierCurve; } }

        protected override void OnSceneGUI()
        {
            base.OnSceneGUI();
            if (!Application.isPlaying)
            {
                DrawEditor();
            }
        }

        protected virtual void DrawEditor()
        {
            DrawMoveEditor();
            var mode = CheckEditMode();
            if (mode == EditMode.Tangent)
            {
                DrawTangentEditor();
            }
        }

        protected virtual void DrawMoveEditor()
        {
            Handles.color = Color.gray;
            DrawFreeMoveHandle(Target.From, Quaternion.identity, NodeSize, MoveSnap, SphereCap, position =>
            {
                if (Vector3.Distance(position, Target.To) <= NodeSize * GetHandleSize(position))
                {
                    position = Target.To;
                }
                Target.From = position;
                Target.Rebuild();
            });

            DrawFreeMoveHandle(Target.To, Quaternion.identity, NodeSize, MoveSnap, SphereCap, position =>
            {
                if (Vector3.Distance(position, Target.From) <= NodeSize * GetHandleSize(position))
                {
                    position = Target.From;
                }
                Target.To = position;
                Target.Rebuild();
            });
        }

        protected virtual void DrawTangentEditor()
        {
            Handles.color = Color.gray;
            var frTangent = Target.From + Target.FrTangent;
            Handles.DrawLine(Target.From, frTangent);
            DrawFreeMoveHandle(frTangent, Quaternion.identity, NodeSize, MoveSnap, SphereCap, position =>
            {
                Target.FrTangent = position - Target.From;
                Target.Rebuild();
            });

            var toTangent = Target.To + Target.ToTangent;
            Handles.DrawLine(Target.To, toTangent);
            DrawFreeMoveHandle(toTangent, Quaternion.identity, NodeSize, MoveSnap, SphereCap, position =>
            {
                Target.ToTangent = position - Target.To;
                Target.Rebuild();
            });
        }

        protected virtual EditMode CheckEditMode()
        {
            if (Event.current.alt)
            {
                return EditMode.Tangent;
            }
            return EditMode.Normal;
        }

        protected enum EditMode
        {
            Normal = 0,
            Tangent = 1
        }
    }
}