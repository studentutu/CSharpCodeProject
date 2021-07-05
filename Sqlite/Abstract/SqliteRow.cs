/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SqliteRow.cs
 *  Description  :  Sqlite table row.
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
    /// Sqlite table row.
    /// </summary>
    public abstract class SqliteRow : ISqliteRow
    {
        /// <summary>
        /// Statement of the row's columns.
        /// </summary>
        public string ColumnsStatement { protected set; get; }

        /// <summary>
        /// Name of primary key.
        /// </summary>
        public string PrimaryKey { protected set; get; }

        /// <summary>
        /// Value of primary key.
        /// </summary>
        public object PrimaryValue { protected set; get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public SqliteRow()
        {

        }

        /// <summary>
        /// Fill this object from data row.
        /// </summary>
        /// <param name="row"></param>
        public virtual void FillFrom(DataRow row)
        {

        }

        /// <summary>
        /// Fill this object to data row.
        /// </summary>
        /// <param name="row"></param>
        public virtual void FillTo(DataRow row)
        {

        }
    }
}