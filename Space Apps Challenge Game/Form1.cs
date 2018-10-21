using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using Space_Apps_Challenge_Game.Properties;

namespace Space_Apps_Challenge_Game
{
    public partial class Form1 : Form
    {
        Question CurrentQuestion;
        GameLogic GL = new GameLogic(); 
        Bitmap bm;
        Graphics Graph;
        private Game game;
        public Form1()
        {
            InitializeComponent();
            GL.End += End;
            game = new Game(pictureBox1.Width, pictureBox1.Height,GL);
            bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graph = Graphics.FromImage(bm);
            game.NewFrame += DrawFrame;
            game.Question += ViewQuestion;
            game.Start();
        }

        private void End()
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    game.CV = -1;
                    break;
                case Keys.S:
                    game.CV = 1;
                    break;
                case Keys.A:
                    game.CH = -1;
                    break;
                case Keys.D:
                    game.CH = 1;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    game.CV = 0;
                    break;
                case Keys.S:
                    game.CV = 0;
                    break;
                case Keys.A:
                    game.CH = 0;
                    break;
                case Keys.D:
                    game.CH = 0;
                    break;
            }
        }
        
        private void ViewQuestion(int id)
        {
            Action a = () => {
                setQuestion(id);
            };
            Invoke(a);
        }

        private void setQuestion(int id)
        {
            Question q = GL.GetQuestion(id);
            CurrentQuestion = q;
            if (q != null)
            {
                button1.Text = "Answer";
                groupBox1.Text = q.location;
                label1.Text = q.question;
                radioButton1.Text = q.a1;
                radioButton2.Text = q.a2;
                radioButton3.Text = q.a3;
                radioButton4.Text = q.a4;
                switch (q.type)
                {
                    case QuestionType.SelectAnswer:
                        textBox1.Visible = false;
                        radioButton1.Visible = true;
                        radioButton2.Visible = true;
                        radioButton3.Visible = true;
                        radioButton4.Visible = true;
                        break;
                    case QuestionType.FullAnsver:
                        textBox1.Visible = true;
                        radioButton1.Visible = false;
                        radioButton2.Visible = false;
                        radioButton3.Visible = false;
                        radioButton4.Visible = false;
                        break;
                    case QuestionType.Fact:
                        textBox1.Visible = false;
                        radioButton1.Visible = false;
                        radioButton2.Visible = false;
                        radioButton3.Visible = false;
                        radioButton4.Visible = false;
                        break;
                }
            }
            else
            {
                textBox1.Visible = false;
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                radioButton4.Visible = false;
                button1.Text = "OK";
                if (id <= 10)
                {
                    label1.Text = "This planet has been already explored!";
                    groupBox1.Text = "Mission completed!";
                }
                else
                {
                    label1.Text = "You lost 10 points.";
                    groupBox1.Text = "Your space ship has crashed!";
                }
            }
            switch(id)
            {
                case 1:
                    pictureBox2.Image = Resources.Mercury_Hubble;
                    break;
                case 2:
                    pictureBox2.Image = Resources.Venus_Hubble;
                    break;
                case 3:
                    pictureBox2.Image = Resources.Earth_Hubble;
                    break;
                case 4:
                    pictureBox2.Image = Resources.Mars_Hubble;
                    break;
                case 5:
                    pictureBox2.Image = Resources.Jupieter_Hubble;
                    break;
                case 6:
                    pictureBox2.Image = Resources.Saturn_Hubble;
                    break;
                case 7:
                    pictureBox2.Image = Resources.Uranus_Hubble;
                    break;
                case 8:
                    pictureBox2.Image = Resources.Neptune_Hubble;
                    break;
                case 9:
                    pictureBox2.Image = Resources.Pluto_Hubble;
                    break;
                case 10:
                    pictureBox2.Image = Resources.Asteroid_Hubble;
                    break;
                default:
                    pictureBox2.Image = Resources.Crashed;
                    break;
            }
            pictureBox2.Visible = true;
            groupBox1.Visible = true;
        }

        private void DrawFrame(Bitmap b)
        {
            Action a = () =>{
                Graph.DrawImage(b, 0, 0);
                pictureBox1.Image = bm;
            };
            Invoke(a);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string answer = "";
            if (CurrentQuestion != null)
            if (CurrentQuestion.type == QuestionType.SelectAnswer)
            {
                if (radioButton1.Checked)
                    answer = "1";
                if (radioButton2.Checked)
                    answer = "2";
                if (radioButton3.Checked)
                    answer = "3";
                if (radioButton4.Checked)
                    answer = "4";
            }
            else
            {
                answer = textBox1.Text;
            }
            GL.SetAnswer(CurrentQuestion, answer);
            groupBox1.Visible = false;
            game.Return();
            this.Focus();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            GL.Save();
            game.Stop();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = true;
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = true;
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = true;
            radioButton4.Checked = false;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = true;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
        }
    }
}
