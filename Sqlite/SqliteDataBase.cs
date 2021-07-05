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
        /// <param name="handler">Handler for sqlite data base.</param>
        public SqliteDataBase(ISqliteHandler handler)
        {
            this.handler = handler;
        }

        /// <summary>
        /// Select or create a table for the T row from data base.
        /// </summary>
        /// <typeparam name="T">Type of the table row.</typeparam>
        /// <returns></returns>
        public virtual ISqliteTable<T> SelectTable<T>() where T : class, new()
        {
            return null;
        }
        
        /// <summary>
        /// Delete the table from data base.
        /// </summary>
        /// <param name="name">The name of table.</param>
        /// <returns>Number of rows affected.</returns>
        public virtual int DeleteTable(string name)
        {
            var cmd = string.Format("DELETE TABLE {0}", name);
            return handler.ExecuteNonQuery(cmd);
        }
    }
}