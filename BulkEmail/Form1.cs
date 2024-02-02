using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace BulkEmail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void buttonSend_Click(object sender, EventArgs e)
        {
            string emailAdd = textBoxEmail.Text;
            string pass = textBoxPass.Text;
            string accCode = "MAKI";
            string accName= "Makita";
            string accEmail = "makita@gmail";
            string firstName = "Makita";


            MimeMessage email = new MimeMessage();

            email.From.Add(new MailboxAddress("Sam Ladbrook", emailAdd));
            email.To.Add(new MailboxAddress("Craig Ladbrook", "craig.ladbrook@mitre10.co.nz"));
            email.To.Add(new MailboxAddress("Craig Ladbrook", "craig.ladbrook@mitre10.co.nz"));

            email.Subject = "Test email";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $@"<p>Dear {firstName},</p>
                        <p>Account Code: {accCode}</p>
                        <p>Account Name: {accName}</p>
                        <p>Account Email: {accEmail}</p>
                        <p>Over the next 3 months, Taupo Mitre 10 MEGA is migrating to a new software system called SAP.</p>
                        <p>With this new system being introduced, we now have certain new criteria for customer accounts,
                        in-particular around minimum monthly dollar spend which is now set at $500.00 a month.
                        Due to your current spend not meeting this criteria we have had to de-activate your account prior to switching over to the new system.
                        If you believe your spending may change either now or in the future, please feel free to make contact with us to discuss options,
                        which we are more than happy to do as we certainly value your business.</p>
                        <p>We apologize if this causes any inconvenience but again we are happy to discuss if your circumstances change.
                        If this is the case, in the first instance, you can speak to the team at Customer Services who will take all your details.</p>
                        <p>Thanks again for your continued business.</p>
                        <p>Your Sincerely,</p>
                        <p>Craig Ladbrook</p>
                        <p>Director / Member Principal</p>
                        <p>M: 027 555 3338   E: craig.ladbrook@mitre10.co.nz</p>
                        <p>Mitre 10 Mega Taupo</p>
                        <p>99 Bella George Lane, Taupo 3379 | PO Box 824, Taupo, 3351</p>"
            };
            

            using (SmtpClient smtpClient = new SmtpClient())
            {
                //smtpClient.Connect("209.133.218.2", 587, false);
                smtpClient.Connect("smtp.office365.com", 587, false);

                
                smtpClient.Authenticate(emailAdd, pass);

                smtpClient.Send(email);
                MessageBox.Show("the message should be sent");


                smtpClient.Disconnect(true);
                
            }
        }

        private void checkBoxPassSH_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPassSH.Checked)
            {
                textBoxPass.UseSystemPasswordChar = PasswordPropertyTextAttribute.No.Password;
            }
            else
            {
                textBoxPass.UseSystemPasswordChar = PasswordPropertyTextAttribute.Yes.Password;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxPass.UseSystemPasswordChar = PasswordPropertyTextAttribute.Yes.Password;

        }
    }
}
