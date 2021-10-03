/*************************************************************************
 *  Copyright (C) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SingleComponent.cs
 *  Description  :  Generic base class for single Component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/11/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.DesignPattern
{
    /// <summary>
    /// Generic base class for single Component.
    /// Inheritance class should with the sealed access modifier to ensure distinct singleton.
    /// </summary>
    [DisallowMultipleComponent]
    public abstract class SingleComponent<T> : MonoBehaviour where T : Component
    {
        /// <summary>
        /// Single instance of the specified Component T.
        /// </summary>
        public static T Instance { get { return Agent.instance; } }

        #region
        /// <summary>
        /// Agent provide the single instance.
        /// </summary>
        private class Agent
        {
            #region Property
            /// <summary>
            /// Single instance of the specified Component T.
            /// </summary>
            internal static readonly T instance = new GameObject(typeof(T).Name).AddComponent<T>();
            #endregion

            #region Static Method
            /// <summary>
            /// Explicit static constructor to tell C# compiler not to mark type as beforefieldinit.
            /// </summary>
            static Agent()
            {
                DontDestroyOnLoad(instance);
            }
            #endregion
        }
        #endregion
    }
}