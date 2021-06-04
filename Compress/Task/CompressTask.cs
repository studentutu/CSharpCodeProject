/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CompressTask.cs
 *  Description  :  File compress task.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  5/30/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;

namespace MGS.Compress
{
    /// <summary>
    /// File compress task.
    /// </summary>
    internal class CompressTask : Task
    {
        protected IEnumerable<string> entries;
        protected string destFile;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="compressor"></param>
        /// <param name="entries"></param>
        /// <param name="destFile"></param>
        /// <param name="clearBefor"></param>
        /// <param name="progressCallback"></param>
        /// <param name="completeCallback"></param>
        public CompressTask(ICompressor compressor,
            IEnumerable<string> entries, string destFile, bool clearBefor = true,
            Action<float> progressCallback = null, Action<bool, string> completeCallback = null) :
            base(compressor, clearBefor, progressCallback, completeCallback)
        {
            this.entries = entries;
            this.destFile = destFile;
        }

        /// <summary>
        /// Start compressor task.
        /// </summary>
        public override void Start()
        {
            State = TaskState.Working;
            compressor.Compress(entries, destFile, clearBefor,
                progressCallback, (isSucceed, info) =>
                {
                    State = isSucceed ? TaskState.Complete : TaskState.Error;
                    completeCallback?.Invoke(isSucceed, info);
                });
        }
    }
}