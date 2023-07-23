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

namespace WindowsFormsApp2
{
    public partial class Addmember : Form
    {
        public Addmember()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\OneDrive\Documents\GymDatabase.mdf;Integrated Security=True;Connect Timeout=30");

        private void Addmember_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mbname.Text == "" || phone.Text == "" || Amount.Text == "" || aget.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    String query = "insert into Membertbl values('" + mbname.Text + "','" + phone.Text + "','" + gender.SelectedItem.ToString() + "'," + aget.Text + "," + Amount.Text + ",'" + timing.SelectedItem.ToString() + "')";

                   SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member successfully Added");
                    Amount.Text = "";
                    aget.Text = "";
                    mbname.Text = "";
                    phone.Text = "";
                    gender.Text = "";
                    timing.Text = "";


                    con.Close();


                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Amount.Text = "";
            aget.Text = "";
            mbname.Text = "";
            phone.Text = "";
            gender.Text = "";
            timing.Text = "";

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();

        }
    }
}
