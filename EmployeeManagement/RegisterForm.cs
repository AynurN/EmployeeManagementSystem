using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagement
{
    public partial class RegisterForm : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Documents\employee.mdf;Integrated Security=True;Connect Timeout=30");
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signin_btn_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Hide();
        }

        private void register_showPassword_CheckedChanged(object sender, EventArgs e)
        {
            register_password.PasswordChar = register_showPassword.Checked ? '\0' : '*';
        }

        private void register_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void signup_btn_Click(object sender, EventArgs e)
        {
            if (register_username.Text == "" || register_password.Text == "") MessageBox.Show("Please fill all the blank areas!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (connection.State != ConnectionState.Open)
                {
                    try
                    {
                        connection.Open();
                        string selectUserName = "select count(id) from users where username=@user";
                        using (SqlCommand checkUser = new SqlCommand(selectUserName, connection)) {
                            checkUser.Parameters.AddWithValue("@user",register_username.Text.Trim());
                            int count = (int)checkUser.ExecuteScalar();
                            if (count > 0) {
                                MessageBox.Show("This user already exists!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                DateTime today = DateTime.Today;
                                string insertData = "insert into users " +
                                    "(username,password,regiter_date)" +
                                    "values(@username, @password, @dateReg)";
                                using (SqlCommand cmd = new SqlCommand(insertData, connection))
                                {
                                    cmd.Parameters.AddWithValue("@username", register_username.Text.Trim());
                                    cmd.Parameters.AddWithValue("@password", register_password.Text.Trim());
                                    cmd.Parameters.AddWithValue("@dateReg", today);
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Registered successfully!", "Information message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Form1 loginForm = new Form1();
                                    loginForm.Show();
                                    this.Hide();
                                }
                            }
                        }
                        

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error:" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }

            }
        }
    }
}
