using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMIS_WEBSITE_VER._02
{
    public partial class Physical_profile : Form
    {
        public Physical_profile()
        {
            InitializeComponent();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Add_Student_Medical_Record form = new Add_Student_Medical_Record();
            form.ShowDialog();
        }
    }
}
