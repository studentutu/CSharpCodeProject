/*************************************************************************
 *  Copyright (c) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  HTextRowData.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/29/2021
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.UGUI
{
    /// <summary>
    /// HText-Row-Data.
    /// </summary>
    public class HTextRowData
    {
        /// <summary>
        /// 
        /// </summary>
        public string tittle;
        /// <summary>
        /// 
        /// </summary>
        public string content;

        /// <summary>
        /// 
        /// </summary>
        public HTextRowData() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tittle"></param>
        /// <param name="content"></param>
        public HTextRowData(string tittle, string content)
        {
            this.tittle = tittle;
            this.content = content;
        }
    }
}