using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using Hostel.Model;
using System.Threading;

namespace Hostel.DB
{
    class SQLiteStore : Store
    {
        private SQLiteSafe sql;
        private const string FileName = "Hostel.db3";

        public SQLiteStore()
        {
            sql = new SQLiteSafe(FileName);
            if (!File.Exists(FileName))
                CreateDataBase();
            UpdateDB();
        }

        private void CreateDataBase()
        {
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    SQLiteConnection.CreateFile(FileName);
                    break;
                }
                catch
                {
                    Thread.Sleep(10);
                }
            }
            sql.ExecuteNonQuery(Properties.Resources.CreateDB);
        }

        public override SQLiteSafe SQL => sql;

        public override void CreateNewDataBase()
        {
            if (sql != null)
            {
                sql.Close();
                sql = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            bool moved = false;
            for (int c = 0; c < 50; c++)
                try
                {
                    if (Students.Count > 0)
                    {
                        if (File.Exists(FileName))
                        {
                            // Make backup
                            string name = "Hostel.bak";
                            int i = 0;
                            while (File.Exists(name))
                            {
                                name = "Hostel_" + i + ".bak";
                                i++;
                            }

                            File.Move(FileName, name);
                        }
                    }
                    else
                        File.Delete(FileName);

                    Console.WriteLine("Move success");
                    moved = true;
                    break;
                }
                catch
                {
                    Thread.Sleep(100);
                    Console.WriteLine("Fail move");
                }

            if (!moved)
                throw new Exception("Cannot move DB");

            sql = new SQLiteSafe(FileName);
            CreateDataBase();
            UpdateDB();
            InitLists();
        }

        private void UpdateDB()
        {
            if (!CoumnExists("Students", "passport")) sql.ExecuteNonQuery("ALTER TABLE Students ADD COLUMN passport TEXT NOT NULL DEFAULT('')");
            if (!CoumnExists("Students", "group")) sql.ExecuteNonQuery("ALTER TABLE Students ADD COLUMN [group] TEXT NOT NULL DEFAULT('')");
        }

        private bool CoumnExists(string tableName, string columnName)
        {
            var cmd = new SQLiteCommand("PRAGMA table_info('" + tableName + "')");
            var tbl = sql.ExecuteTable(cmd);
            foreach (DataRow row in tbl.Rows)
            {
                var name = (string)row["name"];
                if (name.Equals(columnName)) return true;
            }
            return false;
        }

        #region Факультеты

        protected override List<Faculty> ReadFaculties()
        {
            var table = sql.ExecuteTable("SELECT * FROM Faculty");

            var faculties = new List<Faculty>(table.Rows.Count + 4);
            foreach (DataRow row in table.Rows)
            {
                var fac = new Faculty(row);
                faculties.Add(fac);
            }

            return faculties;
        }

        protected override Faculty StoreFaculty(Faculty faculty)
        {
            var cmd = new SQLiteCommand("INSERT INTO Faculty(name)VALUES(@name);SELECT * FROM Faculty WHERE id=last_insert_rowid();");
            cmd.Parameters.AddWithValue("@name", faculty.Name);
            var result = sql.ExecuteTable(cmd);
            return new Faculty(result.Rows[0]);
        }

        #endregion

        #region Специальности

        protected override List<Speciality> ReadSpecialities()
        {
            var table = sql.ExecuteTable("SELECT * FROM Speciality");
            var list = new List<Speciality>(table.Rows.Count + 4);
            foreach (DataRow row in table.Rows)
            {
                var spec = new Speciality(row);
                list.Add(spec);
            }
            return list;
        }

        protected override Speciality StoreSpeciality(Speciality speciality)
        {
            var cmd = new SQLiteCommand("INSERT INTO Speciality(idFaculty,name,duration)VALUES(@idFac,@name,@dur);SELECT * FROM Speciality WHERE id=last_insert_rowid()");
            if (speciality.Faculty != null)
                cmd.Parameters.AddWithValue("@idFac", speciality.Faculty.Id);
            else
                cmd.Parameters.AddWithValue("@idFac", DBNull.Value);
            cmd.Parameters.AddWithValue("@name", speciality.Name);
            cmd.Parameters.AddWithValue("@dur", speciality.Duration);
            var result = sql.ExecuteTable(cmd);
            return new Speciality(result.Rows[0]);
        }

        #endregion

        #region Студенты

        protected override List<Student> ReadStudents()
        {
            var table = sql.ExecuteTable("SELECT * FROM Students");
            var list = new List<Student>(table.Rows.Count + 8);
            foreach (DataRow row in table.Rows)
            {
                var st = new Student(row);
                list.Add(st);
            }
            return list;
        }

        protected override Student StoreStudent(Student student)
        {
            var cmd = new SQLiteCommand("INSERT INTO Students(fname,sname,patronymic,birthdate,address,year,idSpeciality,budget,contractNum,room,isActive)VALUES(@fname,@sname,@patronymic,@bd,@address,@year,@idSpec,@budget,@cNum,@room,@active);SELECT * FROM Students WHERE id=last_insert_rowid()");
            cmd.Parameters.AddWithValue("@fname", student.FirstName);
            cmd.Parameters.AddWithValue("@sname", student.SecondName);
            cmd.Parameters.AddWithValue("@patronymic", student.Patronymic);
            cmd.Parameters.AddWithValue("@bd", student.BirthDate);
            cmd.Parameters.AddWithValue("@address", student.Address);
            cmd.Parameters.AddWithValue("@year", student.Year);
            if (student.Speciality != null)
                cmd.Parameters.AddWithValue("@idSpec", student.Speciality.Id);
            else
                cmd.Parameters.AddWithValue("@idSpec", DBNull.Value);
            cmd.Parameters.AddWithValue("@budget", student.IsBudget);
            cmd.Parameters.AddWithValue("@cNum", student.ContractNum);
            cmd.Parameters.AddWithValue("@room", student.Room);
            cmd.Parameters.AddWithValue("@active", student.IsActive);
            var result = sql.ExecuteTable(cmd);
            return new Student(result.Rows[0]);
        }

        #endregion
    }
}
