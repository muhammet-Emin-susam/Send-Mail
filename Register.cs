using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace SendMail
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
        DBSENDMAİLEntities db = new DBSENDMAİLEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            UserLogin t = new UserLogin()

            {
                UserMail = LoginEmail.Text,
                UserPassword = LoginPassword.Text,
            };
            db.UserLogin.Add(t);
            db.SaveChanges();
            if (LoginEmail == null && LoginPassword == null)
            {
                MessageBox.Show("Lütfen Geçerli Bir E-mail ve ya Şifre giriniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Hide();
            Form1 fr = new Form1();
            fr.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fb = new Form1();
            fb.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
