/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CommandUnitManager.cs
 *  Description  :  Manager of Command units.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;

namespace MGS.CommandServo
{
    /// <summary>
    /// Manager of Command units.
    /// </summary>
    public class CommandUnitManager : ICommandUnitManager
    {
        #region Field and Property
        /// <summary>
        /// On Command respond event.
        /// </summary>
        public event Action<Command> OnRespondEvent;

        /// <summary>
        /// units managed by this manager.
        /// </summary>
        protected Dictionary<string, ICommandUnit> units = new Dictionary<string, ICommandUnit>();
        #endregion

        #region Private Method
        /// <summary>
        /// On Command unit respond.
        /// </summary>
        /// <param name="code">Command code.</param>
        /// <param name="args">Command args.</param>
        protected void OnUnitRespond(string code, params object[] args)
        {
            if (string.IsNullOrEmpty(code))
            {
                return;
            }

            InvokeOnRespondEvent(new Command(code, args));
        }

        /// <summary>
        /// Invoke on respond event.
        /// </summary>
        /// <param name="command"></param>
        protected void InvokeOnRespondEvent(Command command)
        {
            OnRespondEvent?.Invoke(command);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Register Command unit.
        /// </summary>
        /// <param name="unit">Command unit.</param>
        public void RegisterUnit(ICommandUnit unit)
        {
            if (unit == null || string.IsNullOrEmpty(unit.Code))
            {
                return;
            }

            unit.OnRespondEvent += OnUnitRespond;
            units.Add(unit.Code, unit);
        }

        /// <summary>
        /// Unregister Command unit.
        /// </summary>
        /// <param name="code">Unit code.</param>
        public void UnregisterUnit(string code)
        {
            if (units.ContainsKey(code))
            {
                units[code].OnRespondEvent -= OnUnitRespond;
                units.Remove(code);
            }
        }

        /// <summary>
        /// Unregister Command units.
        /// </summary>
        public void UnregisterUnits()
        {
            foreach (var unit in units.Values)
            {
                unit.OnRespondEvent -= OnUnitRespond;
            }
            units.Clear();
        }

        /// <summary>
        /// Execute Command.
        /// </summary>
        /// <param name="command">Command to execute.</param>
        public void Execute(Command command)
        {
            if (units.ContainsKey(command.Code))
            {
                units[command.Code].Execute(command.Args);
            }
        }
        #endregion
    }
}