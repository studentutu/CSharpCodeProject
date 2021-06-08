/*************************************************************************
 *  Copyright ? 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ISubtitle.cs
 *  Description  :  Interface of subtitle.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  4/25/2019
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Media.Subtitle
{
    /// <summary>
    /// Interface of subtitle.
    /// </summary>
    public interface ISubtitle
    {
        #region Method
        /// <summary>
        /// Get subtitle clip content at play time.
        /// </summary>
        /// <param name="time">Play time(Milliseconds) of clip.</param>
        /// <returns>Subtitle clip content.</returns>
        string GetClip(int time);
        #endregion
    }
}