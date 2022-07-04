using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventory_Sytem.Forms;

namespace Inventory_Sytem {
    public partial class FrmMainMenu : Form {
        private Form ActiveForm;

        public FrmMainMenu() {
            InitializeComponent();
        }

        private void btnProduct_Click(object sender, EventArgs e) {
            OpenChildForm(new frmProduct(), sender);
        }

        private void btnCategory_Click(object sender, EventArgs e) {
            OpenChildForm(new frmCategory(), sender);
        }

        private void OpenChildForm(Form childForm, object sender) {
            if (ActiveForm != null) {
                ActiveForm.Close();
            }
            ActiveForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelChild.Controls.Add(childForm);
            this.panelChild.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            
        }
    }
}
