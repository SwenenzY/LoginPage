using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginPage
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login log = new Login();
            log.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool alreadyhave = false;
            string puser = textBox1.Text;
            string ppass = textBox2.Text;
            FileStream filex = new FileStream(@"F:\\LoginPage\\LoginPage\\bin\\Debug\\Accounts.txt", FileMode.Open);
            StreamReader swx = new StreamReader(filex);
            for (int i = 0; i < filex.Length; i++)
            {

                string textx = swx.ReadLine();
                if (string.IsNullOrEmpty(textx)) continue;
                int Long = textx.LastIndexOf(':');
                string password = textx.Substring(Long + 1);
                string Username = textx.Substring(0, Long);
                if (puser == Username)
                {
                    alreadyhave = true;
                }
            }
            swx.Close();
            filex.Close();
            
            string text = File.ReadAllText(@"F:\\LoginPage\\LoginPage\\bin\\Debug\\Accounts.txt");
            FileStream file = new FileStream(@"F:\\LoginPage\\LoginPage\\bin\\Debug\\Accounts.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(file);
            if (textBox2.Text.Length < 6)
            {
                MessageBox.Show("Error! your password lower a 6");
                return;
            }
            if (alreadyhave)
            {
                MessageBox.Show("Error! your username already using");
                return;
            }
            if (textBox1.Text == null)
            {
                MessageBox.Show("Error! Blank username");
            } else if (textBox2.Text == null)
            {
                MessageBox.Show("Error! Blank Password");
            }
            else
            {
                string Name = textBox1.Text;
                string Pass = textBox2.Text;
                sw.Write(text + "\n\n" + Environment.NewLine  + Name + ":" + Pass);
                sw.Flush();
                MessageBox.Show("Your register as successful, you're now login! \n your redicting.... in 2 seconds");
                Thread.Sleep(2000);
                this.Hide();
                Login log = new Login();
                log.Show();
            }
            sw.Close();
            file.Close();
            Thread.Sleep(1000);
        }
    }
}
