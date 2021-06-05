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
using System.Text;

namespace MGS.Compress
{
    /// <summary>
    /// File compress task.
    /// </summary>
    internal class CompressTask : Task
    {
        protected IEnumerable<string> entries;
        protected string destFile;
        protected Encoding encoding;
        protected string directoryPathInArchive;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="compressor"></param>
        /// <param name="entries">Target entrie[files or directories].</param>
        /// <param name="destFile">The dest file.</param>
        /// <param name="encoding">Encoding for zip file.</param>
        /// <param name="directoryPathInArchive">Directory path in archive of zip file.</param>
        /// <param name="clearBefor">Clear origin file(if exists) befor compress.</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="completeCallback">Complete callback.</param>
        public CompressTask(ICompressor compressor,
            IEnumerable<string> entries, string destFile,
            Encoding encoding, string directoryPathInArchive = null, bool clearBefor = true,
            Action<float> progressCallback = null, Action<bool, string> completeCallback = null) :
            base(compressor, clearBefor, progressCallback, completeCallback)
        {
            this.entries = entries;
            this.destFile = destFile;

            this.encoding = encoding;
            this.directoryPathInArchive = directoryPathInArchive;
        }

        /// <summary>
        /// Start compressor task.
        /// </summary>
        public override void Start()
        {
            State = TaskState.Working;
            compressor.Compress(entries, destFile, encoding, directoryPathInArchive, clearBefor,
                progressCallback, (isSucceed, info) =>
                {
                    State = isSucceed ? TaskState.Complete : TaskState.Error;
                    completeCallback?.Invoke(isSucceed, info);
                });
        }
    }
}