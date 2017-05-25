using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hostel.DB;

namespace Hostel.Model
{
    public abstract class IdObject
    {
        protected Store Store => Store.Inst;

        protected SQLiteSafe sql => Store.Inst.SQL;

        protected int _id;

        protected IdObject(DataRow row)
        {
            _id = (int)(long)row["Id"];
        }

        protected IdObject()
        {
        }

        protected abstract string Table { get; }

        public int Id => _id;

        protected virtual bool CheckDublicate()
        {
            return false;
        }

        protected void UpdateField(string field, object value)
        {
            if (_id == 0) return;

            if (value is bool)
                value = ((bool)value) ? 1 : 0;
            else if (value is IdObject)
                value = ((IdObject)value).Id;

            SQLiteCommand cmd = new SQLiteCommand("UPDATE " + Table + " SET " + field + "=@V WHERE id=@id");
            cmd.Parameters.AddWithValue("@id", _id);
            cmd.Parameters.AddWithValue("@V", value);
            sql.ExecuteNonQuery(cmd);
        }

        public void Delete()
        {
            var cmd = new SQLiteCommand("DELETE FROM " + Table + " WHERE id=@id");
            cmd.Parameters.AddWithValue("@id", _id);
            sql.ExecuteNonQuery(cmd);
            DeleteFromList();
        }

        protected abstract void DeleteFromList();
    }
}
