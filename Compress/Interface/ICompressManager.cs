/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ICompressManager.cs
 *  Description  :  Interface for compress manager.
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
    /// Interface for compress manager.
    /// </summary>
    public interface ICompressManager
    {
        #region Property
        /// <summary>
        /// Compressor for manager.
        /// </summary>
        ICompressor Compressor { set; get; }

        /// <summary>
        /// Max run count of async operate.
        /// </summary>
        int MaxRunCount { set; get; }
        #endregion

        #region Method
        /// <summary>
        /// Compress entrie[files or directories] to dest file async.
        /// </summary>
        /// <param name="entries">Target entrie[files or directories].</param>
        /// <param name="destFile">The dest file.</param>
        /// <param name="encoding">Encoding for zip file.</param>
        /// <param name="directoryPathInArchive">Directory path in archive of zip file.</param>
        /// <param name="clearBefor">Clear origin file(if exists) befor compress.</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="finishedCallback">Finished callback.</param>
        /// <returns>Guid of async operate.</returns>
        string CompressAsync(IEnumerable<string> entries, string destFile,
            Encoding encoding, string directoryPathInArchive = null, bool clearBefor = true,
            Action<float> progressCallback = null, Action<bool, object> finishedCallback = null);

        /// <summary>
        /// Decompress file to dest dir async.
        /// </summary>
        /// <param name="filePath">Target file.</param>
        /// <param name="destDir">The dest decompress directory.</param>
        /// <param name="clearBefor">Clear the dest dir before decompress.</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="finishedCallback">Finished callback.</param>
        /// <returns>Guid of async operate.</returns>
        string DecompressAsync(string filePath, string destDir, bool clearBefor = true,
            Action<float> progressCallback = null, Action<bool, object> finishedCallback = null);

        /// <summary>
        /// Abort async operate.
        /// </summary>
        /// <param name="guid">Guid of async operate.</param>
        void AbortAsync(string guid);
        #endregion
    }
}