/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CommandUnit.cs
 *  Description  :  Command unit.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.CommandServo
{
    /// <summary>
    /// Command unit.
    /// </summary>
    public abstract class CommandUnit : ICommandUnit
    {
        #region Field and Property
        /// <summary>
        /// Code of Command unit.
        /// </summary>
        public virtual string Code { set; get; }

        /// <summary>
        /// On Command unit respond event.
        /// </summary>
        public event Action<string, object[]> OnRespondEvent;
        #endregion

        #region Public Method
        /// <summary>
        /// Execute Command.
        /// </summary>
        /// <param name="args">Command args.</param>
        public abstract void Execute(params object[] args);
        #endregion

        #region
        /// <summary>
        /// Invoke on respond event.
        /// </summary>
        /// <param name="args">Command args.</param>
        protected void InvokeOnRespondEvent(object[] args)
        {
            OnRespondEvent?.Invoke(Code, args);
        }
        #endregion
    }
}