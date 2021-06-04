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

#if USE_SHARPCOMPRESS
using SharpCompress.Archives;
using SharpCompress.Archives.Zip;
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

                using (var archive = ZipArchive.Create())
                {
                    var index = 0f;
                    var count = new List<string>(entries).Count;
                    foreach (var entry in entries)
                    {
                        archive.AddAllFromDirectory(entry);
                        index++;

                        var progress = (index / count) * 0.75f;
                        progressCallback?.Invoke(progress);
                    }

                    using (var stream = File.OpenWrite(destFile))
                    {
                        archive.SaveTo(stream);
                    }

                    progressCallback?.Invoke(1.0f);
                    completeCallback?.Invoke(true, destFile);
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
#endif