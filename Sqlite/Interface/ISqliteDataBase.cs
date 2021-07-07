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

        /// <summary>
        /// Connect to the table for the T type row from data base.
        /// [Create file and table if not exist]
        /// </summary>
        /// <typeparam name="T">Type of the table row.</typeparam>
        /// <param name="name">Name of table.</param>
        /// <returns></returns>
        ISqliteTable<T> ConnectTable<T>(string name) where T : ISqliteRow, new();

        /// <summary>
        /// Delete the table from data base.
        /// </summary>
        /// <param name="name">The name of table.</param>
        /// <returns>Number of rows affected.</returns>
        int DeleteTable(string name);
    }
}