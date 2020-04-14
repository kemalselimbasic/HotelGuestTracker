using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;

namespace hotelv2
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { baza mongo = new baza();
            if (textBox4.Text != textBox5.Text)
            {
                MessageBox.Show("Lozinke nisu iste", "Error");
                this.Close();
            }
            user test = mongo.findOne<user>("users", textBox3.Text);
           
            user korisnik = new user {
                ime = textBox1.Text,
                prezime = textBox2.Text,
                username = textBox3.Text,
                password = textBox4.Text


            };


            if (test.username == "a")
            {

               mongo.insertRecord("users", korisnik);
               MessageBox.Show("Uspjesno ste sacuvali gosta");
               this.Close();
            
            }
            else
            {

                MessageBox.Show("Korisnik vec postoji");
            
            }
            
            

        }
    }
}
