/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoCurveCacherEditor.cs
 *  DeTargetion  :  Editor for MonoCurveCacher.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  9/17/2021
 *  DeTargetion  :  Initial development version.
 *************************************************************************/

using MGS.Common.UEditor;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace MGS.Curve.UEditor
{
    [CustomEditor(typeof(MonoCurveCacher), true)]
    public class MonoCurveCacherEditor : SceneEditor
    {
        protected MonoCurveCacher Target { get { return target as MonoCurveCacher; } }
        protected string cacheFile;

        protected virtual void OnEnable()
        {
            cacheFile = string.Format("{0}/monocurvecache/{1}",
                Application.persistentDataPath, Target.GetComponent<MonoCurve>().GetInstanceID());
        }

        public override void OnInspectorGUI()
        {
            DrawCacheInspector();
            DrawDefaultInspector();
        }

        protected virtual void DrawCacheInspector()
        {
            EditorGUILayout.BeginHorizontal("Box");

            if (GUILayout.Button("Load"))
            {
                if (!File.Exists(cacheFile))
                {
                    Debug.LogWarning("Build the cache first.");
                    return;
                }

                if (Target.Load(cacheFile))
                {
                    SceneView.RepaintAll();
                    MarkSceneDirty();
                    Debug.Log("Load cache succeed.");
                }
                else
                {
                    Debug.LogError("Load cache failed.");
                }
            }

            GUILayout.FlexibleSpace();

            if (GUILayout.Button("Build"))
            {
                if (Target.Build(cacheFile))
                {
                    Debug.Log("Build cache succeed.");
                }
                else
                {
                    Debug.LogError("Build cache failed.");
                }
            }

            if (GUILayout.Button("Clear"))
            {
                if (Target.Delete(cacheFile))
                {
                    Debug.Log("Clear cache succeed.");
                }
                else
                {
                    Debug.LogError("Clear cache failed.");
                }
            }

            EditorGUILayout.EndHorizontal();
        }
    }
}