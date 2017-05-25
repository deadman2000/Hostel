using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Hostel.Model
{
    public class Faculty : IdObject
    {
        protected override string Table => "Faculty";

        public Faculty(DataRow row) : base(row)
        {
            _name = (string)row["name"];
        }

        public Faculty()
        {
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value) return;
                _name = value;
                UpdateField("name", _name);
            }
        }

        public override string ToString()
        {
            return _name;
        }

        protected override void DeleteFromList()
        {
            Store.Faculties.Remove(this);
        }

        public List<Speciality> Specialities => Store.Specialities.FindAll(s => s.Faculty == this).ToList();
    }
}
