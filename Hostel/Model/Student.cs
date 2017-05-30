using System;
using System.Data;
using System.Globalization;

namespace Hostel.Model
{
    public class Student : IdObject
    {
        protected override string Table => "Students";

        public Student(DataRow row) : base(row)
        {
            _firstName = (string)row["fname"];
            _secondName = (string)row["sname"];
            _patronymic = (string)row["patronymic"];
            _birthDate = (DateTime)row["birthdate"];
            _address = (string)row["address"];
            _passport = (string)row["passport"];
            _year = (byte)(long)row["year"];
            _group = (string)row["group"];
            if (row["idSpeciality"] != DBNull.Value)
                _speciality = Store.GetSpeciality((int)(long)row["idSpeciality"]);
            _isBudget = (long)row["budget"] > 0;
            _contractNum = (int)(long)row["contractNum"];
            _room = (string)row["room"];
            _isActive = (long)row["isActive"] > 0;
            _isRemoved = (long)row["isRemoved"] > 0;
        }

        public Student()
        {
        }

        private string _firstName;
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName == value) return;
                _firstName = value;
                UpdateField("fname", value);
            }
        }

        private string _secondName;
        /// <summary>
        /// Фамилия
        /// </summary>
        public string SecondName
        {
            get { return _secondName; }
            set
            {
                if (_secondName == value) return;
                _secondName = value;
                UpdateField("sname", value);
            }
        }

        private string _patronymic;
        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic
        {
            get { return _patronymic; }
            set
            {
                if (_patronymic == value) return;
                _patronymic = value;
                UpdateField("patronymic", value);
            }
        }

        private DateTime _birthDate;
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                if (_birthDate == value) return;
                _birthDate = value;
                UpdateField("birthdate", value);
            }
        }

        private string _address;
        /// <summary>
        /// Прописка
        /// </summary>
        public string Address
        {
            get { return _address; }
            set
            {
                if (_address == value) return;
                _address = value;
                UpdateField("address", value);
            }
        }

        private string _passport;
        /// <summary>
        /// Паспортные данные
        /// </summary>
        public string Passport
        {
            get { return _passport; }
            set
            {
                if (_passport == value) return;
                _passport = value;
                UpdateField("passport", value);
            }
        }

        private string _group;
        /// <summary>
        /// Группа
        /// </summary>
        public string Group
        {
            get { return _group; }
            set
            {
                if (_group == value) return;
                _group = value;
                UpdateField("group", value);
            }
        }

        private byte _year;
        /// <summary>
        /// Курс
        /// </summary>
        public byte Year
        {
            get { return _year; }
            set
            {
                if (_year == value) return;
                _year = value;
                UpdateField("year", value);
            }
        }

        private Speciality _speciality;
        /// <summary>
        /// Специальность
        /// </summary>
        public Speciality Speciality
        {
            get { return _speciality; }
            set
            {
                if (_speciality == value) return;
                _speciality = value;
                UpdateField("idSpeciality", value);
            }
        }

        public Faculty Faculty => _speciality?.Faculty;

        public string FacultyName => _speciality?.Faculty?.Name;

        private bool _isBudget;
        /// <summary>
        /// Бюджет / договор
        /// </summary>
        public bool IsBudget
        {
            get { return _isBudget; }
            set
            {
                if (_isBudget == value) return;
                _isBudget = value;
                UpdateField("budget", value);
            }
        }

        private int _contractNum;
        /// <summary>
        /// Номер договора
        /// </summary>
        public int ContractNum
        {
            get { return _contractNum; }
            set
            {
                if (_contractNum == value) return;
                _contractNum = value;
                UpdateField("contractNum", value);
            }
        }

        private string _room;
        /// <summary>
        /// Комната
        /// </summary>
        public string Room
        {
            get { return _room; }
            set
            {
                if (_room == value) return;
                _room = value;
                UpdateField("room", value);
            }
        }

        private bool _isActive;
        /// <summary>
        /// Заселен
        /// </summary>
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                if (_isActive == value) return;
                _isActive = value;
                UpdateField("isActive", value);
            }
        }

        private bool _isRemoved;
        /// <summary>
        /// Выселен
        /// </summary>
        public bool IsRemoved
        {
            get { return _isRemoved; }
            set
            {
                if (_isRemoved == value) return;
                _isRemoved = value;
                UpdateField("isRemoved", value);
            }
        }

        public string FullName => _secondName + " " + _firstName + " " + _patronymic;

        public static int CompareBySecondName(Student a, Student b)
        {
            return String.Compare(a._secondName, b._secondName);
        }

        private static TextInfo ti = CultureInfo.CurrentCulture.TextInfo;

        public override string ToString()
        {
            return ti.ToTitleCase((_secondName + " " + _firstName + " " + _patronymic).ToLower());
        }

        protected override void DeleteFromList()
        {
            Store.Students.Remove(this);
        }
    }
}
