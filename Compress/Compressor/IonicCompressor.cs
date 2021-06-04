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
using System;
using System.Collections.Generic;
using System.IO;

namespace MGS.Compress
{
    /// <summary>
    /// Ionic compressor.
    /// </summary>
    public class IonicCompressor : ICompressor
    {
        #region Public Method
        /// <summary>
        /// Compress entrie[file or directorie] to dest file.
        /// </summary>
        /// <param name="entries">Target entrie[Files or Directories].</param>
        /// <param name="destFile">The dest file.</param>
        /// <param name="clearBefor">Clear origin file(if exists) befor compress.</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="completeCallback">Complete callback.</param>
        public virtual void Compress(IEnumerable<string> entries, string destFile, bool clearBefor = true,
            Action<float> progressCallback = null, Action<bool, string> completeCallback = null)
        {
            try
            {
                if (clearBefor && File.Exists(destFile))
                {
                    File.Delete(destFile);
                }

                using (var zipFile = new ZipFile(destFile))
                {
                    zipFile.SaveProgress += (s, e) =>
                    {
                        if (e == null || e.EntriesTotal == 0)
                        {
                            return;
                        }

                        var progress = (float)e.EntriesSaved / e.EntriesTotal;
                        progressCallback?.Invoke(progress);
                    };

                    foreach (var entry in entries)
                    {
                        zipFile.AddItem(entry);
                    }
                    zipFile.Save();
                }
            }
            catch (Exception ex)
            {
                var error = string.Format("Compress file exception: {0}\r\n{1}", ex.Message, ex.StackTrace);
                completeCallback?.Invoke(false, error);
            }
        }

        /// <summary>
        /// Decompress file to dest dir [Support .zip].
        /// </summary>
        /// <param name="filePath">Target file.</param>
        /// <param name="destDir">The dest decompress directory.</param>
        /// <param name="clearBefor">Clear the dest dir before decompress.</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="completeCallback">Complete callback.</param>
        public virtual void Decompress(string filePath, string destDir, bool clearBefor = true,
            Action<float> progressCallback = null, Action<bool, string> completeCallback = null)
        {
            try
            {
                if (clearBefor)
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