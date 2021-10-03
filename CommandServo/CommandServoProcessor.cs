/*************************************************************************
 *  Copyright (C) 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CommandServoProcessor.cs
 *  Description  :  Command servo processor.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.DesignPattern;

namespace MGS.CommandServo
{
    /// <summary>
    /// Command servo processor.
    /// </summary>
    public sealed class CommandServoProcessor : SingleUpdater<CommandServoProcessor>, ICommandServoProcessor
    {
        #region Field and Property
        /// <summary>
        /// Manager of Commands.
        /// </summary>
        public ICommandManager CommandManager { set; get; }

        /// <summary>
        /// Manager of Command units.
        /// </summary>
        public ICommandUnitManager CommandUnitManager
        {
            set
            {
                if (commandUnitManager != null)
                {
                    commandUnitManager.OnRespondEvent -= OnUnitRespond;
                }

                if (value != null)
                {
                    value.OnRespondEvent += OnUnitRespond;
                }
                commandUnitManager = value;
            }
            get { return commandUnitManager; }
        }

        /// <summary>
        /// Manager of Command units.
        /// </summary>
        private ICommandUnitManager commandUnitManager;

        /// <summary>
        /// The settings of processor is valid?
        /// </summary>
        private bool IsSettingsValid
        {
            get
            {
                if (CommandManager == null || CommandUnitManager == null)
                {
                    return false;
                }
                return true;
            }
        }
        #endregion

        #region Private Method
        /// <summary>
        /// Constructor.
        /// </summary>
        private CommandServoProcessor() { }

        /// <summary>
        /// On update event.
        /// </summary>
        protected override void Update()
        {
            if (!IsSettingsValid)
            {
                return;
            }

            var commands = CommandManager.DequeueCommands();
            if (commands != null)
            {
                foreach (var command in commands)
                {
                    CommandUnitManager.Execute(command);
                }
            }
        }

        /// <summary>
        /// On unit respond.
        /// </summary>
        /// <param name="command">Respond Command.</param>
        private void OnUnitRespond(Command command)
        {
            if (!IsSettingsValid)
            {
                return;
            }

            CommandManager.RespondCommand(command);
        }
        #endregion

        #region Method
        /// <summary>
        /// Initialize processor.
        /// </summary>
        /// <param name="commandManager">Manager of Commands.</param>
        /// <param name="unitManager">Manager of Command units.</param>
        public void Initialize(ICommandManager commandManager, ICommandUnitManager unitManager)
        {
            CommandManager = commandManager;
            CommandUnitManager = unitManager;
        }
        #endregion
    }
}