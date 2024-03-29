﻿/*************************************************************************
 *  Copyright (C) 2017-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  HermiteCurve.cs
 *  Description  :  Define piecewise three hermite spline curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/26/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;

namespace MGS.Mathematics.Curve
{
    /// <summary>
    /// Piecewise three hermite spline curve.
    /// </summary>
    public class HermiteCurve
    {
        #region
        /// <summary>
        /// Indexer.
        /// </summary>
        /// <param name="index">Index of key frame.</param>
        /// <returns>The key frame at index.</returns>
        public KeyFrame this[int index]
        {
            set { frames[index] = value; }
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
        public HermiteCurve(IEnumerable<KeyFrame> frames)
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
        public void AddFrame(float time, double value)
        {
            frames.Add(new KeyFrame(time, value));
        }

        /// <summary>
        /// Add key frames to curve.
        /// </summary>
        /// <param name="frames"></param>
        public void AddFrames(IEnumerable<KeyFrame> frames)
        {
            this.frames.AddRange(frames);
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
        /// Clear frames.
        /// </summary>
        public void ClearFrames()
        {
            frames.Clear();
        }

        /// <summary>
        /// Smooth in and out tangents.
        /// </summary>
        /// <param name="weight"></param>
        public void SmoothTangents(float weight = 0)
        {
            for (int i = 0; i < frames.Count; i++)
            {
                SmoothTangents(i, weight);
            }
        }

        /// <summary>
        /// Smooth in and out tangents.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="weight"></param>
        public void SmoothTangents(int index, float weight)
        {
            if (index < 0 || index > frames.Count - 1)
            {
                return;
            }

            //Designed By Mogoson.
            KeyFrame k0, k1, k2;
            if (index == 0 || index == frames.Count - 1)
            {
                if (frames.Count < 2 || frames[0].value != frames[frames.Count - 1].value)
                {
                    var frame = frames[index];
                    frame.inTangent = frame.outTangent = 0;
                    frames[index] = frame;
                    return;
                }

                k0 = frames[frames.Count - 2];
                k1 = frames[index];
                k2 = frames[1];

                if (index == 0)
                {
                    k0.time -= frames[frames.Count - 1].time;
                }
                else
                {
                    k2.time += frames[frames.Count - 1].time;
                }
            }
            else
            {
                k0 = frames[index - 1];
                k1 = frames[index];
                k2 = frames[index + 1];
            }

            var weight01 = (1 + weight) / 2;
            var weight12 = (1 - weight) / 2;
            var t01 = (k1.value - k0.value) / (k1.time - k0.time);
            var t12 = (k2.value - k1.value) / (k2.time - k1.time);
            k1.inTangent = k1.outTangent = t01 * weight01 + t12 * weight12;
            frames[index] = k1;
        }

        /// <summary>
        /// Evaluate the curve at t.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public double Evaluate(float t)
        {
            return Evaluate(frames.ToArray(), t);
        }
        #endregion

        #region
        /// <summary>
        /// Evaluate the value of hermite curve at time.
        /// </summary>
        /// <param name="frames">Key frames of hermite curve.</param>
        /// <param name="t"></param>
        /// <returns>The value of hermite curve at time.</returns>
        public static double Evaluate(KeyFrame[] frames, float t)
        {
            if (frames == null || frames.Length == 0)
            {
                return 0;
            }

            if (frames.Length == 1)
            {
                return frames[0].value;
            }

            if (t <= frames[0].time)
            {
                return frames[0].value;
            }

            if (t >= frames[frames.Length - 1].time)
            {
                return frames[frames.Length - 1].value;
            }

            var fr = 0;
            var to = frames.Length;
            while (fr < to)
            {
                var hf = fr + (to - fr) / 2;
                if (frames[hf].time == t)
                {
                    return frames[hf].value;
                }

                if (frames[hf].time < t)
                {
                    if (frames[hf + 1].time == t)
                    {
                        return frames[hf + 1].value;
                    }

                    if (frames[hf + 1].time > t)
                    {
                        return Evaluate(frames[hf], frames[hf + 1], t);
                    }

                    if (fr == hf)
                    {
                        return 0;
                    }
                    fr = hf;
                }
                else
                {
                    if (frames[hf - 1].time == t)
                    {
                        return frames[hf - 1].value;
                    }

                    if (frames[hf - 1].time < t)
                    {
                        return Evaluate(frames[hf - 1], frames[hf], t);
                    }

                    if (to == hf)
                    {
                        return 0;
                    }
                    to = hf;
                }
            }
            return 0;
        }

        /// <summary>
        /// Evaluate the value of hermite curve at time on the range from start key frame to end key frame.
        /// </summary>
        /// <param name="start">Start Key frame of hermite curve.</param>
        /// <param name="end">End Key frame of hermite curve.</param>
        /// <param name="t">Time of curve to evaluate value.</param>
        /// <returns>The value of hermite curve at time on the range from start key frame to end key frame.</returns>
        public static double Evaluate(KeyFrame start, KeyFrame end, float t)
        {
            return Evaluate(start.time, start.value, start.outTangent, end.time, end.value, end.inTangent, t);
        }

        /// <summary>
        /// Hermite interpolate between t0 and t1 by t.
        /// </summary>
        /// <param name="t0">Time of t0.</param>
        /// <param name="v0">Value of t0.</param>
        /// <param name="m0">Micro quotient value of t0.</param>
        /// <param name="t1">Time of t1.</param>
        /// <param name="v1">Value of t1.</param>
        /// <param name="m1">Micro quotient value of t1.</param>
        /// <param name="t">t is between t0 and t1.</param>
        /// <returns></returns>
        public static double Evaluate(double t0, double v0, double m0, double t1, double v1, double m1, float t)
        {
            /*  Designed By Mogoson.
             *  Hermite Polynomial Structure
             *  Base: H(t) = v0a0(t) + v1a1(t) + m0b0(t) + m1b1(t)
             * 
             *                     t-t0    t-t1  2
             *        a0(t) = (1+2------)(------)
             *                     t1-t0   t0-t1
             *                    
             *                     t-t1    t-t0  2
             *        a1(t) = (1+2------)(------)
             *                     t0-t1   t1-t0
             * 
             *                        t-t1  2
             *        b0(t) = (t-t0)(------)
             *                        t0-t1
             * 
             *                        t-t0  2
             *        b1(t) = (t-t1)(------)
             *                        t1-t0
             * 
             *  Let:  d0 = t-t0, d1 = t-t1, d = t0-t1
             * 
             *              d0          d1
             *        q0 = ---- , q1 = ----
             *              d           d
             * 
             *               t-t1  2     d1  2     2          t-t0  2     d0  2     2
             *        p0 = (------)  = (----)  = q1  , p1 = (------)  = (----)  = q0
             *               t0-t1       d                    t1-t0       -d
             * 
             *  Get:  H(t) = (1-2q0)v0p0 + (1+2q1)v1p1 + mod0p0 + m1d1p1
             */

            var d0 = t - t0;
            var d1 = t - t1;
            var d = t0 - t1;

            var q0 = d0 / d;
            var q1 = d1 / d;

            var p0 = q1 * q1;
            var p1 = q0 * q0;

            return (1 - 2 * q0) * v0 * p0 + (1 + 2 * q1) * v1 * p1 + m0 * d0 * p0 + m1 * d1 * p1;
        }
        #endregion
    }
}