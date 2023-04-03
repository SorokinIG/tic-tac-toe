using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




/// <summary>
/// |0 3 6|
/// |1 4 7|  -- расположение номеров кнопок
/// |2 5 8|
/// </summary>
/// 
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int h;
        private int v;
        private int k; //ход

        private string krest = "X";
        private string nol = "O";
        private int player;
        private int run;
        private Button[] a  = new Button[50];
   



        public Form1()
        {
            
            InitializeComponent();
            krest = "X";
            nol = "O";
            Random r = new Random();
            player =r.Next(0,2);

         // player = 0;
            int k = 0;
        }

        
        private void RunningBot()
        {
            if ((run == 1)&&(player == 0) )
            {
                Button b = new Button();

                b = WinOrBlock(nol);
                if(b == null)
                {
                    b = WinOrBlock(krest);
                    {
                        if (b == null)
                        {
                          b =  openspace();
                        }
                    }
                }
                
                b.PerformClick();
                run = 0;

            }
        }
        
        private void CompOrHum()
        {

            

          if ( checkBox1.Checked)
            {
                if (textBox1.Text == "3x3")
                h = 3;
                v = 3;

                int count = 0;

               

                for (int i = 0; i < h; i++)
                {
                    for (int j = 0; j < v; j++)
                    {
                        

                        Button but = new Button();
                        but.Name = "button" + count;
                        but.Text = "";
                        but.Size = new Size(100, 100);
                        but.Location = new Point(i * 100 + 10, j * 100 + 10);
                       
                        but.Click += createButtonClick;
                        this.Controls.Add(but);


                        a[count] = but;
                        count++;
                    }
                }
            }
          if ( checkBox2.Checked) 
            { 
                if (textBox1.Text == "3x3")
            h = 3;
            v = 3;

            int count = 0;



            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < v; j++)
                {


                    Button but = new Button();
                    but.Name = "button" + count;
                    but.Text = "";
                    but.Size = new Size(100, 100);
                    but.Location = new Point(i * 100 + 10, j * 100 + 10);
                    but.Click += ButtonClickVsAI;
                    this.Controls.Add(but);
                       
                           a[count] = but;
                      
                        count++;
                }
            }
        }


    }

       
    
        
        private void Check()
        {
            int Res = 0;

            

            if (
                (a[0].Text == a[1].Text && a[1].Text == a[2].Text) && (a[0].Text != "") && (a[1].Text != "") && (a[2].Text != "")  || 
                (a[3].Text == a[4].Text && a[4].Text == a[5].Text) && (a[3].Text != "") && (a[4].Text != "") && (a[5].Text != "")  ||
                (a[6].Text == a[7].Text && a[7].Text == a[8].Text) && (a[6].Text != "") && (a[7].Text != "") && (a[8].Text != "")  ||
                (a[0].Text == a[3].Text && a[3].Text == a[6].Text) && (a[0].Text != "") && (a[3].Text != "") && (a[6].Text != "") ||
                (a[1].Text == a[4].Text && a[4].Text == a[7].Text) && (a[1].Text != "") && (a[4].Text != "") && (a[7].Text != "") ||
                (a[2].Text == a[5].Text && a[5].Text == a[8].Text) && (a[2].Text != "") && (a[5].Text != "") && (a[8].Text != "") ||
                (a[0].Text == a[4].Text && a[4].Text == a[8].Text) && (a[0].Text != "") && (a[4].Text != "") && (a[8].Text != "") ||
                (a[2].Text == a[4].Text && a[4].Text == a[6].Text) && (a[2].Text != "") && (a[4].Text != "") && (a[6].Text != "") 
                )  
            {

                        Res = 1;

            }
           
            if (a[0].Enabled == false && a[1].Enabled == false && a[2].Enabled == false && a[3].Enabled == false && a[4].Enabled == false && a[5].Enabled == false &&
                a[6].Enabled == false && a[7].Enabled == false && a[8].Enabled == false)
            {
                Res = 2;
            }
           

            switch (Res)
            {

                case 3:
                    MessageBox.Show("Вы проиграли");

                    player = 3;
                   
                  break;
                case 1:
                    MessageBox.Show("Победил"+ " : "+label1.Text);
                    player = 3;
                    run = 0;

                    break;
                case 2:
                    MessageBox.Show("Ничья");
                    player = 3;
                    run = 0;

                    break;
            }

            
        }


   
        private void ButtonClickVsAI(object sender, EventArgs e)
        {
            Check();
            k++;
            switch (player)
            {
                case 1:
                    sender.GetType().GetProperty("Text").SetValue(sender, krest);
                    player = 0;
                    label1.Text = "Игрок 1";
                    run = 1;
                 
                        RunningBot();
                  
                    break;
                case 0:
                    
                    sender.GetType().GetProperty("Text").SetValue(sender, nol);
                    player = 1;
                    label1.Text = "Компьютер";
                    break;


            }



            label2.Text = "Ход:" + k;

            sender.GetType().GetProperty("Enabled").SetValue(sender, false);

           
        }


       private Button WinOrBlock(string mark)
        {


            //Vert

            if ((a[0].Text == "") && (a[1].Text == mark) && (a[2].Text == mark))
                return a[0];

            if ((a[0].Text == mark) && (a[1].Text == "") && (a[2].Text == mark))
                return a[1];

            if ((a[0].Text == mark) && (a[1].Text == mark) && (a[2].Text == ""))
            return a[2];

            if ((a[3].Text == "") && (a[4].Text == mark) && (a[5].Text == mark))
                return a[3];

            if ((a[3].Text == mark) && (a[4].Text == "") && (a[5].Text == mark))
                return a[4];

            if ((a[3].Text == mark) && (a[4].Text == mark) && (a[5].Text == ""))
                return a[5];

            if ((a[6].Text == "") && (a[7].Text == mark) && (a[8].Text == mark))
                return a[6];

            if ((a[6].Text == mark) && (a[7].Text == "") && (a[8].Text == mark))
                return a[7];

            if ((a[6].Text == mark) && (a[7].Text == mark) && (a[8].Text == ""))
                return a[8];

            //Horiz

            if ((a[0].Text == "") && (a[3].Text == mark) && (a[6].Text == mark))
                return a[0];

            if ((a[0].Text == mark) && (a[3].Text == "") && (a[6].Text == mark))
                return a[3];

            if ((a[0].Text == mark) && (a[3].Text == mark) && (a[6].Text == ""))
                return a[6];

            if ((a[1].Text == "") && (a[4].Text == mark) && (a[7].Text == mark))
                return a[1];

            if ((a[1].Text == mark) && (a[4].Text == "") && (a[7].Text == mark))
                return a[4];

            if ((a[1].Text == mark) && (a[4].Text == mark) && (a[7].Text == ""))
                return a[7];

            if ((a[2].Text == "") && (a[5].Text == mark) && (a[8].Text == mark))
                return a[2];

            if ((a[2].Text == mark) && (a[5].Text == "") && (a[8].Text == mark))
                return a[5];

            if ((a[2].Text == mark) && (a[5].Text == mark) && (a[8].Text == ""))
                return a[8];

            //Diagonal

            if ((a[0].Text == "") && (a[4].Text == mark) && (a[8].Text == mark))
                return a[0];

            if ((a[0].Text == mark) && (a[4].Text == "") && (a[8].Text == mark))
                return a[4];

            if ((a[0].Text == mark) && (a[4].Text == mark) && (a[8].Text == ""))
                return a[8];

            if ((a[2].Text == "") && (a[4].Text == mark) && (a[6].Text == mark))
                return a[2];

            if ((a[2].Text == mark) && (a[4].Text == "") && (a[6].Text == mark))
                return a[4];

            if ((a[2].Text == mark) && (a[4].Text == mark) && (a[6].Text == ""))
                return a[6];

            return null;
        }

        private Button openspace()
        {
            Button b = new Button();

            b = null;

            foreach(Control c in a)
            {
                b = c as Button;
                if(b != null)
                {
                   

                   if (b.Text == "")
                    { 
                        return b; 
                    }
                }
            }

            return null;
        }

        private void createButtonClick(object sender, EventArgs e) //логика для хода
        {
            k++;
            switch (player)
            {
                case 1:
                    sender.GetType().GetProperty("Text").SetValue(sender, krest);
                    player = 0;
                    label1.Text = "Игрок 1";
                    
                    break;
                case 0:
                    sender.GetType().GetProperty("Text").SetValue(sender, nol);
                    player = 1;
                    label1.Text = "Игрок 2";
                    
                    break;
                    
                    
            }



            label2.Text = "Ход:" + k;

            sender.GetType().GetProperty("Enabled").SetValue(sender, false);

            Check();
        }



        private void button1_Click(object sender, EventArgs e) //создание поля 
        {
            
            CompOrHum();


            if (player == 0)
            {
                run = 1;
                RunningBot();
            }
        }

       
    }
}
