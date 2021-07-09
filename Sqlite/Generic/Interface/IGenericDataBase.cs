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
        /// Select sqlite view from data base as IGenericView.
        /// </summary>
        /// <typeparam name="T">Type of view row.</typeparam>
        /// <param name="name">Name of view.</param>
        /// <returns></returns>
        IGenericView<T> SelectView<T>(string name) where T : IViewRow, new();

        /// <summary>
        /// Create sqlite table for the type T row. 
        /// </summary>
        /// <typeparam name="T">Type of table row.</typeparam>
        /// <param name="name">Name of table.</param>
        /// <returns>Number of rows affected.</returns>
        int CreateTable<T>(string name) where T : ITableRow, new();

        /// <summary>
        /// Select sqlite table from data base as IGenericTable.
        /// </summary>
        /// <typeparam name="T">Type of table row.</typeparam>
        /// <param name="name">Name of table.</param>
        /// <returns></returns>
        IGenericTable<T> SelectTable<T>(string name) where T : ITableRow, new();
    }
}