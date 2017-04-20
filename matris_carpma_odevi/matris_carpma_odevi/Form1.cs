using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace matris_carpma_odevi
{
    public partial class Form1 : Form
    {
        int birinci_matris_satir;
        int birinci_matris_sutun;
        int ikinci_matris_satir;
        int ikinci_matris_sutun;
        int[,] birinci_matris;
        int[,] ikinci_matris;
        int[,] yeni_matris;

        Random rndm = new Random();

        Stopwatch zaman1 = new Stopwatch();
        double zmn1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            birinci_matris_satir = Convert.ToInt32(textBox1.Text.ToString());
            birinci_matris_sutun = Convert.ToInt32(textBox2.Text.ToString());
            ikinci_matris_satir = Convert.ToInt32(textBox3.Text.ToString());
            ikinci_matris_sutun = Convert.ToInt32(textBox4.Text.ToString());
            birinci_matris = new int[birinci_matris_satir, birinci_matris_sutun];
            ikinci_matris = new int[ikinci_matris_satir, ikinci_matris_sutun];
            yeni_matris = new int[birinci_matris_satir, ikinci_matris_sutun];

            for (int x = 0; x < birinci_matris_satir; x++)
            {
                for (int y = 0; y < birinci_matris_sutun; y++)
                {
                    birinci_matris[x, y] = rndm.Next(1, 10);
                }
            }

            for (int x = 0; x < ikinci_matris_satir; x++)
            {
                for (int y = 0; y < ikinci_matris_sutun; y++)
                {
                    ikinci_matris[x, y] = rndm.Next(1, 10);
                }
            }

            MessageBox.Show("Matrisler oluşturuldu!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            zaman1.Start();
            for (int x = 0; x < birinci_matris_satir ; x++)
            {
                for (int y = 0; y < ikinci_matris_sutun; y++)
                {
                    for (int k = 0; k < birinci_matris_sutun; k++)

                        yeni_matris[x, y] += birinci_matris[x, k] * ikinci_matris[k, y];
                }

            }

            zaman1.Stop();

            zmn1 = Convert.ToDouble(zaman1.ElapsedMilliseconds) / 1000;

            MessageBox.Show(zmn1.ToString());
        }
    }
}
