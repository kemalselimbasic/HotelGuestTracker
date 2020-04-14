using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace hotelv2
{
    public partial class login : Form
    {
        baza mongo = new baza();
        public login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form reg = new register();
            reg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string pwd = textBox2.Text;

            var korisnik=mongo.findOne<user>("users",username);
            if(korisnik.password==pwd && korisnik.username == username)
            {
                Form home = new Form1();
                
                home.Show();
                
            }
            else
            {
                MessageBox.Show("Neuspjesan login pokusajte ponovo!", "Login error");
            }
        }
    }
}
