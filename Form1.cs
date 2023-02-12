using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace xuanfengchuanti
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[,] map = new int[5, 5];
        int[,] tmap = new int[5, 5];

        int fenshu = 0;
        

        int[] buzhoux = new int[1000];
        int[] buzhouy = new int[1000];

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)

            {
                if(c is TextBox)
                {
                    c.Text = "0";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            map[0, 0] = int.Parse(textBox1.Text);
            map[0, 1] = int.Parse(textBox2.Text);
            map[0, 2] = int.Parse(textBox3.Text);
            map[0, 3] = int.Parse(textBox4.Text);
            map[0, 4] = int.Parse(textBox5.Text);
            map[1, 0] = int.Parse(textBox6.Text);
            map[1, 1] = int.Parse(textBox7.Text);
            map[1, 2] = int.Parse(textBox8.Text);
            map[1, 3] = int.Parse(textBox9.Text);
            map[1, 4] = int.Parse(textBox10.Text);
            map[2, 0] = int.Parse(textBox11.Text);
            map[2, 1] = int.Parse(textBox12.Text);
            map[2, 2] = int.Parse(textBox13.Text);
            map[2, 3] = int.Parse(textBox14.Text);
            map[2, 4] = int.Parse(textBox15.Text);
            map[3, 0] = int.Parse(textBox16.Text);
            map[3, 1] = int.Parse(textBox17.Text);
            map[3, 2] = int.Parse(textBox18.Text);
            map[3, 3] = int.Parse(textBox19.Text);
            map[3, 4] = int.Parse(textBox20.Text);
            map[4, 0] = int.Parse(textBox21.Text);
            map[4, 1] = int.Parse(textBox22.Text);
            map[4, 2] = int.Parse(textBox23.Text);
            map[4, 3] = int.Parse(textBox24.Text);
            map[4, 4] = int.Parse(textBox25.Text);
            textBox26.Text = "";
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    tmap[i, j] = map[i, j];
                }
            }//map传给临时tmap
           
                for (int j = 1; j < 4; j++)
                {
                    for (int k = 1; k < 4; k++)
                    {
                        xuanfeng(j, k);
                        if (jisuan() > fenshu)
                        {
                            buzhoux[j] = j+1;
                            buzhouy[j] = k+1;
                            fenshu = jisuan();
                        }
                        for (int o = 0; o < 5; o++)
                        {
                            for (int p = 0; p < 5; p++)
                            {
                                tmap[o, p] = map[o, p];
                            }
                        }
                    }
                }



            for (int i = 0; i < 1000; i++)//
            {
                if (buzhoux[i] != 0 || buzhouy[i] != 0)
                {
                        textBox26.Text = textBox26.Text + "|" + buzhoux[i] + "，" + buzhouy[i] + "|" + fenshu;

                   

                }

            }
        }
        int xuanfeng(int m, int n)
        {
            int temp = 0;
            temp = tmap[m - 1, n - 1];
            tmap[m - 1, n - 1] = tmap[m, n - 1];

            tmap[m, n - 1] = tmap[m + 1, n - 1];

            tmap[m + 1, n - 1] = tmap[m + 1, n];

            tmap[m + 1, n] = tmap[m + 1, n + 1];
            tmap[m + 1, n + 1] = tmap[m, n + 1];

            tmap[m, n + 1] = tmap[m - 1, n + 1];

            tmap[m - 1, n + 1] = tmap[m - 1, n];
            tmap[m - 1, n] = temp;


            return jisuan();
        }//使用旋风移动数据

        int jisuan()
        {
            int rempsc = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (tmap[i, j] == 2)
                    {

                        for (int k = 0; k < 5; k++)
                        {
                            for (int m = 0; m < 5; m++)
                            {
                                if ((i - k) * (i - k) + (j - m) * (j - m) < 7 && tmap[k, m] > 0)
                                {
                                    rempsc++;
                                }
                            }
                        }
                    }
                }
            }
            return rempsc;
        }//计算数组分数
    }
}
