using System;
using System.Collections.Generic;
using System.Linq;
using Hostel.Model;

namespace Hostel.DB
{
    public abstract class Store
    {
        private static Store _inst;
        public static Store Inst
        {
            get { return _inst; }
            set { _inst = value; }
        }

        public abstract SQLiteSafe SQL { get; }

        #region Инициализация

        public static void Init()
        {
            _inst = new SQLiteStore();
            _inst.InitLists();
        }

        public void InitLists()
        {
            _faculties = ReadFaculties();
            _dictFac = _faculties.ToDictionary(f => f.Id, f => f);

            _specialities = ReadSpecialities();
            _dictSpec = _specialities.ToDictionary(s => s.Id, s => s);

            _students = ReadStudents();
            _students.Sort(Student.CompareBySecondName);
        }

        public abstract void CreateNewDataBase();


        #endregion

        #region Студенты

        private List<Student> _students;
        public List<Student> Students => _students;

        protected abstract List<Student> ReadStudents();

        public void Add(Student student)
        {
            student = StoreStudent(student);
            _students.Add(student);
            _students.Sort(Student.CompareBySecondName);
        }

        protected abstract Student StoreStudent(Student student);

        #endregion

        #region Специальности

        protected abstract List<Speciality> ReadSpecialities();

        private List<Speciality> _specialities;
        private Dictionary<int, Speciality> _dictSpec;

        public List<Speciality> Specialities => _specialities;

        public void Add(Speciality speciality)
        {
            speciality = StoreSpeciality(speciality);
            _specialities.Add(speciality);
        }

        protected abstract Speciality StoreSpeciality(Speciality speciality);

        public Speciality GetSpeciality(int id)
        {
            Speciality s;
            if (_dictSpec.TryGetValue(id, out s)) return s;
            return null;
        }

        #endregion

        #region Факультеты

        protected abstract List<Faculty> ReadFaculties();

        private List<Faculty> _faculties;
        public List<Faculty> Faculties => _faculties;

        private Dictionary<int, Faculty> _dictFac;

        public void Add(Faculty faculty)
        {
            faculty = StoreFaculty(faculty);
            _faculties.Add(faculty);
        }

        protected abstract Faculty StoreFaculty(Faculty faculty);

        public Faculty GetFaculty(int id)
        {
            Faculty f;
            if (_dictFac.TryGetValue(id, out f)) return f;
            return null;
        }

        #endregion

        public List<Student> GetCurrentStudents()
        {
            return _students.FindAll(s => !s.IsRemoved && s.IsActive);
        }

        public void AddYear()
        {
            foreach (var student in _students)
            {
                if (student.IsRemoved) continue;

                if (student.Speciality != null && student.Speciality.Duration == student.Year)
                    student.IsRemoved = true;
                else
                    student.Year++;
            }
        }
    }
}
