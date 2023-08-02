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
    public partial class UpdateDelete : Form
    {
        public UpdateDelete()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void gunaDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\OneDrive\Documents\GymDatabase.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            con.Open();
            String query = "select * from Membertbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            MemberSDGV.DataSource = ds.Tables[0];


            con.Close();

        }


        private void UpdateDelete_Load(object sender, EventArgs e)
        {
            populate();

        }
        int key=0;

        private void MemberSDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key = Convert.ToInt32(MemberSDGV.SelectedRows[0].Cells[0].Value.ToString());
            Nametb.Text = MemberSDGV.SelectedRows[0].Cells[1].Value.ToString();
            phonetb.Text = MemberSDGV.SelectedRows[0].Cells[2].Value.ToString();
            Gendercb.Text = MemberSDGV.SelectedRows[0].Cells[3].Value.ToString();
            Timingcb.Text = MemberSDGV.SelectedRows[0].Cells[4].Value.ToString();
            Amnttb.Text = MemberSDGV.SelectedRows[0].Cells[5].Value.ToString();
            Agetb.Text = MemberSDGV.SelectedRows[0].Cells[6].Value.ToString();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Nametb.Text = "";
            phonetb.Text = "";
            Agetb.Text = "";
            Gendercb.Text = "";
            Timingcb.Text = "";
            Amnttb.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            log.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(key== 0)
            {
                MessageBox.Show("Select The Member to Be Deleted");

            }
            else
            {
                try
                {
                    con.Open();
                    String query = "delete from Membertbl where MID=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member Deleted Succesfully");
                    con.Close();
                    populate();


                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0 || Nametb.Text== "" || phonetb.Text== "" || Agetb.Text== "" || Timingcb.Text== ""|| Gendercb.Text== "" || Amnttb.Text== "" )
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    con.Open();
                    String query = "updatee Membertbl set MName = '" + Nametb.Text + "',MPhone = '" + phonetb.Text + "',MGen = '"+Gendercb.Text+"',MAge = '"+Agetb.Text + "',MAmount = '" +Amnttb.Text+"',MTiming ='"+Timingcb.Text+"'where MID = "+key+";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member Deleted Succesfully");
                    con.Close();
                    populate();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }
    }
}
