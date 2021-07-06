using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deer_racing_pro
{
    public partial class Form1 : Form
    {
        //giving predifined bet values to user

        int schin = 50;
        int gur = 50;
        int jhon = 50;
        functionlLogic logic = new functionlLogic();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // add the nme of ddeer
            selectDeer.Items.Add("1");
            selectDeer.Items.Add("2");
            selectDeer.Items.Add("3");
            selectDeer.Items.Add("4");
            
            //generate the amount 
            int y = 1;
            do
            {
                selectAmount.Items.Add(y.ToString());
                y++;
            } while (y <= 50);

            //add the name of players
            selectPlayer.Items.Add("Sachin");
            selectPlayer.Items.Add("Gurnaib");
            selectPlayer.Items.Add("Jhones");


        }

        private void lock_bet_Click(object sender, EventArgs e)
        {
            int ply = selectPlayer.SelectedIndex;
            int deer = selectDeer.SelectedIndex;
            int amt = selectAmount.SelectedIndex;

            // conditional statement ablout sleckinf de hog

            if (ply>-1 && deer >-1 && amt>-1) {
                switch (ply)
                {
                    case 0:
                        if (amt <= schin && schin > 0)
                        {
                            sachin_message.Text = "Sachin Select " + selectDeer.Items[deer].ToString() + " with the amount of " + selectAmount.Items[amt].ToString();
                            race_btn.Visible = true;
                        }
                        else {
                            MessageBox.Show("Need to check the Balance");

                        }
                        break;
                    case 1:
                        if (amt <= gur && gur>0) {
                            gurnaib_bet.Text = "Gurnaib select " + selectDeer.Items[deer].ToString() + " with the amount of " + selectAmount.Items[amt].ToString();
                            race_btn.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("Need to check the Balance");

                        }
                        break;
                    case 2:
                        if (amt <= jhon && jhon>0)
                        {
                            Jhones_message.Text = "Jhones select " + selectDeer.Items[deer].ToString() + " with the amount of " + selectAmount.Items[amt].ToString();
                            race_btn.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("Need to check the Balance");

                        }
                        break;

                }


            }
            else
            {
                MessageBox.Show("You need to follow the details ");

            }
        }

        private void race_btn_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        // timer function 

        private void timer1_Tick(object sender, EventArgs e)
        {
            deer1.Left += logic.moveDeer();
            deer2.Left += logic.moveDeer();
            deer3.Left += logic.moveDeer();
            deer4.Left += logic.moveDeer();
            if (deer1.Left > logic.stpTimer()) {
                timer1.Stop();
                MessageBox.Show("Deer 1 won the race");
                finlResult(1);
            }
            if (deer2.Left > logic.stpTimer())
            {
                timer1.Stop();
                MessageBox.Show("Deer 2 won the race");
                finlResult(2);
            }

            if (deer3.Left > logic.stpTimer())
            {
                timer1.Stop();
                MessageBox.Show("Deer 3 won the race");
                finlResult(3);
            }

            if (deer4.Left > logic.stpTimer())
            {
                timer1.Stop();
                MessageBox.Show("Deer 4 won the race");
                finlResult(4);
            }
        }

        //showing reult

        public void finlResult(int win) {
            if (sachin_message.Text.Contains("of")) {
                String[] recrd = sachin_message.Text.Split(' ');
                if (Convert.ToInt32(recrd[2]) == win)
                {
                    schin = schin + Convert.ToInt32(recrd[7]);
                }
                else {
                    schin = schin - Convert.ToInt32(recrd[7]);
                }
                sachin_message.Text = "Sachin has $" +schin + " amount for the Bet ";
            }

            if (gurnaib_bet.Text.Contains("of"))
            {
                String[] recrd = gurnaib_bet.Text.Split(' ');
                if (Convert.ToInt32(recrd[2]) == win)
                {
                    gur = gur + Convert.ToInt32(recrd[7]);
                }
                else
                {
                    gur = gur - Convert.ToInt32(recrd[7]);
                }
                gurnaib_bet.Text = "Gurnaib has $" + gur + " amount for the Bet ";
            }


            // next plater is selection

            if (Jhones_message.Text.Contains("of"))
            {
                String[] recrd = Jhones_message.Text.Split(' ');
                if (Convert.ToInt32(recrd[2]) == win)
                {
                    jhon = jhon + Convert.ToInt32(recrd[7]);
                }
                else
                {
                    jhon = jhon - Convert.ToInt32(recrd[7]);
                }
                Jhones_message.Text = "Jhones has $" + jhon + " amount for the Bet ";
            }

            deer1.Left = 0; deer2.Left = 0; deer3.Left = 0; deer4.Left = 0;
            race_btn.Visible = false;
            
            selectAmount.SelectedIndex=-1;
            selectDeer.SelectedIndex = -1;
            selectPlayer.SelectedIndex = -1;

        }



    }
}
