/*************************************************************************
 *  Copyright (C) 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ICommandUnit.cs
 *  Description  :  Interface for Command Unit.
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
    /// Interface for Command Unit.
    /// </summary>
    public interface ICommandUnit
    {
        #region Property
        /// <summary>
        /// Command unit code.
        /// </summary>
        string Code { get; }

        /// <summary>
        /// On Command unit respond event.
        /// </summary>
        event Action<string, object[]> OnRespondEvent;
        #endregion

        #region Method
        /// <summary>
        /// Execute Command.
        /// </summary>
        /// <param name="args">Command args.</param>
        void Execute(params object[] args);
        #endregion
    }
}