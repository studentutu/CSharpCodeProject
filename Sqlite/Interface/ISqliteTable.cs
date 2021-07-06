/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ISqliteTable.cs
 *  Description  :  Interface for sqlite table.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/5/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;

namespace MGS.Sqlite
{
    /// <summary>
    /// Interface for sqlite table.
    /// </summary>
    /// <typeparam name="T">Type of the table row.</typeparam>
    public interface ISqliteTable<T> where T : ISqliteRow, new()
    {
        /// <summary>
        /// Name of table.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Select rows from table.
        /// </summary>
        /// <param name="context">Context append to select command.</param>
        /// <returns>Selected rows.</returns>
        ICollection<T> Select(string context);

        /// <summary>
        /// Insert row to table.
        /// </summary>
        /// <param name="row"></param>
        /// <returns>Number of rows affected.</returns>
        void Insert(T row);

        /// <summary>
        /// Update row to table.
        /// </summary>
        /// <param name="row"></param>
        /// <returns>Number of rows affected.</returns>
        void Update(T row);

        /// <summary>
        /// Delete row from table.
        /// </summary>
        /// <param name="row"></param>
        /// <returns>Number of rows affected.</returns>
        void Delete(T row);

        /// <summary>
        /// Delete row from table.
        /// </summary>
        /// <param name="key">Value of the primary key.</param>
        /// <returns>Number of rows affected.</returns>
        void Delete(object key);

        /// <summary>
        /// Commit modifications to data base.
        /// </summary>
        /// <returns>Number of rows affected.</returns>
        int Commit();
    }
}