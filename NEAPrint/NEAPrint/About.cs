using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NEAPrint
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            versionLabel.Text = Utils.GetAssemblyInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
