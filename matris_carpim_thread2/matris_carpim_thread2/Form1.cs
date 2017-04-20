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

namespace matris_carpim_thread2
{
    public partial class Form1 : Form
    {
        volatile int birinci_matris_satir;
        volatile int birinci_matris_sutun;
        volatile int ikinci_matris_satir;
        volatile int ikinci_matris_sutun;
        bool [] matris_satir;
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

        private void Form1_Load(object sender, EventArgs e)
        {

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
            matris_satir =new bool[birinci_matris_satir];

             for (int x = 0; x < birinci_matris_satir; x++)
            {
               matris_satir[x]=true;
            }


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

                    zmn1 = Convert.ToDouble(zaman1.ElapsedMilliseconds) / 1000;
                    zmn2 = Convert.ToDouble(zaman2.ElapsedMilliseconds) / 1000;
                    zmn3 = Convert.ToDouble(zaman3.ElapsedMilliseconds) / 1000;
                    zmn4 = Convert.ToDouble(zaman4.ElapsedMilliseconds) / 1000;

                    MessageBox.Show(zmn1.ToString());
                    MessageBox.Show(zmn2.ToString());
                    MessageBox.Show(zmn3.ToString());
                    MessageBox.Show(zmn4.ToString());

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
          
              

                for (int x = 0; x<birinci_matris_satir; x++)
                {
                    if (matris_satir[x])
                    {
                        matris_satir[x] = false;  	      
                         for (int y = 0; y < ikinci_matris_sutun; y++)
                          {
                             for (int k = 0; k < birinci_matris_sutun; k++)
                              {

                             yeni_matris[x,y] += birinci_matris[x,k] * ikinci_matris[k,y];        
                               }
                           }
                  
                     }
                }
           

            MessageBox.Show("birinci");
            zaman1.Stop();
            thr1.Abort();
          }

         public void carpma2()
         {
            

                     for (int x = 0; x < birinci_matris_satir; x++)
                     {
                         if (matris_satir[x])
                         {
                            matris_satir[x] = false;  	      

                             for (int y = 0; y < ikinci_matris_sutun; y++)
                                 {
                                      for (int k = 0; k < birinci_matris_sutun; k++)
                                         {

                                           yeni_matris[x, y] += birinci_matris[x, k] * ikinci_matris[k, y];
                                            }
                                     }

                            }
                        }
             

             MessageBox.Show("birinci");
             zaman2.Stop();
             thr2.Abort();
         }

         public void carpma3()
         {
            

                     for (int x = 0; x < birinci_matris_satir; x++)
                     {

                         if (matris_satir[x])
                          {
                               matris_satir[x] = false;  	      

                                  for (int y = 0; y < ikinci_matris_sutun; y++)
                                     {
                                        for (int k = 0; k < birinci_matris_sutun; k++)
                                             {

                                              yeni_matris[x, y] += birinci_matris[x, k] * ikinci_matris[k, y];
                                          }
                                      }

                              }
                          }
             

             MessageBox.Show("birinci");
             zaman3.Stop();
             thr3.Abort();
         }



         public void carpma4()
         {
           ;

                     for (int x = 0; x < birinci_matris_satir; x++)
                     {

                         if (matris_satir[x])
                               {
                                 matris_satir[x] = false;  	      

                                   for (int y = 0; y < ikinci_matris_sutun; y++)
                                       {
                                          for (int k = 0; k < birinci_matris_sutun; k++)
                                             {

                                                yeni_matris[x, y] += birinci_matris[x, k] * ikinci_matris[k, y];
                                                }
                                       }

                                  }
                          }
             

             MessageBox.Show("birinci");
             zaman4.Stop();
             thr4.Abort();
         }
    }
}
