using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace On_Thi
{
    public partial class Form1 : Form
    {
        array arr = new array();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void input_arr()
        {
            string txtnhap = textBoxinput.Text;
            arr.create_arr(txtnhap); //luu gia tri mang duoc tao vao Array.Arr
            textBox_aswer.Text = arr.Array_created.ToString();
        }

        private void buttonoutput_Click(object sender, EventArgs e)
        {

            input_arr();   

        }

        private void button_sort_Click(object sender, EventArgs e)
        {
           
            if (radioButton1.Checked == true)
            {
                arr.sort_increase(arr.Arr);

            }
            textBox_aswer.Text = arr.Array_increase;
        }
    }
}
