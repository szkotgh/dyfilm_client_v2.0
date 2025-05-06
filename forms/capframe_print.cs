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
    public partial class capframe_print : Frame
    {
        public capframe_print()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            create_capframe.print_count = Convert.ToInt32(numericUpDown1.Value);
            create_capframe.cf_id = textBox1.Text;
            create_capframe.is_capture = radioButton2.Checked;
            new create_capframe().ShowDialog();
        }
    }
}
