using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoDB.Driver;

namespace hotelv2
{
    public partial class Form3 : Form
    {
        baza mongo = new baza();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            Guest query = new Guest {

                ime = ime.Text,
                prezime = prezime.Text,
                jmbg = jmbg.Text,
                brojSobe = soba.Text,
                brojtel = brojtel.Text,
                datumDolaska = dateTimePicker1.Value.ToShortDateString(),
                datumOdlaska = dateTimePicker2.Value.ToShortDateString()
            

            };
            if (!checkBox1.Checked)
            {
                
                query.datumDolaska = "";


            }
            if (!checkBox2.Checked)
            {
                query.datumOdlaska = "";
               


            }

            Guest res = mongo.findDoc<Guest>("gosti",query.ime,query.prezime,query.jmbg,query.brojSobe,query.brojtel,query.datumDolaska,query.datumOdlaska);
            listBox1.Items.Add("Ime: "+res.ime+" prezime: "+res.prezime+" jmbg: "+ res.jmbg + " broj telefona: " + res.brojtel+" datum dolaska: "+res.datumDolaska + " datum odlaska: " + res.datumOdlaska+ " sprat: "+res.sprat + " broj sobe: " + res.brojSobe);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           var records= mongo.findAll<Guest>("gosti");
            foreach (var res in records)
            {

                listBox1.Items.Add("Ime: " + res.ime + " prezime: " + res.prezime + " jmbg: " + res.jmbg + " broj telefona: " + res.brojtel + " datum dolaska: " + res.datumDolaska + " datum odlaska: " + res.datumOdlaska + " sprat: " + res.sprat + " broj sobe: " + res.brojSobe);

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dateTimePicker1.Visible = true;
              
            }
            else
            {
                dateTimePicker1.Visible = false;
              
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
               ;
                dateTimePicker2.Visible = true;
            }
            else
            {
                
                dateTimePicker2.Visible = false;
            }
        }
    }
        
}
