using System;
using System.Windows.Forms;
using Hostel.DB;
using Hostel.Model;

namespace Hostel.UI
{
    public partial class FormSpecialities : Form
    {
        private Faculty _faculty;

        public FormSpecialities(Faculty faculty)
        {
            InitializeComponent();
            _faculty = faculty;
            Fill();

            Text = _faculty.Name;
        }

        void Fill()
        {
            lvSpecialities.Items.Clear();
            foreach (var spec in _faculty.Specialities)
                AddItem(spec);
        }

        private void AddItem(Speciality spec)
        {
            var lvi = lvSpecialities.Items.Add(spec.Name);
            lvi.Tag = spec;
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            var dialog = new SpecialityEditDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var speciality = new Speciality(_faculty, dialog.SpecialityName, dialog.SpecialityDuration);
                try
                {
                    Store.Inst.Add(speciality);
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
            if (lvSpecialities.SelectedItems.Count == 0) return;

            var speciality = (Speciality)lvSpecialities.SelectedItems[0].Tag;
            var fed = new SpecialityEditDialog { SpecialityName = speciality.Name };
            if (fed.ShowDialog() != DialogResult.OK) return;

            try
            {
                speciality.Name = fed.SpecialityName;
                speciality.Duration = fed.SpecialityDuration;
                Fill();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsbRemove_Click(object sender, EventArgs e)
        {
            if (lvSpecialities.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Вы действительно хотите специальность?", "Удаление специальности", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var speciality = (Speciality)lvSpecialities.SelectedItems[0].Tag;
                    try
                    {
                        speciality.Delete();
                        Fill();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
