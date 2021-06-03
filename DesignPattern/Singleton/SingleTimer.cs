/*************************************************************************
 *  Copyright © 2021-2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SingleTimer.cs
 *  Description  :  Define base class of single timer.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  6/4/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Timers;

namespace MGS.DesignPattern
{
    /// <summary>
    /// Provide a single instance with a timer to tick update for the specified type T.
    /// </summary>
    /// <typeparam name="T">Specified type.</typeparam>
    public abstract class SingleTimer<T> : Singleton<T> where T : class
    {
        #region Property
        /// <summary>
        /// Interval of tick update.
        /// </summary>
        public double Interval
        {
            set { Timer.Interval = value; }
            get { return Timer.Interval; }
        }

        /// <summary>
        /// Enabled of tick update.
        /// </summary>
        public bool Enabled
        {
            set { Timer.Enabled = value; }
            get { return Timer.Enabled; }
        }

        /// <summary>
        /// The timer to tick update.
        /// </summary>
        protected Timer Timer { get; }
        #endregion

        #region Method
        /// <summary>
        /// Constructor.
        /// </summary>
        protected SingleTimer()
        {
            Timer = new Timer
            {
                AutoReset = true
            };
            Timer.Elapsed += TickUpdate;
            Timer.Start();
        }

        /// <summary>
        /// Timer tick update.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        protected abstract void TickUpdate(object sender, ElapsedEventArgs e);
        #endregion
    }
}