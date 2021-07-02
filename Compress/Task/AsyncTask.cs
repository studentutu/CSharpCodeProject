/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  AsyncTask.cs
 *  Description  :  Base async compress task.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  5/30/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;
using System.Threading;

namespace MGS.Compress
{
    /// <summary>
    /// Base async compress task.
    /// </summary>
    internal abstract class AsyncTask : ITask
    {
        /// <summary>
        /// Guid of compressor task.
        /// </summary>
        public string GUID { get; }

        /// <summary>
        /// State of compressor task.
        /// </summary>
        public TaskState State { protected set; get; }

        /// <summary>
        /// Entries associated with the task.
        /// </summary>
        public abstract IEnumerable<string> Entries { get; }

        protected ICompressor compressor = null;
        protected bool clearBefor = true;
        protected Action<float> progressCallback = null;
        protected Action<bool, object> finishedCallback = null;
        protected Thread thread;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="compressor"></param>
        /// <param name="clearBefor"></param>
        /// <param name="progressCallback"></param>
        /// <param name="finishedCallback"></param>
        public AsyncTask(ICompressor compressor, bool clearBefor = true,
               Action<float> progressCallback = null, Action<bool, object> finishedCallback = null)
        {
            GUID = Guid.NewGuid().ToString();

            this.compressor = compressor;
            this.clearBefor = clearBefor;
            this.progressCallback = progressCallback;
            this.finishedCallback = finishedCallback;
        }

        /// <summary>
        /// Start compressor task.
        /// </summary>
        public void Start()
        {
            if (State == TaskState.Working)
            {
                return;
            }

            thread = new Thread(() =>
            {
                Execute();
                State = TaskState.Finished;
            })
            { IsBackground = true };

            thread.Start();
            State = TaskState.Working;
        }

        /// <summary>
        /// Abort compressor task.
        /// </summary>
        public void Abort()
        {
            if (State != TaskState.Working)
            {
                return;
            }

            thread.Abort();
            State = TaskState.Finished;
        }

        /// <summary>
        /// Execute task operate.
        /// </summary>
        protected abstract void Execute();
    }
}