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
            Handler = new SqliteHandler(file);
        }

        /// <summary>
        /// Select or create a table for the T row from data base.
        /// </summary>
        /// <typeparam name="T">Type of the table row.</typeparam>
        /// <returns></returns>
        public virtual ISqliteTable<T> SelectTable<T>() where T : ISqliteRow, new()
        {
            return new SqliteTable<T>(Handler);
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