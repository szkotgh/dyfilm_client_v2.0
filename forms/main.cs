using dyfilm_client_v2._0.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dyfilm_client_v2._0.forms
{
    public partial class main : Frame
    {
        public main()
        {
            InitializeComponent();
        }

        private void panel_main_Click(object sender, EventArgs e)
        {
            start_dyfilm();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            start_dyfilm();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            start_dyfilm();
        }

        private void start_dyfilm()
        {
            Hide();
            new sel_frame().ShowDialog();
        }
    }
}
