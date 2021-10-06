/*************************************************************************
 *  Copyright (C) 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Singleton.cs
 *  Description  :  Define base class of singleton.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  2/13/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.DesignPattern
{
    /// <summary>
    /// Provide a single instance of the specified type T;
    /// Inheritance class should with the sealed access modifier
    /// and a private parameterless constructor to ensure singleton.
    /// </summary>
    /// <typeparam name="T">Specified type.</typeparam>
    public abstract class Singleton<T> where T : class
    {
        /// <summary>
        /// Single instance of the specified type T.
        /// </summary>
        public static T Instance { get { return Agent.instance; } }

        /// <summary>
        /// Agent provide the single instance.
        /// </summary>
        private class Agent
        {
            /// <summary>
            /// Single instance of the specified type T created by that type's default constructor.
            /// </summary>
            internal static readonly T instance = Activator.CreateInstance(typeof(T), true) as T;

            /// <summary>
            /// Explicit static constructor to tell C# compiler not to mark type as beforefieldinit.
            /// </summary>
            static Agent() { }
        }
    }
}