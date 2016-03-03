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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Contact c = new Contact {
                Name = textBox1.Text,
                EmailPhone = textBox2.Text
            };

            var file = Path.Combine(Directory.GetCurrentDirectory(), "contacts.txt");
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                writer.WriteLine(string.Format("{0},{1}", c.Name,c.EmailPhone));
                writer.Flush();
            }
            this.Close();
        }
    }
}
