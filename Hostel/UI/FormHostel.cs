using System;
using System.ComponentModel;
using System.Windows.Forms;
using Hostel.DB;
using Hostel.Model;
using Hostel.Reports;
using System.Linq;
using System.Collections.Generic;

namespace Hostel.UI
{
    public partial class FormHostel : Form
    {
        public FormHostel()
        {
            InitializeComponent();

            dgvHostel.AutoGenerateColumns = false;

            tscbMode.SelectedIndex = 0;

            //RefreshGrid();

            dgvHostel.Sort(colSName, ListSortDirection.Ascending);
        }

        private void tscbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        #region Buttons

        private void tsmiAddStudent_Click(object sender, EventArgs e)
        {
            StudentEdit.ShowForm();
        }

        private void tsmiFaculties_Click(object sender, EventArgs e)
        {
            new FormFaculties().ShowDialog();
        }


        private void tsmiEditStudent_Click(object sender, EventArgs e)
        {
            EditCurrent();
        }

        private void tsmiRemove_Click(object sender, EventArgs e)
        {
            RemoveCurrent();
        }

        private void tsmiRemoveStudent_Click(object sender, EventArgs e)
        {
            DeleteCurrent();
        }


        private void dgvHostel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvHostel.RowCount)
                EditCurrent();
        }


        private void tsmEditStud_Click(object sender, EventArgs e)
        {
            EditCurrent();
        }

        private void tsmRemoveStud_Click(object sender, EventArgs e)
        {
            RemoveCurrent();
        }


        private void tsmiDeleteStud_Click(object sender, EventArgs e)
        {
            DeleteCurrent();
        }

        #endregion


        #region Actions

        private void RefreshGrid()
        {
            Student curr = null;
            if (dgvHostel.CurrentRow != null)
                curr = (Student)dgvHostel.CurrentRow.Tag;

            dgvHostel.Rows.Clear();

            foreach (var st in Store.Inst.Students)
            {
                switch (tscbMode.SelectedIndex)
                {
                    case 0:
                        if (!st.IsActive || st.IsRemoved) continue;
                        break;
                    case 1:
                        if (st.IsActive || st.IsRemoved) continue;
                        break;
                    case 2:
                        if (!st.IsRemoved) continue;
                        break;
                }

                var i = dgvHostel.Rows.Add(st.SecondName, st.FirstName, st.Patronymic, st.Room);
                var row = dgvHostel.Rows[i];
                row.Tag = st;
                if (st == curr)
                    dgvHostel.CurrentCell = dgvHostel[0, i];
            }
        }


        private void EditCurrent()
        {
            if (dgvHostel.CurrentRow == null) return;
            StudentEdit.ShowForm((Student)dgvHostel.CurrentRow.Tag);
        }

        private void DeleteCurrent()
        {
            if (dgvHostel.CurrentRow == null) return;

            if (MessageBox.Show("Вы действительно хотите удалить информацию о студенте?", "Удаление информации о студенте", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                ((Student)dgvHostel.CurrentRow.Tag).Delete();
        }

        private void RemoveCurrent()
        {
            if (dgvHostel.CurrentRow == null) return;

            if (MessageBox.Show("Вы действительно хотите выселить студента?", "Выселение студента", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                ((Student)dgvHostel.CurrentRow.Tag).IsRemoved = true;
        }

        #endregion


        #region Reports

        private void tsmiReportRooms_Click(object sender, EventArgs e)
        {
            RoomReport.BuildAllRooms();
        }

        private void tsmiLevel1_Click(object sender, EventArgs e)
        {
            RoomReport.BuildRoomsReport(1);
        }

        private void tsmiLevel2_Click(object sender, EventArgs e)
        {
            RoomReport.BuildRoomsReport(2);
        }

        private void tsmiLevel3_Click(object sender, EventArgs e)
        {
            RoomReport.BuildRoomsReport(3);
        }

        private void tsmiLevel4_Click(object sender, EventArgs e)
        {
            RoomReport.BuildRoomsReport(4);
        }

        private void tsmiLevel5_Click(object sender, EventArgs e)
        {
            RoomReport.BuildRoomsReport(5);
        }

        private void tsmiFacReport_Click(object sender, EventArgs e)
        {
            FacReport.Build();
        }

        private void tsmiRepFacYear_Click(object sender, EventArgs e)
        {
            FormFaculties form = new FormFaculties();
            form.SelectMode = true;
            if (form.ShowDialog() == DialogResult.OK)
            {
                new FacYearReport(form.SelectedFaculty).Build();
            }
        }

        private void tsmiGraduatesReport_Click(object sender, EventArgs e)
        {
            new GraduatesReport().Build();
        }

        #endregion

        private void tsmiAddYear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Перевод на следующий курс", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Store.Inst.AddYear();
                RefreshGrid();
                MessageBox.Show("Готово");
            }
        }

        private void tsmiDBImport_Click(object sender, EventArgs e)
        {
            Importer.Import(@"import.xlsx");
            RefreshGrid();
        }

        private void tsmiRandomize_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Случайное изменение всех студентов", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                List<Speciality> all = new List<Speciality>();
                Store.Inst.Faculties.ForEach(f => all.AddRange(f.Specialities));
                Random rnd = new Random();
                foreach (var st in Store.Inst.Students)
                {
                    st.Speciality = all[rnd.Next(all.Count)];
                    st.Year = (byte)(1 + rnd.Next(st.Speciality.Duration));
                }

                MessageBox.Show("Готово");
            }
        }
    }
}
