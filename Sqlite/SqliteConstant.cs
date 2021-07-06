/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SqliteConstant.cs
 *  Description  :  Constant for sqlite.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/7/2020
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Sqlite
{
    /// <summary>
    /// Constant for sqlite.
    /// </summary>
    public sealed class SqliteConstant
    {
        #region
        /// <summary>
        /// PRIMARY KEY
        /// </summary>
        public const string PRIMARY_KEY = "PRIMARY KEY";

        /// <summary>
        /// UNIQUE
        /// </summary>
        public const string UNIQUE = "UNIQUE";

        /// <summary>
        /// NOT NULL
        /// </summary>
        public const string NOT_NULL = "NOT NULL";

        /// <summary>
        /// DEFAULT
        /// </summary>
        public const string DEFAULT = "DEFAULT";
        #endregion

        #region
        /// <summary>
        /// Format of connection string.
        /// </summary>
        public const string CONNECTION_FORMAT = "VERSION=3,URI=FILE:{0}";

        /// <summary>
        /// Format of create table if not exists command.
        /// </summary>
        public const string CMD_CREATE_IF_FORMAT = "CREATE TABLE IF NOT EXISTS {0}{1}";

        /// <summary>
        /// Format of select rows command.
        /// </summary>
        public const string CMD_SELECT_FORMAT = "SELECT * FROM {0}";

        /// <summary>
        /// Format of delete table command.
        /// </summary>
        public const string CMD_DELETE_FORMAT = "DELETE TABLE {0}";
        #endregion
    }
}