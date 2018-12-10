using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection sqlcnn = new SqlConnection(@"Data Source=VTHANHQUD8DD\SQLEXPRESS;Initial Catalog=NhanVien2;Integrated Security=True");

        SqlDataAdapter daNV;
        SqlDataAdapter daCV;

        DataSet ds = new DataSet(); //tao nho lam 1 lan o tren la dc r




        private void Form1_Load(object sender, EventArgs e)
        {

            //load combobox chuc vu
            string query_chucvu = "select * from ChucVu";
            daCV = new SqlDataAdapter(query_chucvu, sqlcnn);
            //cach nao cung dung

            daCV.Fill(ds, "chucvu");

            comboBox_chucvu.DataSource = ds.Tables[0];
            comboBox_chucvu.DisplayMember = "tenchucvu";
            comboBox_chucvu.ValueMember = "machucvu";

            refesh();

            /*
             * 
             * Them
             * 
             */

            string query_them = "insert into NhanVien values(@maso,@ho,@ten,@ngaysinh,@gioitinh,@machucvu)";
            SqlCommand cmd_them = new SqlCommand(query_them, sqlcnn);
            cmd_them.Parameters.Add("@maso",SqlDbType.Char,20, "maso");
            cmd_them.Parameters.Add("@ho", SqlDbType.Char, 20, "ho");
            cmd_them.Parameters.Add("@ten", SqlDbType.Char, 20, "ten");
            //            cmd_them.Parameters.AddWithValue("@ngaysinh", "ngaysinh");
            cmd_them.Parameters.Add("@ngaysinh", SqlDbType.DateTime, 10, "ngaysinh");
            cmd_them.Parameters.Add("@gioitinh", SqlDbType.Char, 20, "gioitinh");
            cmd_them.Parameters.Add("@machucvu", SqlDbType.Char, 2, "machucvu");

            daNV.InsertCommand = cmd_them;



            string query_xoa = "delete from nhanvien where maso = @maso";
            SqlCommand cmd_xoa = new SqlCommand(query_xoa, sqlcnn);
            cmd_xoa.Parameters.Add("@maso", SqlDbType.Char, 20, "maso");
            daNV.DeleteCommand = cmd_xoa;
        }


        public void refesh()
        {
            string query_refesh = "select nv.*, cv.tenchucvu from NhanVien as nv, ChucVu as cv where nv.machucvu = cv.machucvu";
            daNV = new SqlDataAdapter(query_refesh, sqlcnn);
            daNV.Fill(ds, "nhanvien");
            dataGridView1.DataSource = ds.Tables[1];
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            //xu ly them tren dgv
            DataRow row = ds.Tables[1].NewRow();
            row["maso"] = textBox_ms.Text;
            row["ho"] = textBox_ho.Text;
            row["ten"] = textBox_ten.Text;
            row["ngaysinh"] = dateTimePicker1.Value;
            if (radioButton_nam.Checked == true)
                row["gioitinh"] = "Nam";
            else
                row["gioitinh"] = "Nu";
            row["machucvu"] = comboBox_chucvu.SelectedValue;

            ds.Tables[1].Rows.Add(row);
        }

        private void button_luu_Click(object sender, EventArgs e)
        {
            daNV.Update(ds, "nhanvien");
            MessageBox.Show("Saved!");
            dataGridView1.Refresh();
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            dataGridView1.Rows.Remove(dr);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int current = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow dr = dataGridView1.Rows[current];

            textBox_ms.Text = dr.Cells["maso"].Value.ToString();
            textBox_ho.Text = dr.Cells["ho"].Value.ToString();
            textBox_ten.Text = dr.Cells["ten"].Value.ToString();
            dateTimePicker1.Text = dr.Cells["ngaysinh"].Value.ToString();
            if (dr.Cells["gioitinh"].Value.ToString() == "Nam")
                radioButton_nam.Checked = true;
            else
                radioButton_nu.Checked = true;
            
        }
    }

}
