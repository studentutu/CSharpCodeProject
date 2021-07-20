/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SRTSubtitle.cs
 *  Description  :  SRT subtitle of video.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  4/25/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;

namespace MGS.Media.Subtitle
{
    /// <summary>
    /// SRT subtitle of video.
    /// </summary>
    public class SRTSubtitle : Subtitle
    {
        #region Field and Property
        /// <summary>
        /// Lines count of a clip.
        /// </summary>
        public const int CLIP_LINES = 3;

        /// <summary>
        /// Separator of clip time range.
        /// </summary>
        public static readonly string[] TIMERANGE_SEPARATOR = new string[] { "-->" };

        /// <summary>
        /// Separator of clip time.
        /// </summary>
        public static readonly string[] TIME_SEPARATOR = new string[] { ":", "," };
        #endregion

        #region Protected Method
        /// <summary>
        /// Set source of srt subtitle.
        /// </summary>
        /// <param name="source">Data lines of srt subtitle.</param>
        /// <returns>Succeed?</returns>
        protected void SetSource(IEnumerable<string> source)
        {
            ClearCache();

            if (source == null)
            {
                return;
            }

            var lines = new List<string>(source);
            if (lines.Count < CLIP_LINES)
            {
                return;
            }

            while (lines.Count >= CLIP_LINES)
            {
                if (string.IsNullOrEmpty(lines[0]))
                {
                    lines.RemoveAt(0);
                    continue;
                }

                var newClip = ParseToClip(lines[0], lines[1], lines[2]);
                if (newClip == null)
                {
                    lines.RemoveAt(0);
                    continue;
                }
                else
                {
                    clips.Add(newClip);
                    lines.RemoveRange(0, CLIP_LINES);
                }
            }
        }

        /// <summary>
        /// Parse text to subtitle clip.
        /// </summary>
        /// <param name="index">Index text of clip.</param>
        /// <param name="timeRange">The text of clip time range.</param>
        /// <param name="centent">Content text of clip.</param>
        /// <returns>Subtitle clip.</returns>
        protected SubtitleClip ParseToClip(string index, string timeRange, string centent)
        {
            if (string.IsNullOrEmpty(index) || string.IsNullOrEmpty(timeRange))
            {
                return null;
            }

            if (!int.TryParse(index, out int clipIndex))
            {
                return null;
            }

            if (!ParseToTimeRange(timeRange, out int startTime, out int endTime))
            {
                return null;
            }

            return new SubtitleClip(clipIndex, startTime, endTime, centent);
        }

        /// <summary>
        /// Parse text to the time range of subtitle clip.
        /// </summary>
        /// <param name="timeRange">The text of clip time range.</param>
        /// <param name="startTime">Start time(Milliseconds) of clip.</param>
        /// <param name="endTime">End time(Milliseconds) of clip.</param>
        /// <returns>Is parsed?</returns>
        protected bool ParseToTimeRange(string timeRange, out int startTime, out int endTime)
        {
            startTime = 0;
            endTime = 0;

            var times = timeRange.Split(TIMERANGE_SEPARATOR, StringSplitOptions.RemoveEmptyEntries);
            if (times.Length < 2)
            {
                return false;
            }

            if (ParseToTime(times[0], out startTime))
            {
                return false;
            }

            if (ParseToTime(times[1], out endTime))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Parse text to the time of subtitle clip.
        /// </summary>
        /// <param name="timeText">The text of clip time.</param>
        /// <param name="time">Time(Milliseconds) of clip.</param>
        /// <returns>Is parsed?</returns>
        protected bool ParseToTime(string timeText, out int time)
        {
            time = 0;
            var items = timeText.Split(TIME_SEPARATOR, StringSplitOptions.RemoveEmptyEntries);
            if (items.Length < 3)
            {
                return false;
            }

            if (!int.TryParse(items[0], out int hours))
            {
                return false;
            }

            if (!int.TryParse(items[1], out int minute))
            {
                return false;
            }

            if (!int.TryParse(items[2], out int seconds))
            {
                return false;
            }

            var millisecond = 0;
            if (items.Length > 3)
            {
                int.TryParse(items[3], out millisecond);
            }

            time = ((hours * 60 + minute) * 60 + seconds) * 1000 + millisecond;
            return true;
        }

        /// <summary>
        /// Clear subtitle cache.
        /// </summary>
        protected virtual void ClearCache()
        {
            clips.Clear();
            clip = null;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="source">Data lines of srt subtitle.</param>
        public SRTSubtitle(IEnumerable<string> source)
        {
            SetSource(source);
        }
        #endregion
    }
}