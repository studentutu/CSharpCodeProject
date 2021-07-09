/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SqliteDataBase.cs
 *  Description  :  Sqlite data base.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/5/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Logger;
using System;
using System.IO;

namespace MGS.Sqlite
{
    /// <summary>
    /// Sqlite data base.
    /// </summary>
    public class SqliteDataBase : ISqliteDataBase
    {
        /// <summary>
        /// Sqlite handler of this data base.
        /// </summary>
        public ISqliteHandler Handler { protected set; get; }

        /// <summary>
        /// Constructor of SqliteDataBase.
        /// </summary>
        /// <param name="file">Data base file.</param>
        public SqliteDataBase(string file)
        {
            var dir = Path.GetDirectoryName(file);
            if (!Directory.Exists(dir))
            {
                try
                {
                    Directory.CreateDirectory(dir);
                }
                catch (Exception ex)
                {
                    LogUtility.LogException(ex);
                }
            }

            var uri = string.Format("file:{0}", file);
            Handler = new SqliteHandler(uri);
        }

        #region
        /// <summary>
        /// Create sqlite view if not exists.
        /// </summary>
        /// <param name="statement">Statement sql for view.</param>
        /// <returns>Number of rows affected.</returns>
        public int CreateView(string statement)
        {
            var createCmd = string.Format(SqliteConstant.CMD_CREATE_IF_FORMAT, "VIEW", statement);
            return Handler.ExecuteNonQuery(createCmd);
        }

        /// <summary>
        /// Select view from data base.
        /// </summary>
        /// <param name="name">Name of view.</param>
        /// <returns></returns>
        public ISqliteView SelectView(string name)
        {
            var selectCmd = string.Format(SqliteConstant.CMD_SELECT_MASTER_TYPE_NAME_FORMAT, "name", "view", name);
            var result = Handler.ExecuteScalar(selectCmd);
            if (result == null)
            {
                return null;
            }
            return new SqliteView(name, Handler);
        }

        /// <summary>
        /// Delete view from data base.
        /// </summary>
        /// <param name="name">Name of view.</param>
        /// <returns>Number of rows affected.</returns>
        public int DeleteView(string name)
        {
            var deleteCmd = string.Format(SqliteConstant.CMD_DROP_FORMAT, "VIEW", name);
            return Handler.ExecuteNonQuery(deleteCmd);
        }
        #endregion

        #region
        /// <summary>
        /// Create sqlite table if not exists.
        /// </summary>
        /// <param name="statement">Statement sql for table.</param>
        /// <returns>Number of rows affected.</returns>
        public int CreateTable(string statement)
        {
            var createCmd = string.Format(SqliteConstant.CMD_CREATE_IF_FORMAT, "TABLE", statement);
            return Handler.ExecuteNonQuery(createCmd);
        }

        /// <summary>
        /// Select table from data base.
        /// </summary>
        /// <param name="name">Name of table.</param>
        /// <returns></returns>
        public ISqliteTable SelectTable(string name)
        {
            var selectCmd = string.Format(SqliteConstant.CMD_SELECT_MASTER_TYPE_NAME_FORMAT, "name", "table", name);
            var result = Handler.ExecuteScalar(selectCmd);
            if (result == null)
            {
                return null;
            }
            return new SqliteTable(name, Handler);
        }

        /// <summary>
        /// Delete the table from data base.
        /// </summary>
        /// <param name="name">The name of table.</param>
        /// <returns>Number of rows affected.</returns>
        public int DeleteTable(string name)
        {
            var deleteCmd = string.Format(SqliteConstant.CMD_DROP_FORMAT, "TABLE", name);
            return Handler.ExecuteNonQuery(deleteCmd);
        }
        #endregion
    }
}