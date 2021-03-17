using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        connection con = new connection();
        string username, password;

        public Form1()
        {
            InitializeComponent(); 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            con.Open();

            try
            {
                if (userBox.Text != "*" || passwordBox.Text != "*") //1
                {
                    string query = "SELECT [Login],[Password] FROM Users WHERE [Login] ='" + userBox.Text + "' AND [Password] ='" + passwordBox.Text + "';";
                    SqlDataReader row;
                    row = con.ExecuteReader(query);
                    if (row.HasRows)
                    {
                        while (row.Read())
                        {
                            username = row["Login"].ToString();
                            password = row["Password"].ToString();
                        }

                        MessageBox.Show("Вы зашли как: " + userBox.Text + ".");
                    }
                    else
                    {
                        MessageBox.Show("Логин или Пароль не верны", "Information");
                    }
                }
                else
                {
                    MessageBox.Show("Требуется заполнить поля авторизации.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
