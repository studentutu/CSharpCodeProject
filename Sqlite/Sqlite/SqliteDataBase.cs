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
        protected ISqliteHandler handler;

        /// <summary>
        /// Constructor of SqliteDataBase.
        /// </summary>
        /// <param name="file">Data base file.</param>
        public SqliteDataBase(string file)
        {
            var uri = string.Format("file:{0}", file);
            handler = new SqliteHandler(uri);
        }

        #region
        /// <summary>
        /// 
        /// </summary>
        /// <param name="statement"></param>
        /// <returns></returns>
        public int CreateView(string statement)
        {
            var createCmd = string.Format("CREATE VIEW IF NOT EXISTS {0}", statement);
            return handler.ExecuteNonQuery(createCmd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ISqliteView SelectView(string name)
        {
            var selectCmd = string.Format("Select count(*) from sqlite_master where type='table' and name={0}", name);
            var count = handler.ExecuteNonQuery(selectCmd);
            if (count == 0)
            {
                return null;
            }
            return new SqliteView(name, handler);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int DeleteView(string name)
        {
            var deleteCmd = string.Format("DELETE VIEW {0}", name);
            return handler.ExecuteNonQuery(deleteCmd);
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        /// <param name="statement"></param>
        /// <returns></returns>
        public int CreateTable(string statement)
        {
            var createCmd = string.Format(SqliteConstant.CMD_CREATE_IF_FORMAT, statement);
            return handler.ExecuteNonQuery(createCmd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ISqliteTable SelectTable(string name)
        {
            var selectCmd = string.Format("Select count(*) from sqlite_master where type='view' and name={0}", name);
            var count = handler.ExecuteNonQuery(selectCmd);
            if (count == 0)
            {
                return null;
            }
            return new SqliteTable(name, handler);
        }

        /// <summary>
        /// Delete the table from data base.
        /// </summary>
        /// <param name="name">The name of table.</param>
        /// <returns>Number of rows affected.</returns>
        public int DeleteTable(string name)
        {
            var deleteCmd = string.Format(SqliteConstant.CMD_DELETE_FORMAT, name);
            return handler.ExecuteNonQuery(deleteCmd);
        }
        #endregion
    }
}