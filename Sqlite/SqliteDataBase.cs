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
        public ISqliteHandler Handler { protected set; get; }

        /// <summary>
        /// Constructor of SqliteDataBase.
        /// </summary>
        /// <param name="file">Data base file.</param>
        public SqliteDataBase(string file)
        {
            var uri = string.Format("file:{0}", file);
            Handler = new SqliteHandler(uri);
        }

        /// <summary>
        /// Connect to the table for the T type row from data base.
        /// [Create file and table if not exist]
        /// </summary>
        /// <typeparam name="T">Type of the table row.</typeparam>
        /// <param name="name">Name of table.</param>
        /// <returns></returns>
        public virtual ISqliteTable<T> ConnectTable<T>(string name) where T : ISqliteRow, new()
        {
            var table = new SqliteTable<T>(Handler, name);
            var createIfCmd = string.Format(SqliteConstant.CMD_CREATE_IF_FORMAT, table.Statement);
            Handler.ExecuteNonQuery(createIfCmd);
            return table;
        }

        /// <summary>
        /// Delete the table from data base.
        /// </summary>
        /// <param name="name">The name of table.</param>
        /// <returns>Number of rows affected.</returns>
        public virtual int DeleteTable(string name)
        {
            var deleteCmd = string.Format(SqliteConstant.CMD_DELETE_FORMAT, name);
            return Handler.ExecuteNonQuery(deleteCmd);
        }
    }
}