/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GenericTable.cs
 *  Description  :  Generic sqlite table.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/9/2020
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Sqlite
{
    /// <summary>
    /// Generic sqlite table.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericTable<T> : GenericView<T>, IGenericTable<T> where T : ISqliteRow, new()
    {
        /// <summary>
        /// Instance of sqlite table.
        /// </summary>
        protected new ISqliteTable source;

        /// <summary>
        /// Constructor of GenericTable.
        /// </summary>
        /// <param name="table">Instance of sqlite table.</param>
        public GenericTable(ISqliteTable table) : base(table)
        {
            source = table;
        }

        /// <summary>
        /// Insert row to table.
        /// </summary>
        /// <param name="row"></param>
        /// <returns>Number of rows affected.</returns>
        public void Insert(T row)
        {
            var newRow = dataTable.Rows.Add();
            row.FillTo(newRow);
        }

        /// <summary>
        /// Update row to table.
        /// </summary>
        /// <param name="row"></param>
        /// <returns>Number of rows affected.</returns>
        public void Update(T row)
        {
            var key = row.PrimaryValue;
            if (!dataTable.Rows.Contains(key))
            {
                return;
            }

            var dataRow = dataTable.Rows.Find(key);
            dataRow.BeginEdit();
            row.FillTo(dataRow);
            dataRow.EndEdit();
        }

        /// <summary>
        /// Delete row from table.
        /// </summary>
        /// <param name="row"></param>
        /// <returns>Number of rows affected.</returns>
        public void Delete(T row)
        {
            Delete(row.PrimaryValue);
        }

        /// <summary>
        /// Delete row from table.
        /// </summary>
        /// <param name="key">Value of the primary key.</param>
        /// <returns>Number of rows affected.</returns>
        public void Delete(object key)
        {
            if (!dataTable.Rows.Contains(key))
            {
                return;
            }

            var dataRow = dataTable.Rows.Find(key);
            dataRow.Delete();
        }

        /// <summary>
        /// Commit modifications to data base.
        /// </summary>
        /// <returns>Number of rows affected.</returns>
        public int Commit()
        {
            var lines = source.Update(dataTable);
            if (lines > 0)
            {
                dataTable.AcceptChanges();
            }
            return lines;
        }
    }
}