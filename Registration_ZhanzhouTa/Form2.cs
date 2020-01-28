using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registration_ZhanzhouTa
{
    public partial class Form2 : Form
    {
        public string DataToTransferForm2;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //recive the information from form1 and display in textBox1
            textBox1.Text = DataToTransferForm2;
        }
    }
}
