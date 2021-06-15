/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  FileCache.cs
 *  Description  :  Cache for file.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  6/15/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Crypto;
using MGS.Logger;
using System;
using System.IO;

namespace MGS.Common.IO
{
    /// <summary>
    /// Cache for file.
    /// </summary>
    public class FileCache
    {
        /// <summary>
        /// Directory for file cache.
        /// </summary>
        protected string cacheDir;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="cacheDir">Directory for file cache.</param>
        public FileCache(string cacheDir)
        {
            this.cacheDir = cacheDir;
            DirectoryUtility.RequireDirectory(cacheDir);
        }

        /// <summary>
        /// Resolve file path from cache by key.
        /// </summary>
        /// <param name="key">Key for cache file.</param>
        /// <returns>File path from cache by key.</returns>
        public virtual string ResolveFile(string key)
        {
            return string.Format("{0}/{1}.cache", key, cacheDir);
        }

        /// <summary>
        /// Find the cache file from cache by key.
        /// </summary>
        /// <param name="key">Key for cache file.</param>
        /// <param name="md5Hash">Matching file md5 hash [Do not check md5 hash if the value is null or empty].</param>
        /// <returns>The path of cache file from cache by key.</returns>
        public string FindFile(string key, string md5Hash)
        {
            var filePath = ResolveFile(key);
            if (File.Exists(filePath))
            {
                if (string.IsNullOrEmpty(md5Hash))
                {
                    return filePath;
                }

                var fileMd5 = MD5CryptoUtility.ComputeFileHash(filePath);
                if (fileMd5.Equals(md5Hash))
                {
                    return filePath;
                }
            }
            return null;
        }

        /// <summary>
        /// Copy the file in to cache.
        /// </summary>
        /// <param name="file">The target file path.</param>
        /// <param name="key">Key for cache file [Use md5 hash of file path as key if the value is null or empty].</param>
        /// <returns>The key for cache file.</returns>
        public string CopyFrom(string file, string key = null)
        {
            if (!File.Exists(file))
            {
                return null;
            }

            if (string.IsNullOrEmpty(key))
            {
                key = MD5CryptoUtility.ComputeHash(file);
            }

            var cacheFile = ResolveFile(key);
            if (!DirectoryUtility.RequireDirectory(cacheFile))
            {
                return null;
            }

            try
            {
                File.Copy(file, cacheFile, true);
                return key;
            }
            catch (Exception ex)
            {
                LogUtility.LogError("Copy cache file from {0} to {1} for key {2} exception: {3}\r\n{4}",
                    file, cacheFile, key, ex.Message, ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Copy the cache file to dest file by the key.
        /// </summary>
        /// <param name="key">Key for cache file.</param>
        /// <param name="destFile"></param>
        /// <returns>Is Succeed?</returns>
        public bool CopyTo(string key, string destFile)
        {
            var cacheFile = ResolveFile(key);
            if (string.IsNullOrEmpty(key))
            {
                return false;
            }

            if (!DirectoryUtility.RequireDirectory(destFile))
            {
                return false;
            }

            try
            {
                File.Copy(cacheFile, destFile, true);
                return true;
            }
            catch (Exception ex)
            {
                LogUtility.LogError("Copy cache file {0} to {1} by key {2} exception: {3}\r\n{4}",
                    cacheFile, destFile, key, ex.Message, ex.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// Clear the cache file by key.
        /// </summary>
        /// <param name="key">Key for cache file.</param>
        public void Clear(string key)
        {
            var cacheFile = ResolveFile(key);
            if (string.IsNullOrEmpty(key))
            {
                return;
            }

            try
            {
                File.Delete(cacheFile);
            }
            catch (Exception ex)
            {
                LogUtility.LogError("Clear cache file by key {0} exception: {1}\r\n{2}", key, ex.Message, ex.StackTrace);
            }
        }

        /// <summary>
        /// Clear all of the cache files.
        /// </summary>
        public void Clear()
        {
            DirectoryUtility.DeleteChildrenEntries(cacheDir);
        }
    }
}