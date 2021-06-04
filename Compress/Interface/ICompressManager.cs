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
        /// Compress entrie[Files or Directories] to dest file async.
        /// </summary>
        /// <param name="entries">Target entrie[Files or Directories].</param>
        /// <param name="destFile">The dest file.</param>
        /// <param name="clearBefor">Clear origin file(if exists) befor compress.</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="completeCallback">Complete callback.</param>
        void CompressAsync(IEnumerable<string> entries, string destFile, bool clearBefor = true,
               Action<float> progressCallback = null, Action<bool, string> completeCallback = null);

        /// <summary>
        /// Decompress file to dest dir async.
        /// </summary>
        /// <param name="filePath">Target file.</param>
        /// <param name="destDir">The dest decompress directory.</param>
        /// <param name="clearBefor">Clear the dest dir before decompress.</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="completeCallback">Complete callback.</param>
        void DecompressAsync(string filePath, string destDir, bool clearBefor = true,
            Action<float> progressCallback = null, Action<bool, string> completeCallback = null);
        #endregion
    }
}