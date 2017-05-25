using System;
using System.Windows.Forms;
using Hostel.DB;
using Hostel.Model;

namespace Hostel.UI
{
    public partial class FormFaculties : Form
    {
        private bool _selectMode;

        public FormFaculties()
        {
            InitializeComponent();
            Fill();
        }

        public Faculty SelectedFaculty => lvFaculties.SelectedItems[0].Tag as Faculty;

        public bool SelectMode
        {
            get { return _selectMode; }
            set { _selectMode = value; }
        }

        void Fill()
        {
            lvFaculties.Items.Clear();
            foreach (var fac in Store.Inst.Faculties)
                AddFacultyItem(fac);
        }

        void AddFacultyItem(Faculty fac)
        {
            var lvi = lvFaculties.Items.Add(fac.Name);
            lvi.Tag = fac;
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            var fed = new FacultyEditDialog();
            if (fed.ShowDialog() == DialogResult.OK)
            {
                var fac = new Faculty { Name = fed.FacultyName };
                try
                {
                    Store.Inst.Add(fac);
                    Fill();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (lvFaculties.SelectedItems.Count == 0) return;

            var fac = SelectedFaculty;
            var fed = new FacultyEditDialog { FacultyName = fac.Name };
            if (fed.ShowDialog() != DialogResult.OK) return;

            try
            {
                fac.Name = fed.FacultyName;
                Fill();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsbRemove_Click(object sender, EventArgs e)
        {
            if (lvFaculties.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить этот факультет?", "Удаление факультета", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var fac = SelectedFaculty;
                    try
                    {
                        fac.Delete();
                        Fill();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void lvFaculties_DoubleClick(object sender, EventArgs e)
        {
            if (!_selectMode) return;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
