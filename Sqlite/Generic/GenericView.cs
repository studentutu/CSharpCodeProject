/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GenericView.cs
 *  Description  :  Generic sqlite view.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/9/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using System.Data;

namespace MGS.Sqlite
{
    /// <summary>
    /// Generic sqlite view.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericView<T> : IGenericView<T> where T : ISqliteRow, new()
    {
        /// <summary>
        /// Instance of sqlite source.
        /// </summary>
        protected ISqliteView source;

        /// <summary>
        /// DataTable of last selected results.
        /// </summary>
        protected DataTable dataTable;

        /// <summary>
        /// Constructor of GenericView.
        /// </summary>
        /// <param name="view">Instance of sqlite view.</param>
        public GenericView(ISqliteView view)
        {
            source = view;
        }

        /// <summary>
        /// Select rows from table.
        /// </summary>
        /// <param name="cmd">Select cmd [Select all if null].</param>
        /// <returns>Selected rows.</returns>
        public ICollection<T> Select(string cmd = null)
        {
            dataTable = source.Select(cmd);
            if (dataTable == null || dataTable.Rows == null || dataTable.Rows.Count == 0)
            {
                return null;
            }

            var rows = new List<T>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                var item = new T();
                item.FillFrom(dataRow);
                rows.Add(item);
            }
            return rows;
        }
    }
}