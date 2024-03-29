﻿/*************************************************************************
 *  Copyright (C) 2017-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  KeyFrame.cs
 *  Description  :  Key frame base on time and value.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/26/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.Mathematics.Curve
{
    /// <summary>
    /// Key frame base on time and value.
    /// </summary>
    [Serializable]
    public struct KeyFrame
    {
        /// <summary>
        /// Time of key frame.
        /// </summary>
        public double time;

        /// <summary>
        /// Value of key frame.
        /// </summary>
        public double value;

        /// <summary>
        /// In tangent of key frame.
        /// </summary>
        public double inTangent;

        /// <summary>
        /// Out tangent of key frame.
        /// </summary>
        public double outTangent;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="time">Time of key frame.</param>
        /// <param name="value">Value of key frame.</param>
        public KeyFrame(double time, double value)
        {
            this.time = time;
            this.value = value;
            inTangent = 0;
            outTangent = 0;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="time">Time of key frame.</param>
        /// <param name="value">Value of key frame.</param>
        /// <param name="inTangent">In tangent of key frame.</param>
        /// <param name="outTangent">Out tangent of key frame.</param>
        public KeyFrame(double time, double value, double inTangent, double outTangent)
        {
            this.time = time;
            this.value = value;
            this.inTangent = inTangent;
            this.outTangent = outTangent;
        }
    }
}