using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace matris_carpma_thread
{
    public partial class Form1 : Form
    {
        volatile int birinci_matris_satir;
        int birinci_matris_sutun;
        volatile int ikinci_matris_satir;
        int ikinci_matris_sutun;
        int[,] birinci_matris;
        int[,] ikinci_matris;
        int[,] yeni_matris;

        Thread thr1;
        Thread thr2;
        Thread thr3;
        Thread thr4;

        Random rndm = new Random();

        Stopwatch zaman1 = new Stopwatch();
        Stopwatch zaman2 = new Stopwatch();
        Stopwatch zaman3 = new Stopwatch();
        Stopwatch zaman4 = new Stopwatch();

        double zmn1;
        double zmn2;
        double zmn3;
        double zmn4;
        

        public Form1()
        {
            InitializeComponent();
             thr1=new Thread(new ThreadStart(carpma1));
             thr2=new Thread(new ThreadStart(carpma2));
             thr3=new Thread(new ThreadStart(carpma3));
             thr4=new Thread(new ThreadStart(carpma4));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            birinci_matris_satir = Convert.ToInt32( textBox1.Text.ToString());
            birinci_matris_sutun = Convert.ToInt32(textBox2.Text.ToString());
            ikinci_matris_satir = Convert.ToInt32(textBox3.Text.ToString());
            ikinci_matris_sutun = Convert.ToInt32(textBox4.Text.ToString());
            birinci_matris =new int [birinci_matris_satir,birinci_matris_sutun];
            ikinci_matris =new int [ikinci_matris_satir,ikinci_matris_sutun];
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
            thr1.Start();
            thr2.Start();
            thr3.Start();
            thr4.Start();
            
            zaman1.Start();
            zaman2.Start();
            zaman3.Start();
            zaman4.Start();
            while (true)
            {
                if (!thr1.IsAlive && !thr2.IsAlive && !thr3.IsAlive && !thr4.IsAlive)
                {
                    zmn1 = Convert.ToDouble( zaman1.ElapsedMilliseconds)/ 1000;
                    zmn2 = Convert.ToDouble(zaman2.ElapsedMilliseconds )/ 1000;
                    zmn3 = Convert.ToDouble(zaman3.ElapsedMilliseconds )/ 1000;
                    zmn4 = Convert.ToDouble(zaman4.ElapsedMilliseconds) / 1000;

                    if (zmn1 > zmn2)
                    {
                        if (zmn3 > zmn4)
                        {
                            if (zmn1 > zmn3)
                            {
                                MessageBox.Show(zmn1.ToString());
                                break;
                            }
                            else
                            {
                                MessageBox.Show(zmn3.ToString());
                                break;
                            }
                        }
                        else
                        {
                            if (zmn1 > zmn4)
                            {
                                MessageBox.Show(zmn1.ToString());
                                break;
                            }
                            else
                            {
                                MessageBox.Show(zmn4.ToString());
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (zmn3 > zmn4)
                        {
                            if (zmn2 > zmn3)
                            {
                                MessageBox.Show(zmn2.ToString());
                                break;
                            }
                            else
                            {
                                MessageBox.Show(zmn3.ToString());
                                break;
                            }
                        }
                        else
                        {
                            if (zmn2 > zmn4)
                            {
                                MessageBox.Show(zmn2.ToString());
                                break;
                            }
                            else
                            {
                                MessageBox.Show(zmn4.ToString());
                                break;
                            }
                        }
                    }
                }
                
            }
            

        }

        public void carpma1()
        {
            
            for (int x = 0; x<birinci_matris_satir/4; x++)  
            {       	      
                for (int y = 0; y < ikinci_matris_sutun/4; y++)
                {
                    for (int k = 0; k < birinci_matris_sutun; k++)

                        yeni_matris[x,y] += birinci_matris[x,k] * ikinci_matris[k,y];        
                }
          
            }

            MessageBox.Show("birinci");
            zaman1.Stop();
            thr1.Abort();
           
        }

        public void carpma2()
        {

            for (int x = birinci_matris_satir/4; x < 2*(birinci_matris_satir / 4); x++)
            {
                for (int y = ikinci_matris_sutun/4 ; y < 2*(ikinci_matris_sutun / 4); y++)
                {
                    for (int k = 0; k < birinci_matris_sutun; k++)

                        yeni_matris[x, y] += birinci_matris[x, k] * ikinci_matris[k, y];        
                }

            }

            MessageBox.Show("ikinci");
            zaman2.Stop();
            thr2.Abort();
            
        }




        public void carpma3()
        {

            for (int x = 2*(birinci_matris_satir) / 4; x < 3 * (birinci_matris_satir / 4); x++)
            {
                for (int y = 2*(ikinci_matris_sutun) / 4; y < 3 * (ikinci_matris_sutun / 4); y++)
                {
                    for (int k = 0; k < birinci_matris_sutun; k++)

                        yeni_matris[x, y] += birinci_matris[x, k] * ikinci_matris[k, y];         
                }

            }
            MessageBox.Show("ucuncu");
            zaman3.Stop();
            thr3.Abort();
            
        }

        public void carpma4()
        {

            for (int x = 3 * (birinci_matris_satir) / 4; x < 4 * (birinci_matris_satir / 4); x++)
            {
                for (int y = 3 * (ikinci_matris_sutun) / 4; y < 4 * (ikinci_matris_sutun / 4); y++)
                {
                    for (int k = 0; k < birinci_matris_sutun; k++)

                        yeni_matris[x, y] += birinci_matris[x, k] * ikinci_matris[k, y];    
                }

            }
            MessageBox.Show("dorduncu");
            zaman4.Stop();
            thr4.Abort();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }




    }
}
