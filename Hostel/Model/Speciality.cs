using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Model
{
    public class Speciality : IdObject
    {
        protected override string Table => "Speciality";

        public Speciality(DataRow row) : base(row)
        {
            _name = (string)row["name"];
            _duration = (int)(long)row["duration"];
            _faculty = Store.GetFaculty((int)(long)row["idFaculty"]);
        }

        public Speciality(Faculty fac, string name, int duration)
        {
            _faculty = fac;
            _name = name;
            _duration = duration;
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value) return;
                _name = value;
                UpdateField("Name", _name);
            }
        }

        private int _duration;
        public int Duration
        {
            get { return _duration; }
            set
            {
                if (_duration == value) return;
                _duration = value;
                UpdateField("duration", _duration);
            }
        }

        private Faculty _faculty;
        public Faculty Faculty => _faculty;

        protected override void DeleteFromList()
        {
            _faculty.Specialities.Remove(this);
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
