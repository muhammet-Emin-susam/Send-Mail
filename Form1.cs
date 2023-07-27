using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendMail
{
    
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            Init_Data();
        }

        public static UserLogin staticlogin = new UserLogin();
        DBSENDMAİLEntities db = new DBSENDMAİLEntities();
        UserLogin ul = new UserLogin();
        //public static string up;
        //public static string um;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (Email.Text != string.Empty && Sifre.Text != string.Empty)
            {
                var existuser = db.UserLogin.FirstOrDefault(a => a.UserMail.Equals(Email.Text));
                if (existuser != null)
                {
                    
                    if (existuser.UserPassword.Equals(Sifre.Text))
                    {
                        Save_Data();
                        MessageBox.Show("Girişiniz Başarıyla Gerçekleştirilmiştir.");
                        Sifre.Text = "";
                        Email.Text = "";
                        this.Hide();
                        Email_Send s = new Email_Send();
                        staticlogin = existuser;
                        s.Show();

                        
                        //up = Sifre.Text;
                        //um = Email.Text;
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Kullanıcı Adı ve ya Şifrenizi Kontrol Ediniz.");

                    }
                }
            }
        }
        private void Init_Data()
        {
            if (Properties.Settings.Default.UserName != string.Empty)
            {
                if (Properties.Settings.Default.UserRemember == true)
                {
                    Email.Text = Properties.Settings.Default.UserName;
                    Sifre.Text = Properties.Settings.Default.UserPassword;
                    checkBox1.Checked = true;
                }
                else
                {
                    Email.Text = Properties.Settings.Default.UserName;
                }
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register f = new Register();
            f.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Save_Data()
        {
            if (checkBox1.Checked)
            {
                Properties.Settings.Default.UserName = Email.Text;
                Properties.Settings.Default.UserPassword = Sifre.Text;
                Properties.Settings.Default.UserRemember = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.UserName = "";
                Properties.Settings.Default.UserPassword = "";
                Properties.Settings.Default.UserRemember = false;
                Properties.Settings.Default.Save();
            }
        }
    }
}
