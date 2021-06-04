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

using MGS.Common.Generic;
using MGS.DesignPattern;
using System;
using System.Collections.Generic;
using System.Timers;

namespace MGS.Compress
{
    /// <summary>
    /// Compress manager.
    /// </summary>
    public sealed class CompressManager : SingleTimer<CompressManager>, ICompressManager
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

        /// <summary>
        /// List to cache tasks.
        /// </summary>
        private List<ICompressTask> tasks = new List<ICompressTask>();
        #endregion

        #region Private Method
        /// <summary>
        /// Constructor.
        /// </summary>
        private CompressManager()
        {
            Compressor = new IonicCompressor();
            MaxRunCount = 10;
        }
        #endregion

        #region Protected Method
        /// <summary>
        /// Timer tick update.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        protected override void TickUpdate(object sender, ElapsedEventArgs e)
        {
            if (tasks.Count == 0)
            {
                return;
            }

            var runner = 0;
            for (int i = 0; i < tasks.Count; i++)
            {
                var task = tasks[i];
                switch (task.State)
                {
                    case TaskState.Idle:
                        if (runner < MaxRunCount)
                        {
                            task.Start();
                        }
                        break;

                    case TaskState.Working:
                        runner++;
                        break;

                    case TaskState.Complete:
                    case TaskState.Error:
                        tasks.Remove(task);
                        i--;
                        break;
                }
            }
        }

        /// <summary>
        /// Add task to cache list.
        /// </summary>
        /// <param name="task"></param>
        private void AddTask(ICompressTask task)
        {
            tasks.Add(task);
        }

        /// <summary>
        /// Check compressor is valid?
        /// </summary>
        /// <param name="compressor"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        private bool CheckCompressor(ICompressor compressor, out string error)
        {
            error = null;
            if (compressor == null)
            {
                error = "The compressor for manager does not set an instance.";
                return false;
            }

            return true;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Compress entrie[Files or Directories] to dest file async.
        /// </summary>
        /// <param name="entries">Target entrie[Files or Directories].</param>
        /// <param name="destFile">The dest file.</param>
        /// <param name="clearBefor">Clear origin file(if exists) befor compress.</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="completeCallback">Complete callback.</param>
        public void CompressAsync(IEnumerable<string> entries, string destFile, bool clearBefor = true,
            Action<float> progressCallback = null, Action<bool, string> completeCallback = null)
        {
            if (entries == null || string.IsNullOrEmpty(destFile))
            {
                DelegateUtility.Invoke(completeCallback, false, "The params is invalid.");
                return;
            }

            if (!CheckCompressor(Compressor, out string error))
            {
                DelegateUtility.Invoke(completeCallback, false, error);
                return;
            }

            var task = new CompressTask(Compressor, entries, destFile, clearBefor,
                progress => { DelegateUtility.Invoke(progressCallback, progress); },
                (isSucceed, info) => { DelegateUtility.Invoke(completeCallback, isSucceed, info); });

            AddTask(task);
        }

        /// <summary>
        /// Decompress file to dest dir async.
        /// </summary>
        /// <param name="filePath">Target file.</param>
        /// <param name="destDir">The dest decompress directory.</param>
        /// <param name="clearBefor">Clear the dest dir before decompress.</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="completeCallback">Complete callback.</param>
        public void DecompressAsync(string filePath, string destDir, bool clearBefor = false,
            Action<float> progressCallback = null, Action<bool, string> completeCallback = null)
        {
            if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(destDir))
            {
                DelegateUtility.Invoke(completeCallback, false, "The params is invalid.");
                return;
            }

            if (!CheckCompressor(Compressor, out string error))
            {
                DelegateUtility.Invoke(completeCallback, false, error);
                return;
            }

            var task = new DecompressTask(Compressor, filePath, destDir, clearBefor,
                 progress => { DelegateUtility.Invoke(progressCallback, progress); },
                (isSucceed, info) => { DelegateUtility.Invoke(completeCallback, isSucceed, info); });

            AddTask(task);
        }
        #endregion
    }
}