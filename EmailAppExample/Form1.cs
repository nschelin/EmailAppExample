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

namespace EmailAppExample
{
    public partial class Form1 : Form
    {
        List<Contact> contacts = new List<Contact>();
        public Form1()
        {
            InitializeComponent();
            Populate();
            comboBox1.DataSource = contacts;
            comboBox1.DisplayMember = "Name";
        }

        private void Populate()
        {
            var file = Path.Combine(Directory.GetCurrentDirectory(), "contacts.txt");
            using (StreamReader reader = new StreamReader(file)) {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] split = line.Split(',');
                    Contact c = new Contact {
                        Name = split[0],
                        EmailPhone = split[1]
                    };
                    contacts.Add(c);
                }
            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            Contact c = (Contact)comboBox1.SelectedValue;
            textBox1.Text = c.EmailPhone;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.FormClosed += Form_FormClosed;
            form.ShowDialog();
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            contacts.Clear();

            Populate();
            comboBox1.DataSource = null;
            comboBox1.DataSource = contacts;
            comboBox1.DisplayMember = "Name";
        }
    }
}
