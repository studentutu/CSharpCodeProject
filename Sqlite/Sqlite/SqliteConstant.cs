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
        /// sqlite_master.
        /// </summary>
        public const string SQLITE_MASTER = "sqlite_master";
        #endregion

        #region
        /// <summary>
        /// Format of connection string.
        /// </summary>
        public const string CONNECTION_FORMAT = "version={0},uri={1}";

        /// <summary>
        /// Format of create if not exists command.
        /// </summary>
        public const string CMD_CREATE_IF_FORMAT = "CREATE {0} IF NOT EXISTS {1}";

        /// <summary>
        /// Format of select command.
        /// </summary>
        public const string CMD_SELECT_FORMAT = "SELECT {0} FROM {1}";

        /// <summary>
        /// Format of select sqlite_master by type and name command.
        /// </summary>
        public const string CMD_SELECT_MASTER_TYPE_NAME_FORMAT = "select {0} from sqlite_master where type='{1}' and name='{2}'";

        /// <summary>
        /// Format of delete command.
        /// </summary>
        public const string CMD_DROP_FORMAT = "DROP {0} {1}";
        #endregion
    }
}