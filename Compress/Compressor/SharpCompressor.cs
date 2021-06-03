/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SharpCompressor.cs
 *  Description  :  Sharp compressor.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  5/30/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using SharpCompress.Archives;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.IO;

namespace MGS.Compress
{
    /// <summary>
    /// Sharp compressor.
    /// </summary>
    public class SharpCompressor : ICompressor
    {
        #region Public Method
        /// <summary>
        /// Compress entrie[Files or Directories] to dest file.
        /// </summary>
        /// <param name="entries">Target entrie[Files or Directories].</param>
        /// <param name="destFile">The dest file.</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="completeCallback">Complete callback.</param>
        public virtual void Compress(IEnumerable<string> entries, string destFile,
            Action<float> progressCallback = null,
            Action<bool, string> completeCallback = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Decompress file to dest dir [Support zip, rar, tar, gzip, 7z].
        /// </summary>
        /// <param name="filePath">Target file.</param>
        /// <param name="destDir">The dest decompress directory.</param>
        /// <param name="clear">Clear the dest dir before decompress.</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="completeCallback">Complete callback.</param>
        public virtual void Decompress(string filePath, string destDir, bool clear = false,
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

                using (var archive = ArchiveFactory.Open(filePath))
                {
                    var totalSize = archive.TotalUncompressSize;
                    long unzipSize = 0;
                    archive.EntryExtractionEnd += (s, e) =>
                    {
                        unzipSize += e.Item.Size;
                        var progress = (float)unzipSize / totalSize;
                        progressCallback?.Invoke(progress);
                    };

                    var options = new ExtractionOptions()
                    {
                        Overwrite = true,
                        ExtractFullPath = true,
                        PreserveFileTime = false,
                        PreserveAttributes = false
                    };

                    foreach (var entry in archive.Entries)
                    {
                        if (!entry.IsDirectory)
                        {
                            entry.WriteToDirectory(destDir, options);
                        }
                    }
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