﻿/*************************************************************************
 *  Copyright (C) 2015-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Circle.cs
 *  Description  :  Circle in plane rectangular coordinate system.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  2/26/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.Mathematics.Geometry
{
    /// <summary>
    /// Circle in plane rectangular coordinate system.
    /// </summary>
    [Serializable]
    public struct Circle
    {
        /*  Circle Definition
         *                       2            2     2
         *  Circle is : (x - c.x)  + (y - c.y)  = r
         */

        /// <summary>
        /// Center.
        /// </summary>
        public Vector2 c;

        /// <summary>
        /// Radius.
        /// </summary>
        public double r;

        /// <summary>
        /// Unit circle.
        /// </summary>
        public static Circle Unit
        {
            get { return new Circle(Vector2.Zero, 1); }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="c">Center.</param>
        /// <param name="r">Radius.</param>
        public Circle(Vector2 c, double r)
        {
            this.c = c;
            this.r = r;
        }
    }
}
