/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SqliteHandler.cs
 *  Description  :  Handler for sqlite data base.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/5/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using Mono.Data.Sqlite;
using System.Data;

namespace MGS.Sqlite
{
    /// <summary>
    /// Handler for sqlite data base.
    /// </summary>
    public class SqliteHandler : ISqliteHandler
    {
        /// <summary>
        /// Connection string.
        /// </summary>
        protected string connectionString;

        /// <summary>
        /// Constructor of SqliteHandler.
        /// </summary>
        /// <param name="file">Data base file.</param>
        public SqliteHandler(string file)
        {
            connectionString = string.Format(SqliteConstant.CONNECTION_FORMAT, file);
        }

        /// <summary>
        /// Execute command with args.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual DataTable ExecuteQuery(string command, params SqliteParameter[] args)
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = command;
                    cmd.Parameters.AddRange(args);

                    using (var adapter = new SqliteDataAdapter(cmd))
                    {
                        var table = new DataTable();
                        adapter.Fill(table);
                        return table;
                    }
                }
            }
        }

        /// <summary>
        /// Execute command with args.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="args"></param>
        /// <returns>Number of rows affected.</returns>
        public virtual int ExecuteNonQuery(string command, params SqliteParameter[] args)
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = command;
                    cmd.Parameters.AddRange(args);

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Execute update table to data base by command with args.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="command"></param>
        /// <param name="args"></param>
        /// <returns>Number of rows affected.</returns>
        public virtual int ExecuteNonQuery(DataTable table, string command, params SqliteParameter[] args)
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = command;
                    cmd.Parameters.AddRange(args);

                    using (var adapter = new SqliteDataAdapter(cmd))
                    {
                        using (var builder = new SqliteCommandBuilder(adapter))
                        {
                            adapter.InsertCommand = builder.GetInsertCommand();
                            adapter.UpdateCommand = builder.GetUpdateCommand();
                            adapter.DeleteCommand = builder.GetDeleteCommand();
                        }
                        return adapter.Update(table);
                    }
                }
            }
        }
    }
}