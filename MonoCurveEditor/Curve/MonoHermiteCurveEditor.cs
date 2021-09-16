/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoHermiteCurveEditor.cs
 *  DeTargetion  :  Editor for MonoHermiteCurve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  2/28/2018
 *  DeTargetion  :  Initial development version.
 *************************************************************************/

using UnityEditor;
using UnityEngine;

namespace MGS.Curve
{
    [CustomEditor(typeof(MonoHermiteCurve), true)]
    public class MonoHermiteCurveEditor : MonoCurveEditor
    {
        protected readonly Color Gray065 = new Color(0.65f, 0.65f, 0.65f, 1);
        protected readonly Color Gray075 = new Color(0.75f, 0.75f, 0.75f, 1);
        protected readonly Color Gray085 = new Color(0.85f, 0.85f, 0.85f, 1);
        protected new MonoHermiteCurve Target { get { return target as MonoHermiteCurve; } }
        protected override void OnSceneGUI()
        {
            base.OnSceneGUI();
            if (!Application.isPlaying)
            {
                DrawEditor();
            }
        }

        protected override void OnInspectorChange()
        {
            base.OnInspectorChange();
            if (Target.autoSmooth)
            {
                Target.InverseAnchorTangents();
            }
        }

        protected virtual void DrawEditor()
        {
            DrawDefaultEditor();

            for (int i = 0; i < Target.AnchorsCount; i++)
            {
                var anchor = Target.GetAnchor(i);
                var mode = CheckEditMode();
                if (mode == EditMode.InsertAnchor)
                {
                    DrawInsertEditor(i, anchor);
                }
                else if (mode == EditMode.RemoveAnchor)
                {
                    DrawRemoveEditor(i, anchor);
                }
                else
                {
                    DrawMoveEditor(i, anchor);

                    if (!Target.autoSmooth)
                    {
                        if (mode == EditMode.Tangent)
                        {
                            DrawTangentEditor(i, anchor);
                        }
                        else if (mode == EditMode.InOutTangent)
                        {
                            DrawInOutTangentEditor(i, anchor);
                        }
                    }
                }
            }
        }

        protected virtual void DrawDefaultEditor()
        {
            if (Target.AnchorsCount == 0)
            {
                //Considering that it may be used on UI, so use Vector2.one.
                var point = Target.transform.TransformPoint(Vector2.one).normalized * GetHandleSize(Target.transform.position);
                Target.AddAnchor(new HermiteAnchor(point));
            }
        }

        protected virtual void DrawInsertEditor(int index, HermiteAnchor anchor)
        {
            Handles.color = Color.green;
            DrawAdaptiveButton(anchor.point, Quaternion.identity, NodeSize, NodeSize, SphereCap, () =>
            {
                var offset = Vector3.zero;
                if (index > 0)
                {
                    offset = (anchor.point - Target.GetAnchor(index - 1).point).normalized * GetHandleSize(anchor.point);
                }
                else
                {
                    //Considering that it may be used on UI, so use Vector2.one.
                    offset = Target.transform.TransformPoint(Vector2.one).normalized * GetHandleSize(anchor.point);
                }
                Target.InsertAnchor(index + 1, new HermiteAnchor(anchor.point + offset));
                Target.Rebuild();
            });
        }

        protected virtual void DrawRemoveEditor(int index, HermiteAnchor anchor)
        {
            Handles.color = Color.red;
            DrawAdaptiveButton(anchor.point, Quaternion.identity, NodeSize, NodeSize, SphereCap, () =>
            {
                Target.RemoveAnchor(index);
                Target.Rebuild();
            });
        }

        protected virtual void DrawMoveEditor(int index, HermiteAnchor anchor)
        {
            Handles.color = Color.gray;
            if (index == 0 || index == Target.AnchorsCount - 1)
            {
                if (Target.IsClose)
                {
                    Handles.color = Gray075;
                }
                DrawFreeMoveHandle(anchor.point, Quaternion.identity, NodeSize, MoveSnap, SphereCap, position =>
                {
                    var adjacent = Target.GetAnchor(Target.AnchorsCount - 1 - index);
                    if (Vector3.Distance(position, adjacent.point) <= NodeSize * GetHandleSize(position))
                    {
                        position = adjacent.point;
                    }
                    anchor.point = position;
                    Target.SetAnchor(index, anchor);
                    Target.Rebuild();
                });
            }
            else
            {
                DrawFreeMoveHandle(anchor.point, Quaternion.identity, NodeSize, MoveSnap, SphereCap, position =>
                {
                    anchor.point = position;
                    Target.SetAnchor(index, anchor);
                    Target.Rebuild();
                });
            }
        }

        protected virtual void DrawTangentEditor(int index, HermiteAnchor anchor)
        {
            Handles.color = Color.gray;
            if (index > 0)
            {
                var inTangent = anchor.point - anchor.inTangent;
                Handles.DrawLine(anchor.point, inTangent);
                DrawFreeMoveHandle(inTangent, Quaternion.identity, NodeSize, MoveSnap, SphereCap, position =>
                {
                    anchor.inTangent = anchor.outTangent = anchor.point - position;
                    Target.SetAnchor(index, anchor);
                    if (Target.IsClose && index == Target.AnchorsCount - 1)
                    {
                        var firstAnchor = Target.GetAnchor(0);
                        firstAnchor.outTangent = anchor.inTangent;
                        Target.SetAnchor(0, firstAnchor);
                    }
                    Target.Rebuild();
                });
            }

            if (index < Target.AnchorsCount - 1)
            {
                var outTangent = anchor.point + anchor.outTangent;
                Handles.DrawLine(anchor.point, outTangent);
                DrawFreeMoveHandle(outTangent, Quaternion.identity, NodeSize, MoveSnap, SphereCap, position =>
                {
                    anchor.inTangent = anchor.outTangent = position - anchor.point;
                    Target.SetAnchor(index, anchor);
                    if (Target.IsClose && index == 0)
                    {
                        var lastAnchor = Target.GetAnchor(Target.AnchorsCount - 1);
                        lastAnchor.inTangent = anchor.outTangent;
                        Target.SetAnchor(Target.AnchorsCount - 1, lastAnchor);
                    }
                    Target.Rebuild();
                });
            }
        }

        protected virtual void DrawInOutTangentEditor(int index, HermiteAnchor anchor)
        {
            if (index > 0)
            {
                Handles.color = Gray065;
                var inTangent = anchor.point - anchor.inTangent;
                Handles.DrawLine(anchor.point, inTangent);
                DrawFreeMoveHandle(inTangent, Quaternion.identity, NodeSize, MoveSnap, SphereCap, position =>
                {
                    anchor.inTangent = anchor.point - position;
                    Target.SetAnchor(index, anchor);
                    Target.Rebuild();
                });
            }

            if (index < Target.AnchorsCount - 1)
            {
                Handles.color = Gray085;
                var outTangent = anchor.point + anchor.outTangent;
                Handles.DrawLine(anchor.point, outTangent);
                DrawFreeMoveHandle(outTangent, Quaternion.identity, NodeSize, MoveSnap, SphereCap, position =>
                {
                    anchor.outTangent = position - anchor.point;
                    Target.SetAnchor(index, anchor);
                    Target.Rebuild();
                });
            }
        }

        protected virtual EditMode CheckEditMode()
        {
            if (Event.current.control && Event.current.shift)
            {
                return EditMode.RemoveAnchor;
            }
            else if (Event.current.control)
            {
                return EditMode.InsertAnchor;
            }
            else if (Event.current.alt && Event.current.shift)
            {
                return EditMode.InOutTangent;
            }
            else if (Event.current.alt)
            {
                return EditMode.Tangent;
            }
            return EditMode.Normal;
        }

        protected enum EditMode
        {
            InsertAnchor = -2,
            RemoveAnchor = -1,
            Normal = 0,
            Tangent = 1,
            InOutTangent = 2
        }
    }
}