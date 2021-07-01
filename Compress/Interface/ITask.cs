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

namespace MGS.Compress
{
    /// <summary>
    /// Interface for compressor task.
    /// </summary>
    internal interface ITask
    {
        /// <summary>
        /// Guid of task.
        /// </summary>
        string GUID { get; }

        /// <summary>
        /// State of task.
        /// </summary>
        TaskState State { get; }

        /// <summary>
        /// Start task.
        /// </summary>
        void Start();

        /// <summary>
        /// Abort task.
        /// </summary>
        void Abort();
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