using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateIssueAuto
{
    public partial class Form1 : Form
    {
        private Form2 _form2;
        private Form3 _form3;

        public Form1(Form2 form2, Form3 form3)
        {
            _form2 = form2;
            _form3 = form3;
            InitializeComponent();
        }

        private void btnForm2_Click(object sender, EventArgs e)
        {
            
            _form2.ShowDialog();
        }

        private void btnForm3_Click(object sender, EventArgs e)
        {
            
            _form3.ShowDialog();
        }
    }
}
