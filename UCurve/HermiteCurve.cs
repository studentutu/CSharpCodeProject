/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  HermiteCurve.cs
 *  Description  :  Define hermite curve
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  8/20/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;

namespace MGS.UCurve
{
    /// <summary>
    /// Hermite curve
    /// </summary>
    public class HermiteCurve : ITimeCurve
    {
        #region
        /// <summary>
        /// Indexer.
        /// </summary>
        /// <param name="index">Index of key frame.</param>
        /// <returns>The key frame at index.</returns>
        public KeyFrame this[int index]
        {
            get { return frames[index]; }
        }

        /// <summary>
        /// Key frames of curve.
        /// </summary>
        protected List<KeyFrame> frames = new List<KeyFrame>();

        /// <summary>
        /// Count of key frames.
        /// </summary>
        public int FramesCount { get { return frames.Count; } }
        #endregion

        #region
        /// <summary>
        /// Constructor.
        /// </summary>
        public HermiteCurve() { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="frames">Key frames of curve.</param>
        public HermiteCurve(KeyFrame[] frames)
        {
            this.frames.AddRange(frames);
        }

        /// <summary>
        /// Add key frame to curve.
        /// </summary>
        /// <param name="frame">Key frame to add.</param>
        public void AddFrame(KeyFrame frame)
        {
            frames.Add(frame);
        }

        /// <summary>
        /// Add key frame to curve.
        /// </summary>
        /// <param name="time">Key of frame.</param>
        /// <param name="value">Value of frame.</param>
        public void AddFrame(double time, Vector3 value)
        {
            frames.Add(new KeyFrame(time, value));
        }

        /// <summary>
        /// Remove key frame.
        /// </summary>
        /// <param name="frame">Key frame to remove.</param>
        public void RemoveFrame(KeyFrame frame)
        {
            frames.Remove(frame);
        }

        /// <summary>
        /// Remove key frame at index.
        /// </summary>
        /// <param name="index">Index of frame.</param>
        public void RemoveFrame(int index)
        {
            frames.RemoveAt(index);
        }

        /// <summary>
        /// Evaluate the curve at t.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public Vector3 Evaluate(float t)
        {
            return Vector3.zero;
        }
        #endregion

        #region
        /// <summary>
        /// Evaluate the value of hermite curve at time.
        /// </summary>
        /// <param name="frames">Key frames of hermite curve.</param>
        /// <param name="t"></param>
        /// <returns>The value of hermite curve at time.</returns>
        public static Vector3 Evaluate(KeyFrame[] frames, double t)
        {
            if (frames == null || frames.Length == 0)
            {
                return Vector3.zero;
            }

            var value = Vector3.zero;
            if (frames.Length == 1)
            {
                value = frames[0].value;
            }
            else
            {
                if (t <= frames[0].time)
                {
                    value = frames[0].value;
                }
                else if (t >= frames[frames.Length - 1].time)
                {
                    value = frames[frames.Length - 1].value;
                }
                else
                {
                    for (int i = 0; i < frames.Length; i++)
                    {
                        if (i == frames[i].time)
                        {
                            value = frames[i].value;
                            break;
                        }

                        if (t > frames[i].time && t < frames[i + 1].time)
                        {
                            value = Evaluate(frames[i], frames[i + 1], t);
                            break;
                        }
                    }
                }
            }
            return value;
        }

        /// <summary>
        /// Evaluate the value of hermite curve at time on the range from start key frame to end key frame.
        /// </summary>
        /// <param name="start">Start Key frame of hermite curve.</param>
        /// <param name="end">End Key frame of hermite curve.</param>
        /// <param name="t">Time of curve to evaluate value.</param>
        /// <returns>The value of hermite curve at time on the range from start key frame to end key frame.</returns>
        public static Vector3 Evaluate(KeyFrame start, KeyFrame end, double t)
        {
            return Vector3.zero;
        }
        #endregion
    }

    /// <summary>
    /// Key frame base on time and value.
    /// </summary>
    [Serializable]
    public struct KeyFrame
    {
        #region Field and Property
        /// <summary>
        /// Time of frame.
        /// </summary>
        public double time;

        /// <summary>
        /// Value of frame.
        /// </summary>
        public Vector3 value;

        /// <summary>
        /// In tangent of frame.
        /// </summary>
        public Vector3 inTangent;

        /// <summary>
        /// Out tangent of frame.
        /// </summary>
        public Vector3 outTangent;
        #endregion

        #region Public Method
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="time">Time of frame.</param>
        /// <param name="value">Value of frame.</param>
        public KeyFrame(double time, Vector3 value)
        {
            this.time = time;
            this.value = value;
            inTangent = Vector3.zero;
            outTangent = Vector3.zero;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="time">Time of frame.</param>
        /// <param name="value">Value of frame.</param>
        /// <param name="inTangent">In tangent of frame.</param>
        /// <param name="outTangent">Out tangent of frame.</param>
        public KeyFrame(double time, Vector3 value, Vector3 inTangent, Vector3 outTangent)
        {
            this.time = time;
            this.value = value;
            this.inTangent = inTangent;
            this.outTangent = outTangent;
        }
        #endregion
    }
}