using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public partial class Form1 : Form
    {
        public string s;

        public Form1(FileInfo x)
        {

            InitializeComponent();
            s = x.FullName;

            try
            {
                pictureBox1.Image = Image.FromFile(s);
            }
            catch
            {
                MessageBox.Show("File can't be open", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

    }
}
