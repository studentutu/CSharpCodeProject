/*************************************************************************
 *  Copyright (C) 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoSkinEditor.cs
 *  Description  :  Editor for MonoSkin component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/20/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.UEditor;
using UnityEditor;
using UnityEngine;

namespace MGS.SkinnedMesh
{
    [CustomEditor(typeof(MonoSkinnedMesh), true)]
    public class MonoSkinEditor : SceneEditor
    {
        protected MonoSkinnedMesh Target { get { return target as MonoSkinnedMesh; } }

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
            EditorUtility.UnloadUnusedAssetsImmediate(false);
            Undo.undoRedoPerformed -= Target.Rebuild;
        }

        public override void OnInspectorGUI()
        {
            DrawCaptionInspector();
            EditorGUI.BeginChangeCheck();
            DrawDefaultInspector();
            if (EditorGUI.EndChangeCheck())
            {
                OnInspectorChange();
            }
        }

        protected virtual void DrawCaptionInspector()
        {
            var info = CollectCaption();
            if (!string.IsNullOrEmpty(info))
            {
                EditorGUILayout.HelpBox(info, MessageType.Info);
            }
        }

        protected virtual string CollectCaption()
        {
            if (Target.Renderer.sharedMesh == null)
            {
                return null;
            }

            var triangles = 0;
            var mesh = Target.Renderer.sharedMesh;
            for (int i = 0; i < mesh.subMeshCount; i++)
            {
                triangles += mesh.GetTriangles(i).Length;
            }
            return string.Format("MeshCount: {0}  Vertices: {1}  Triangles: {2}",
                mesh.subMeshCount, mesh.vertexCount, triangles);
        }

        protected virtual void OnInspectorChange()
        {
            Target.Rebuild();
        }
    }
}