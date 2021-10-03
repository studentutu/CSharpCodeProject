/*************************************************************************
 *  Copyright (C) 2021-2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SingleUpdater.cs
 *  Description  :  Define base class of single updater.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  6/4/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Threading;

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
        public int Interval { set; get; }

        /// <summary>
        /// Enabled of update.
        /// </summary>
        public bool Enabled { set; get; }

        /// <summary>
        /// The thread to update.
        /// </summary>
        private Thread thread;
        #endregion

        #region Method
        /// <summary>
        /// Constructor.
        /// </summary>
        protected SingleUpdater()
        {
            Interval = 200;
            Enabled = true;

            thread = new Thread(Start) { IsBackground = true };
            thread.Start();
        }

        /// <summary>
        /// On thread start event.
        /// </summary>
        private void Start()
        {
            while (true)
            {
                if (Enabled)
                {
                    Update();
                }
                Thread.Sleep(Interval);
            }
        }

        /// <summary>
        /// On thread update event.
        /// </summary>
        protected abstract void Update();
        #endregion
    }
}