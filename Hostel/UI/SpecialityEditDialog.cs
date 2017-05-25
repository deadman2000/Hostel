using System.Windows.Forms;

namespace Hostel.UI
{
    public partial class SpecialityEditDialog : Form
    {
        public SpecialityEditDialog()
        {
            InitializeComponent();
        }

        public string SpecialityName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }

        public int SpecialityDuration => (int)nudDuration.Value;

        private void btOK_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
