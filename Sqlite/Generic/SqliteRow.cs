/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SqliteRow.cs
 *  Description  :  Generic class for sqlite table row implement
 *                  base reflection.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/5/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace MGS.Sqlite
{
    /// <summary>
    /// Generic class for sqlite table row implement base reflection.
    /// </summary>
    public abstract class SqliteRow : ISqliteRow
    {
        #region
        /// <summary>
        /// Statement of the columns.
        /// </summary>
        public string Statement { protected set; get; }

        /// <summary>
        /// Name of primary key.
        /// </summary>
        public virtual string PrimaryKey
        {
            get { return primaryField.Name; }
        }

        /// <summary>
        /// Value of primary key.
        /// </summary>
        public virtual object PrimaryValue
        {
            get { return primaryField.GetValue(this); }
        }

        /// <summary>
        /// Field info of sqlite fields.
        /// </summary>
        protected static List<FieldInfo> sqliteFields;

        /// <summary>
        /// Field info of primary field.
        /// </summary>
        protected static FieldInfo primaryField;
        #endregion

        #region
        /// <summary>
        /// Constructor.
        /// </summary>
        public SqliteRow()
        {
            Initialize();
        }

        /// <summary>
        /// Fill this object from data row.
        /// </summary>
        /// <param name="row"></param>
        public virtual void FillFrom(DataRow row)
        {
            foreach (var field in sqliteFields)
            {
                field.SetValue(this, row[field.Name]);
            }
        }

        /// <summary>
        /// Fill this object to data row.
        /// </summary>
        /// <param name="row"></param>
        public virtual void FillTo(DataRow row)
        {
            foreach (var field in sqliteFields)
            {
                row[field.Name] = field.GetValue(this);
            }
        }
        #endregion

        #region
        /// <summary>
        /// Initialize the follow infos.
        /// [Statement, sqliteFields, primaryField]
        /// </summary>
        protected virtual void Initialize()
        {
            //The info of sqlite fields is generic, so just need init once.
            if (sqliteFields == null)
            {
                sqliteFields = new List<FieldInfo>();

                var fields = GetType().GetFields();
                var columns = new List<string>();
                foreach (var field in fields)
                {
                    if (field.IsDefined(typeof(SqliteFieldAttribute), false))
                    {
                        sqliteFields.Add(field);

                        var column = string.Format("{0} {1}", field.Name, field.FieldType.Name.ToUpper());
                        var atrbt = field.GetCustomAttributes(typeof(SqliteFieldAttribute), false)[0] as SqliteFieldAttribute;
                        if (atrbt.PrimaryKey)
                        {
                            primaryField = field;
                            column += string.Format(" {0}", SqliteConstant.PRIMARY_KEY);
                        }
                        if (atrbt.Unique)
                        {
                            column += string.Format(" {0}", SqliteConstant.UNIQUE);
                        }
                        if (atrbt.NotNull)
                        {
                            column += string.Format(" {0}", SqliteConstant.NOT_NULL);
                        }
                        if (atrbt.Default != null)
                        {
                            column += string.Format(" {0} {1}", SqliteConstant.DEFAULT, atrbt.Default);
                        }
                        columns.Add(column);
                    }
                }
                Statement = string.Format("({0})", string.Join(",", columns.ToArray()));
            }
        }
        #endregion
    }
}