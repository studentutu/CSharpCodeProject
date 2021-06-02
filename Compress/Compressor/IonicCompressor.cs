/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IonicCompressor.cs
 *  Description  :  Ionic compressor.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  5/30/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using Ionic.Zip;
using MGS.DesignPattern;
using System;
using System.Collections.Generic;
using System.IO;

namespace MGS.Compress
{
    /// <summary>
    /// Ionic compressor.
    /// </summary>
    public class IonicCompressor : Singleton<IonicCompressor>, ICompressor
    {
        #region Private Method
        /// <summary>
        /// Constructor.
        /// </summary>
        private IonicCompressor() { }
        #endregion

        #region Public Method
        /// <summary>
        /// Compress entrie[Files or Directories] to dest file.
        /// </summary>
        /// <param name="entries">Target entrie[Files or Directories].</param>
        /// <param name="destFile">The dest file.</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="completeCallback">Complete callback.</param>
        public void Compress(IEnumerable<string> entries, string destFile,
            Action<float> progressCallback = null,
           Action<bool, string> completeCallback = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Decompress file to dest dir [Support zip].
        /// </summary>
        /// <param name="filePath">Target file.</param>
        /// <param name="destDir">The dest decompress directory.</param>
        /// <param name="clear">Clear the dest dir before decompress.</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="completeCallback">Complete callback.</param>
        public void Decompress(string filePath, string destDir, bool clear = false,
            Action<float> progressCallback = null,
            Action<bool, string> completeCallback = null)
        {
            try
            {
                if (clear)
                {
                    if (Directory.Exists(destDir))
                    {
                        Directory.Delete(destDir, true);
                    }
                }

                using (var zipFile = new ZipFile(filePath))
                {
                    zipFile.ExtractProgress += (s, e) =>
                    {
                        if (e == null || e.EntriesTotal == 0)
                        {
                            return;
                        }

                        var progress = (float)e.EntriesExtracted / e.EntriesTotal;
                        progressCallback?.Invoke(progress);
                    };
                    zipFile.ExtractAll(destDir, ExtractExistingFileAction.OverwriteSilently);
                }

                completeCallback?.Invoke(true, destDir);
            }
            catch (Exception ex)
            {
                var error = string.Format("Decompress file exception: {0}\r\n{1}", ex.Message, ex.StackTrace);
                completeCallback?.Invoke(false, error);
            }
        }
        #endregion
    }
}