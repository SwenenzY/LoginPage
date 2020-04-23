using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginPage
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register reg = new Register();
            reg.Show();       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int wins = 0;
            string aname = null;
            FileStream file = new FileStream(@"F:\\LoginPage\\LoginPage\\bin\\Debug\\Accounts.txt", FileMode.Open);
            StreamReader sw = new StreamReader(file);
            int Errorcount = 0;
            for (int i = 0; i < file.Length; i++)
            {
              
                string text = sw.ReadLine();
                if (string.IsNullOrEmpty(text)) continue;
                int Long = text.LastIndexOf(':');
                string password = text.Substring(Long+1); 
                string Username = text.Substring(0, Long);
                string name = textBox1.Text;
                string pass = textBox2.Text;
                aname = name;
                if (Username == name && pass == password)
                {
                    wins++;
                      
                }
            }
         
            if (wins == 1)
            {
                MessageBox.Show("Hi " + aname + "!");
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }

            sw.Close();
            file.Close();
        }
    }
}
