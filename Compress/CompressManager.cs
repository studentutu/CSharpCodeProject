/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CompressManager.cs
 *  Description  :  Compress manager.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  5/30/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.DesignPattern;
using System;
using System.Collections.Generic;

namespace MGS.Compress
{
    /// <summary>
    /// Compress manager.
    /// </summary>
    public class CompressManager : Singleton<CompressManager>, ICompressManager
    {
        #region Field and Property
        /// <summary>
        /// Compressor for manager.
        /// </summary>
        public ICompressor Compressor { set; get; }

        /// <summary>
        /// Max run count of async operate.
        /// </summary>
        public int MaxRunCount { set; get; }
        #endregion

        #region Private Method
        /// <summary>
        /// Constructor.
        /// </summary>
        private CompressManager()
        {
            Compressor = IonicCompressor.Instance;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Compress entrie[Files or Directories] to dest file async.
        /// </summary>
        /// <param name="entries">Target entrie[Files or Directories].</param>
        /// <param name="destFile">The dest file.</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="completeCallback">Complete callback.</param>
        public void CompressAsync(IEnumerable<string> entries, string destFile,
            Action<float> progressCallback = null,
            Action<bool, string> completeCallback = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Decompress file to dest dir async.
        /// </summary>
        /// <param name="filePath">Target file.</param>
        /// <param name="destDir">The dest decompress directory.</param>
        /// <param name="clear">Clear the dest dir before decompress.</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="completeCallback">Complete callback.</param>
        public void DecompressAsync(string filePath, string destDir, bool clear = false,
            Action<float> progressCallback = null,
            Action<bool, string> completeCallback = null)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}