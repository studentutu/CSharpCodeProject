/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Task.cs
 *  Description  :  Base compress task.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  5/30/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.Compress
{
    /// <summary>
    /// Base compress task.
    /// </summary>
    internal abstract class Task : ICompressTask
    {
        /// <summary>
        /// State of compressor task.
        /// </summary>
        public TaskState State { protected set; get; }

        protected ICompressor compressor = null;
        protected bool clearBefor = true;
        protected Action<float> progressCallback = null;
        protected Action<bool, string> completeCallback = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="compressor"></param>
        /// <param name="clearBefor"></param>
        /// <param name="progressCallback"></param>
        /// <param name="completeCallback"></param>
        public Task(ICompressor compressor, bool clearBefor = true,
               Action<float> progressCallback = null, Action<bool, string> completeCallback = null)
        {
            this.compressor = compressor;
            this.clearBefor = clearBefor;
            this.progressCallback = progressCallback;
            this.completeCallback = completeCallback;
        }

        /// <summary>
        /// Start compressor task.
        /// </summary>
        public abstract void Start();
    }
}