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
using System.IO;
using System.Diagnostics;
using DevExpress.XtraEditors;

namespace SendMail
{
    public partial class Email_Send : Form
    {
        public Email_Send()
        {
            InitializeComponent();
        }
        DBSENDMAİLEntities db = new DBSENDMAİLEntities();
        private void label3_Click(object sender, EventArgs e)
        {

        }
        string DosyaYolu;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (SendEmail == null)
            {
                MessageBox.Show("Lütfen Geçerli Bir E-mail adresi giriniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //try
            //{ 
            //    SmtpClient client = new SmtpClient("smtp.yandex.com", 587);
            //    client.EnableSsl = true;
            //    client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //    client.Credentials = new NetworkCredential(Form1.staticlogin.UserMail, Form1.staticlogin.UserPassword);
            //    MailAddress from = new MailAddress(Form1.staticlogin.UserMail, "DENEME");
            //    MailAddress to = new MailAddress(SendEmail.Text);
            //    MailMessage message = new MailMessage(from, to);

            //    message.Body = SendMessage.Text;
            //    message.IsBodyHtml = true;
            //    message.Subject = SendSubject.Text;
            //    message.SubjectEncoding = System.Text.Encoding.UTF8;
            //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

            //    client.Send(message);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            try
            {
                MailMessage mesajim = new MailMessage();
                SmtpClient istemci = new SmtpClient();
                //istemci.UseDefaultCredentials = false;
                istemci.Credentials = new System.Net.NetworkCredential(Form1.staticlogin.UserMail, Form1.staticlogin.UserPassword);
                istemci.Port = 587;
                istemci.Host = "smtp.yandex.com.tr";
                istemci.EnableSsl = true;
                mesajim.To.Add(SendEmail.Text);
                mesajim.From = new MailAddress(Form1.staticlogin.UserMail);
                mesajim.Subject = SendSubject.Text;
                mesajim.Body = SendMessage.Text;
                mesajim.Attachments.Add(new Attachment(DosyaYolu));
                istemci.Send(mesajim);
                
                XtraMessageBox.Show("Mesaj gönderme işlemi başarılı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                
            }
            
            
        }

        private void pictureEdit2_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fb = new Form1();
            fb.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var kategoriler = db.UserLogin.ToList();
            dataGridView1.DataSource = kategoriler;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Title = "www.yazilimkodlama.com";
            dosya.ShowDialog();
            DosyaYolu = dosya.FileName;
                

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Process.Start(button.Tag.ToString());
        }
    }
}
