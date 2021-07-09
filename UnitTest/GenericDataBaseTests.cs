using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;

namespace MGS.Sqlite.Tests
{
    [TestClass()]
    public class GenericDataBaseTests
    {
        protected GenericDataBase dataBase;

        [TestInitialize()]
        public void Initialize()
        {
            var dbFile = string.Format("{0}/DataBase/TestDB.db", Environment.CurrentDirectory);
            dataBase = new GenericDataBase(dbFile);
            Assert.IsNotNull(dataBase);
        }

        #region
        [TestMethod()]
        public void CreateTableTest()
        {
            //Create view if not exists.
            var lines = dataBase.CreateTable("table_t0(id INT32 PRIMARY KEY UNIQUE NOT NULL,name STRING NOT NULL)");
            Console.WriteLine("CreateTableTest lines {0}", lines);
        }

        [TestMethod()]
        public void SelectTableInsertTest()
        {
            var table = dataBase.SelectTable("table_t0");
            Assert.IsNotNull(table);

            var dataTable = table.Select();
            Assert.IsNotNull(dataTable);

            //Insert new rows.
            dataTable.Rows.Add(0, "a");
            dataTable.Rows.Add(1, "b");
            dataTable.Rows.Add(2, "c");

            var lines = table.Update(dataTable);
            Console.WriteLine("Insert new lines {0}", lines);

            foreach (DataRow row in dataTable.Rows)
            {
                Assert.IsNotNull(row);
                Console.WriteLine("SelectTableInsertTest row {0} {1}", row["id"], row["name"]);
            }
        }

        [TestMethod()]
        public void SelectTableUpdateTest()
        {
            var table = dataBase.SelectTable("table_t0");
            Assert.IsNotNull(table);

            var dataTable = table.Select();
            Assert.IsNotNull(dataTable);

            var row_0 = dataTable.Rows[0];
            row_0.BeginEdit();
            row_0["name"] = "test update name";
            row_0.EndEdit();

            var lines = table.Update(dataTable);
            if (lines > 0)
            {
                dataTable.AcceptChanges();
            }
            Console.WriteLine("Update lines {0}", lines);

            foreach (DataRow row in dataTable.Rows)
            {
                Assert.IsNotNull(row);
                Console.WriteLine("SelectTableUpdateTest row {0} {1}", row["id"], row["name"]);
            }
        }

        [TestMethod()]
        public void SelectTableDeleteTest()
        {
            var table = dataBase.SelectTable("table_t0");
            Assert.IsNotNull(table);

            var dataTable = table.Select();
            Assert.IsNotNull(dataTable);

            dataTable.Rows[0].Delete();
            var lines = table.Update(dataTable);
            if (lines > 0)
            {
                dataTable.AcceptChanges();
            }
            Console.WriteLine("Delete lines {0}", lines);

            foreach (DataRow row in dataTable.Rows)
            {
                Assert.IsNotNull(row);
                Console.WriteLine("SelectTableDeleteTest row {0} {1}", row["id"], row["name"]);
            }
        }

        [TestMethod()]
        public void DeleteTableTest()
        {
            var lines = dataBase.DeleteTable("table_t0");
            Console.WriteLine("DeleteTableTest lines {0}", lines);
        }
        #endregion

        #region
        [TestMethod()]
        public void CreateViewTest()
        {
            //Create view if not exists.
            var lines = dataBase.CreateView("view_v0 as select name from table_t0");
            Console.WriteLine("CreateViewTest lines {0}", lines);
        }

        [TestMethod()]
        public void SelectViewTest()
        {
            var view = dataBase.SelectView("view_v0");
            Assert.IsNotNull(view);

            var dataTable = view.Select();
            Assert.IsNotNull(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                Assert.IsNotNull(row);
                Console.WriteLine("SelectViewTest row {0}", row["name"]);
            }
        }

        [TestMethod()]
        public void DeleteViewTest()
        {
            var lines = dataBase.DeleteView("view_v0");
            Console.WriteLine("DeleteViewTest lines {0}", lines);
        }
        #endregion
    }
}