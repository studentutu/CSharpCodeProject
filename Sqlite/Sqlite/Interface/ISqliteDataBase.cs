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
        /// <summary>
        /// Sqlite handler of this data base.
        /// </summary>
        ISqliteHandler Handler { get; }

        #region
        /// <summary>
        /// Create sqlite view if not exists.
        /// </summary>
        /// <param name="statement">Statement sql for view.</param>
        /// <returns>Number of rows affected.</returns>
        int CreateView(string statement);

        /// <summary>
        /// Select view from data base.
        /// </summary>
        /// <param name="name">Name of view.</param>
        /// <returns></returns>
        ISqliteView SelectView(string name);

        /// <summary>
        /// Delete view from data base.
        /// </summary>
        /// <param name="name">Name of view.</param>
        /// <returns>Number of rows affected.</returns>
        int DeleteView(string name);
        #endregion

        #region
        /// <summary>
        /// Create sqlite table if not exists.
        /// </summary>
        /// <param name="statement">Statement sql for table.</param>
        /// <returns>Number of rows affected.</returns>
        int CreateTable(string statement);

        /// <summary>
        /// Select table from data base.
        /// </summary>
        /// <param name="name">Name of table.</param>
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