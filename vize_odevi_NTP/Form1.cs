using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
namespace vize_odevi_NTP

{
    public partial class Form1 : Form
    {
        string altin_link = "http://www.kulcealtin.com/altinxml/";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(altin_link);
            XmlElement root = doc1.DocumentElement;

            XmlNodeList nodes = root.SelectNodes("altin");

            foreach (XmlNode node in nodes)
            {
                string adi = node["adi"].InnerText;
                string al = node["sat"].InnerText;
                string sat = node["al"].InnerText;

                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = adi;
                row.Cells[1].Value = sat;
                row.Cells[2].Value = al;
                dataGridView1.Rows.Add(row);
            }


            TextWriter writer = new StreamWriter(@"C:\Users\Bycymon\Desktop/xml.txt");

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    writer.Write("" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                }
                writer.WriteLine("");
                writer.WriteLine("------------------------------------------------");
            }
            writer.Close();
            MessageBox.Show("Txt Kaydedildi..");
            




        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Veri Güncellenme Tarihi  " + DateTime.Now.ToLongDateString());
        }
    }
}
