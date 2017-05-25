using System;
using System.Windows.Forms;

namespace Hostel.UI
{
    public partial class FacultyEditDialog : Form
    {
        public FacultyEditDialog()
        {
            InitializeComponent();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public string FacultyName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }
    }
}
