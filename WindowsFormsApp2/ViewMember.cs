﻿using System;
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
    public partial class ViewMember : Form
    {
        public ViewMember()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\OneDrive\Documents\GymDatabase.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            con.Open();
            String query = "select * from Membertbl";
            SqlDataAdapter sda = new SqlDataAdapter(query,con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            MemberSDGV.DataSource = ds.Tables[0];


            con.Close();

        }
        private void ViewMember_Load(object sender, EventArgs e)
        {
            populate();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();

        }
    }
}
