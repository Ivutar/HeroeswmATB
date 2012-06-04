using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ATB.Data;

namespace ATB.Win
{
    public partial class frmUnits : Form
    {
        public frmUnits()
        {
            InitializeComponent();
        }

        private void frmUnits_Activated(object sender, EventArgs e)
        {
            try
            {
                using (atbEntities ctx = new atbEntities())
                {
                    dgvUnits.DataSource = ctx.units;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
