/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  DecompressTask.cs
 *  Description  :  File decompress task.
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
    /// File decompress task.
    /// </summary>
    internal class DecompressTask : Task
    {
        protected string filePath;
        protected string destDir;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="compressor"></param>
        /// <param name="filePath"></param>
        /// <param name="destDir"></param>
        /// <param name="clearBefor"></param>
        /// <param name="progressCallback"></param>
        /// <param name="completeCallback"></param>
        public DecompressTask(ICompressor compressor,
            string filePath, string destDir, bool clearBefor = true,
            Action<float> progressCallback = null, Action<bool, object> completeCallback = null) :
            base(compressor, clearBefor, progressCallback, completeCallback)
        {
            this.filePath = filePath;
            this.destDir = destDir;
        }

        /// <summary>
        /// Start decompress task.
        /// </summary>
        public override void Start()
        {
            State = TaskState.Working;
            compressor.Decompress(filePath, destDir, clearBefor,
                progressCallback, (isSucceed, info) =>
                {
                    State = isSucceed ? TaskState.Complete : TaskState.Error;
                    completeCallback?.Invoke(isSucceed, info);
                });
        }
    }
}