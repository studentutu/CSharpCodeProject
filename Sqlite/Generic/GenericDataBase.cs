/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GenericDataBase.cs
 *  Description  :  Generic sqlite data base.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/9/2020
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Sqlite.Generic
{
    /// <summary>
    /// Generic sqlite data base.
    /// </summary>
    public class GenericDataBase : SqliteDataBase, IGenericDataBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        public GenericDataBase(string file) : base(file) { }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public IGenericView<T> SelectView<T>(string name) where T : ISqliteRow, new()
        {
            var view = SelectView(name);
            if (view == null)
            {
                return null;
            }

            return new GenericView<T>(view);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public IGenericTable<T> SelectTable<T>(string name) where T : ISqliteRow, new()
        {
            var table = SelectTable(name);
            if (table == null)
            {
                return null;
            }

            return new GenericTable<T>(table);
        }
    }
}