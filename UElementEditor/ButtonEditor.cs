/*************************************************************************
 *  Copyright © 2016-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ButtonEditor.cs
 *  Description  :  Editor for Button element.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/9/2018
 *  Description  :  Initial development version.
 *  
 *  Author       :  Mogoson
 *  Version      :  1.1
 *  Date         :  6/22/2018
 *  Description  :  Optimize display of node.
 *************************************************************************/

using MGS.Common;
using UnityEditor;
using UnityEngine;

namespace MGS.Element
{
    [CustomEditor(typeof(Button), true)]
    [CanEditMultipleObjects]
    public class ButtonEditor : SceneEditor
    {
        #region Field and Property 
        protected Button Target { get { return target as Button; } }

        protected Vector3 ZeroPoint
        {
            get
            {
                if (Application.isPlaying)
                {
                    var point = Target.StartPosition;
                    if (Target.transform.parent)
                    {
                        point = Target.transform.parent.TransformPoint(point);
                    }
                    return point;
                }
                return Target.transform.position;
            }
        }
        #endregion

        #region Protected Method
        protected virtual void OnSceneGUI()
        {
            Handles.color = Color.cyan;
            DrawAdaptiveSphereCap(ZeroPoint, Quaternion.identity, NodeSize);
            DrawAdaptiveSphereCap(Target.transform.position, Quaternion.identity, NodeSize);
            DrawSphereArrow(ZeroPoint, Target.transform.forward, Target.DownOffset, NodeSize);

            if (Target.SelfLock)
            {
                DrawAdaptiveSphereCap(ZeroPoint + Target.transform.forward * Target.DownOffset * Target.LockPercent, Quaternion.identity, NodeSize);
            }
        }
        #endregion
    }
}