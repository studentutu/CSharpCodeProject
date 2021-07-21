/*************************************************************************
 *  Copyright © 2021-2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SingleUpdater.cs
 *  Description  :  Define base class of single updater.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  6/4/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Timers;

namespace MGS.DesignPattern
{
    /// <summary>
    /// Provide a single instance to update for the specified type T;
    /// Inheritance class should with the sealed access modifier
    /// and a private parameterless constructor to ensure singleton.
    /// </summary>
    /// <typeparam name="T">Specified type.</typeparam>
    public abstract class SingleUpdater<T> : Singleton<T> where T : class
    {
        #region Property
        /// <summary>
        /// Interval of update [ms].
        /// </summary>
        public double Interval
        {
            set { Timer.Interval = value; }
            get { return Timer.Interval; }
        }

        /// <summary>
        /// Enabled of update.
        /// </summary>
        public bool Enabled
        {
            set { Timer.Enabled = value; }
            get { return Timer.Enabled; }
        }

        /// <summary>
        /// The timer to update.
        /// </summary>
        protected Timer Timer { get; }
        #endregion

        #region Method
        /// <summary>
        /// Constructor.
        /// </summary>
        protected SingleUpdater()
        {
            Timer = new Timer
            {
                AutoReset = true
            };
            Timer.Elapsed += (s, e) => Update(e.SignalTime);
            Timer.Start();
        }

        /// <summary>
        /// On update event.
        /// </summary>
        /// <param name="signalTime">Signal time.</param>
        protected abstract void Update(DateTime signalTime);
        #endregion
    }
}