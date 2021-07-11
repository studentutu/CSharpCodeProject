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
            //Create table if not exists.
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

        #region
        class PersonT : TableRow
        {
            //Must mark a PrimaryKey.
            [ColumnField(PrimaryKey = true)]
            public int id = 0;

            [ColumnField]
            public string name = "";
        }

        [TestMethod()]
        public void CreateGenericTableTest()
        {
            //Create table if not exists.
            var lines = dataBase.CreateTable<PersonT>("table_person");
            Console.WriteLine("CreateTableTest lines {0}", lines);
        }

        [TestMethod()]
        public void SelectGenericTableInsertTest()
        {
            var table = dataBase.SelectTable<PersonT>("table_person");
            Assert.IsNotNull(table);

            table.Insert(new PersonT() { id = 0, name = "a" });
            table.Insert(new PersonT() { id = 1, name = "b" });
            table.Insert(new PersonT() { id = 2, name = "c" });
            var lines = table.Commit();
            Console.WriteLine("Insert new lines {0}", lines);

            var persons = table.Select();
            foreach (var person in persons)
            {
                Assert.IsNotNull(person);
                Console.WriteLine("SelectGenericTableInsertTest person {0} {1}", person.id, person.name);
            }
        }

        [TestMethod()]
        public void SelectGenericTableUpdateTest()
        {
            var table = dataBase.SelectTable<PersonT>("table_person");
            Assert.IsNotNull(table);

            var persons = table.Select();
            var enumer = persons.GetEnumerator();
            enumer.MoveNext();
            var person_0 = enumer.Current;

            //person_0.id = 100;//person_0.id is primary key, modify it's value not supported.
            person_0.name = "Test update name";
            table.Update(person_0);
            var lines = table.Commit();
            Console.WriteLine("Update lines {0}", lines);

            persons = table.Select();
            foreach (var person in persons)
            {
                Assert.IsNotNull(person);
                Console.WriteLine("SelectGenericTableUpdateTest person {0} {1}", person.id, person.name);
            }
        }

        [TestMethod()]
        public void SelectGenericTableDeleteTest()
        {
            var table = dataBase.SelectTable<PersonT>("table_person");
            Assert.IsNotNull(table);

            var persons = table.Select();
            var enumer = persons.GetEnumerator();
            enumer.MoveNext();
            var person_0 = enumer.Current;

            table.Delete(person_0);
            //table.Delete(person_0.id);
            var lines = table.Commit();
            Console.WriteLine("Delete lines {0}", lines);

            persons = table.Select();
            foreach (var person in persons)
            {
                Assert.IsNotNull(person);
                Console.WriteLine("SelectGenericTableDeleteTest person {0} {1}", person.id, person.name);
            }
        }
        #endregion

        #region
        class PersonV : ViewRow
        {
            //Do not need mark PrimaryKey.
            [ColumnField]
            public int id = 0;

            [ColumnField]
            public string name = "";
        }

        [TestMethod()]
        public void CreateGenericViewTest()
        {
            //Create view if not exists.
            var lines = dataBase.CreateView("view_person as select * from table_person");
            Console.WriteLine("CreateGenericViewTest lines {0}", lines);
        }

        [TestMethod()]
        public void SelectGenericViewTest()
        {
            var view = dataBase.SelectView<PersonT>("view_person");
            Assert.IsNotNull(view);

            var persons = view.Select();
            foreach (var person in persons)
            {
                Assert.IsNotNull(person);
                Console.WriteLine("SelectGenericViewTest person {0} {1}", person.id, person.name);
            }
        }
        #endregion
    }
}