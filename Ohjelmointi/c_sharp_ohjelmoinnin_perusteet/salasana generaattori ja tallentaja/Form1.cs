using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace mumman_salasanat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void luo_Click(object sender, EventArgs e)
        {

            int minimipituus = 8;
            int maksimipituus = 12;

            string mahdollisetmerkit = "abcdefghijklmnopqrestuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!?";
            StringBuilder salasana = new StringBuilder();
            Random random = new Random();
            int salasananpituus = random.Next(minimipituus, maksimipituus + 1);

            while (salasananpituus-- > 0)
                salasana.Append(mahdollisetmerkit[random.Next(mahdollisetmerkit.Length)]);
                  label1.Text = salasana.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nykyinenkauttaja = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            StreamWriter tiedosto = new StreamWriter(nykyinenkauttaja + "\\salasanat.txt", true);
            tiedosto.Write("\n" + textBox1.Text + " = " + label1.Text);
            tiedosto.Close();
           
        }
    }
}
