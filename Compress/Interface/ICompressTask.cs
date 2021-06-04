/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ICompressTask.cs
 *  Description  :  Interface for compressor task.
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
    internal interface ICompressTask
    {
        /// <summary>
        /// State of compressor task.
        /// </summary>
        TaskState State { get; }

        /// <summary>
        /// Start compressor task.
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
        Complete,

        /// <summary>
        /// 
        /// </summary>
        Error
    }
}