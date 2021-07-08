/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IGenericDataBase.cs
 *  Description  :  Interface for generic sqlite data base.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/9/2020
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Sqlite
{
    /// <summary>
    /// Interface for generic sqlite data base.
    /// </summary>
    public interface IGenericDataBase : ISqliteDataBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        IGenericView<T> SelectView<T>(string name) where T : ISqliteRow, new();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        IGenericTable<T> SelectTable<T>(string name) where T : ISqliteRow, new();
    }
}