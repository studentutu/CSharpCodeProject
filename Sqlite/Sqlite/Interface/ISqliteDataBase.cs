/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ISqliteDataBase.cs
 *  Description  :  Interface for sqlite data base.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/5/2020
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Sqlite
{
    /// <summary>
    /// Interface for sqlite data base.
    /// </summary>
    public interface ISqliteDataBase
    {
        #region
        /// <summary>
        /// 
        /// </summary>
        /// <param name="statement"></param>
        /// <returns></returns>
        int CreateView(string statement);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ISqliteView SelectView(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        int DeleteView(string name);
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        /// <param name="statement"></param>
        /// <returns></returns>
        int CreateTable(string statement);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ISqliteTable SelectTable(string name);

        /// <summary>
        /// Delete the table from data base.
        /// </summary>
        /// <param name="name">The name of table.</param>
        /// <returns>Number of rows affected.</returns>
        int DeleteTable(string name);
        #endregion
    }
}