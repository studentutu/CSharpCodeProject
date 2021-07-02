/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ITask.cs
 *  Description  :  Interface for task.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  5/30/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;

namespace MGS.Compress
{
    /// <summary>
    /// Interface for compressor task.
    /// </summary>
    internal interface ITask
    {
        /// <summary>
        /// State of task.
        /// </summary>
        TaskState State { get; }

        /// <summary>
        /// Entries associated with the task.
        /// </summary>
        IEnumerable<string> Entries { get; }

        /// <summary>
        /// Start task.
        /// </summary>
        void Start();
    }

    /// <summary>
    /// State of task.
    /// </summary>
    internal enum TaskState
    {
        /// <summary>
        /// 
        /// </summary>
        Idle,

        /// <summary>
        /// 
        /// </summary>
        Working,

        /// <summary>
        /// 
        /// </summary>
        Finished
    }
}