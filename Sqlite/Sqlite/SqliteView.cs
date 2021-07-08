/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SqliteView.cs
 *  Description  :  Sqlite view.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/9/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Data;

namespace MGS.Sqlite
{
    /// <summary>
    /// Sqlite view.
    /// </summary>
    public class SqliteView : ISqliteView
    {
        /// <summary>
        /// Name of source.
        /// </summary>
        protected string name;

        /// <summary>
        /// Instance of sqlite handler.
        /// </summary>
        protected ISqliteHandler handler;

        /// <summary>
        /// Constructor of SqliteView.
        /// </summary>
        /// <param name="name">Name of view.</param>
        /// <param name="handler">Instance of sqlite handler.</param>
        public SqliteView(string name, ISqliteHandler handler)
        {
            this.name = name;
            this.handler = handler;
        }

        /// <summary>
        /// Select rows from source.
        /// </summary>
        /// <param name="cmd">Select cmd [Select all if null].</param>
        /// <returns></returns>
        public DataTable Select(string cmd = null)
        {
            if (string.IsNullOrEmpty(cmd))
            {
                cmd = string.Format(SqliteConstant.CMD_SELECT_FORMAT, name);
            }
            return handler.ExecuteQuery(cmd);
        }
    }
}