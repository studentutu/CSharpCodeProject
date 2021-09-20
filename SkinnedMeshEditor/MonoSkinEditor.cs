/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoSkinEditor.cs
 *  Description  :  Editor for MonoSkin component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/20/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common;
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