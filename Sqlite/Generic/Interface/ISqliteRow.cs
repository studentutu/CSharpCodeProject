/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ISqliteRow.cs
 *  Description  :  Interface for sqlite table row.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/5/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Data;

namespace MGS.Sqlite
{
    /// <summary>
    /// Interface for sqlite table row.
    /// </summary>
    public interface ISqliteRow
    {
        /// <summary>
        /// Statement of the columns.
        /// </summary>
        string Statement { get; }

        /// <summary>
        /// Name of primary key.
        /// </summary>
        string PrimaryKey { get; }

        /// <summary>
        /// Value of primary key.
        /// </summary>
        object PrimaryValue { get; }

        /// <summary>
        /// Fill this object from data row.
        /// </summary>
        /// <param name="row"></param>
        void FillFrom(DataRow row);

        /// <summary>
        /// Fill this object to data row.
        /// </summary>
        /// <param name="row"></param>
        void FillTo(DataRow row);
    }
}