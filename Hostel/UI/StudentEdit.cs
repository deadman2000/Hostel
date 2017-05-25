using System;
using System.Windows.Forms;
using Hostel.DB;
using Hostel.Model;

namespace Hostel.UI
{
    partial class StudentEdit : Form
    {
        static StudentEdit se;

        public static void ShowForm()
        {
            ShowForm(null);
        }

        public static void ShowForm(Student student)
        {
            if (se == null)
            {
                se = new StudentEdit(student);
                se.FormClosed += se_FormClosed;
            }

            se.ShowDialog();
        }

        static void se_FormClosed(object sender, FormClosedEventArgs e)
        {
            se = null;
        }

        private readonly Student _editStudent;

        public StudentEdit(Student student)
        {
            InitializeComponent();

            UpdateFaculties();

            _editStudent = student;
            if (_editStudent == null)
            {
                this.Text = "Заселение";
            }
            else
            {
                this.Text = "Редактирование";
                btAccept.Text = "Сохранить";

                btAcceptMore.Visible = false;

                tbFName.Text = student.FirstName;
                tbSName.Text = student.SecondName;
                tbPatronymic.Text = student.Patronymic;
                dtpBirthDate.Value = student.BirthDate;
                tbAddress.Text = student.Address;
                nudYear.Value = student.Year;

                if (student.Speciality != null)
                    cbFaculty.SelectedItem = student.Speciality.Faculty;
                cbSpeciality.SelectedItem = student.Speciality;

                cbContractBudget.SelectedIndex = student.IsBudget ? 1 : 0;
                nudContractNum.Value = student.ContractNum;
                tbRoom.Text = student.Room;

                chbIsActive.Checked = student.IsActive;
                chbRemoved.Checked = student.IsRemoved;
            }
        }

        void UpdateFaculties()
        {
            object selected = cbFaculty.SelectedItem;
            cbFaculty.DataSource = null;
            cbFaculty.DataSource = Store.Inst.Faculties;
            cbFaculty.SelectedItem = selected;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btAccept_Click(object sender, EventArgs e)
        {
            if (_editStudent == null)
                Add();
            else
                Edit();
            Close();
        }

        private void btAcceptMore_Click(object sender, EventArgs e)
        {
            Add();
            Clear();
        }

        private void Add()
        {
            Student st = new Student
            {
                FirstName = tbFName.Text,
                SecondName = tbSName.Text,
                Patronymic = tbPatronymic.Text,
                BirthDate = dtpBirthDate.Value,
                Address = tbAddress.Text,
                Year = (byte)nudYear.Value,
                Speciality = cbSpeciality.SelectedItem as Speciality,
                IsBudget = cbContractBudget.SelectedIndex == 1,
                ContractNum = (int)nudContractNum.Value,
                Room = tbRoom.Text,
                IsActive = chbIsActive.Checked
            };
            try
            {
                Store.Inst.Add(st);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Edit()
        {
            try
            {
                _editStudent.FirstName = tbFName.Text;
                _editStudent.SecondName = tbSName.Text;
                _editStudent.Patronymic = tbPatronymic.Text;
                _editStudent.BirthDate = dtpBirthDate.Value.Date;
                _editStudent.Address = tbAddress.Text;
                _editStudent.Year = (byte)nudYear.Value;
                _editStudent.Speciality = cbSpeciality.SelectedItem as Speciality;
                _editStudent.IsBudget = cbContractBudget.SelectedIndex == 1;
                _editStudent.ContractNum = (int)nudContractNum.Value;
                _editStudent.Room = tbRoom.Text;
                _editStudent.IsActive = chbIsActive.Checked;
                _editStudent.IsRemoved = chbRemoved.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Clear()
        {
            tbFName.Clear();
            tbSName.Clear();
            tbPatronymic.Clear();
            tbAddress.Clear();
            cbFaculty.SelectedItem = null;
            cbContractBudget.SelectedIndex = -1;
            tbRoom.Clear();
            chbIsActive.Checked = false;
            tbSName.Focus();
        }

        private void btEditFaculty_Click(object sender, EventArgs e)
        {
            new FormFaculties().ShowDialog();
            UpdateFaculties();
        }

        private void chbRemoved_CheckedChanged(object sender, EventArgs e)
        {
            if (chbRemoved.Checked)
                chbIsActive.Checked = false;
        }

        private void chbIsActive_CheckedChanged(object sender, EventArgs e)
        {
            if (chbIsActive.Checked)
                chbRemoved.Checked = false;
        }

        private void cbFaculty_SelectedValueChanged(object sender, EventArgs e)
        {
            var fac = cbFaculty.SelectedItem as Faculty;
            if (fac != null)
                cbSpeciality.DataSource = fac.Specialities;
            else
                cbSpeciality.DataSource = null;
        }

        private void btEditSpeciality_Click(object sender, EventArgs e)
        {
            var fac = cbFaculty.SelectedItem as Faculty;
            if (fac == null) return;
            new FormSpecialities(fac).ShowDialog();

            cbSpeciality.DataSource = null;
            cbSpeciality.DataSource = fac.Specialities;
        }
    }
}
