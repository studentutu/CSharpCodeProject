/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SqliteTable.cs
 *  Description  :  Generic sqlite table.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/7/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using System.Data;

namespace MGS.Sqlite
{
    /// <summary>
    /// Generic sqlite table.
    /// </summary>
    public class SqliteTable<T> : ISqliteTable<T> where T : ISqliteRow, new()
    {
        #region
        /// <summary>
        /// Name of table.
        /// </summary>
        public string Name { protected set; get; }

        /// <summary>
        /// Avatar instance of type T.
        /// </summary>
        protected T avatar = new T();

        /// <summary>
        /// Instance of sqlite handler.
        /// </summary>
        protected ISqliteHandler handler;

        /// <summary>
        /// DataTable of last selected results.
        /// </summary>
        protected DataTable dataTable;
        #endregion

        #region
        /// <summary>
        /// Constructor of SqliteTable.
        /// </summary>
        /// <param name="handler">Instance of sqlite handler.</param>
        /// <param name="name">Name of table.</param>
        public SqliteTable(ISqliteHandler handler, string name = null)
        {
            this.handler = handler;
            if (string.IsNullOrEmpty(name))
            {
                name = typeof(T).Name;
            }
            Name = name;

            var createCmd = string.Format(SqliteConstant.CMD_CREATE_IF_FORMAT, name, avatar.Statement);
            handler.ExecuteNonQuery(createCmd);
        }

        /// <summary>
        /// Select rows from table.
        /// </summary>
        /// <param name="context">Context append to select command.</param>
        /// <returns>Selected rows.</returns>
        public ICollection<T> Select(string context)
        {
            var cmd = string.Format(SqliteConstant.CMD_SELECT_FORMAT, Name);
            if (!string.IsNullOrEmpty(context))
            {
                cmd += string.Format(" {0}", context);
            }

            dataTable = handler.ExecuteQuery(cmd);
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[avatar.PrimaryKey] };

            var rows = new List<T>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                var newRow = new T();
                newRow.FillFrom(dataRow);
                rows.Add(newRow);
            }
            return rows;
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
            var selectCmd = string.Format(SqliteConstant.CMD_SELECT_FORMAT, Name);
            return handler.ExecuteNonQuery(dataTable, selectCmd);
        }
        #endregion
    }
}