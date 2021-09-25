/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoCurveHoseEditor.cs
 *  Description  :  Editor for MonoCurveHose component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/20/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Curve;
using UnityEditor;

namespace MGS.SkinnedMesh
{
    [CustomEditor(typeof(MonoCurveHose), true)]
    public class MonoCurveHoseEditor : MonoSkinEditor
    {
        protected new MonoCurveHose Target { get { return target as MonoCurveHose; } }

        protected override void OnEnable() { }

        protected override void OnDisable() { }

        protected override string CollectCaption()
        {
            return string.Format("Segments: {0}\r\n{1}", Target.Segments, base.CollectCaption());
        }

        protected override void OnInspectorChange()
        {
            Target.Rebuild(Target.GetComponent<IMonoCurve>());
        }
    }
}