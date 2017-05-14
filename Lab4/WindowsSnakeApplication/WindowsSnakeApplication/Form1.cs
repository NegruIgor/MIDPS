using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form 
    {
        private Brush brush = new Brush();
        private PenClass p = new PenClass();
        private Random rand = new Random();
        ScoreBoard sB = new ScoreBoard();
        private static Form form;

        public List<Rectangle> listRec = new List<Rectangle>();
        public List<Rectangle> listMove = new List<Rectangle>();
        public List<Rectangle> listWarmLength = new List<Rectangle>();
        
        public Rectangle rect = new Rectangle();
        public Rectangle rectLength = new Rectangle(0, 0, 10, 10);
        public Rectangle randFood = new Rectangle(0, 0, 10, 10);
        
        
        char move;
        bool switchCase;
        public static int tick = 0;
        public static int CountOfClicks = 0, rX, rY, pxX = 0, pxY = 0, WramLength = 0, score = 0, level = 0;


        private void nullAll()
        { 
            CountOfClicks = 0;
            rX = 0;
            rY = 0;
            pxX = 0;
            pxY = 0;
            WramLength = 0;
            score = 0;
            tick = 0;
            level = 0;
            move = '0';
            listRec.Clear();
            listMove.Clear();
            listWarmLength.Clear();
        }
        private int randPoionTableX, randPoionTableY;
        
        private void SwitchMove(char m)
        {
            switch (m)
            {

                case 'u':
                    {
                        rY -= 1;
                        pxY++;
                        if (pxY == 10)
                            pxY = 0;
                        rect.X = rX;
                        rect.Y = rY;
                        listMove.Add(rect);
                        this.pictureBox1.Invalidate();
                        break;
                    }
                case 'd':
                    {
                        rY += 1;
                        pxY++;
                        if (pxY == 10)
                            pxY = 0;
                        rect.X = rX;
                        rect.Y = rY;
                        listMove.Add(rect);
                        this.pictureBox1.Invalidate();
                        break;
                    }
                case 'l':
                    {
                        rX -= 1;
                        pxX++;
                        if (pxX == 10)
                            pxX = 0;
                        rect.X = rX;
                        rect.Y = rY;
                        listMove.Add(rect);
                        this.pictureBox1.Invalidate();
                        break;
                    }
                case 'r':
                    {
                        rX += 1;
                        pxX++;
                        if (pxX == 10)
                            pxX = 0;
                        rect.X = rX;
                        rect.Y = rY;
                        listMove.Add(rect);
                        this.pictureBox1.Invalidate();

                        break;
                    }

            }
        }
        private void FOOD()
        {
            if ((rect.X) == randPoionTableX && (rect.Y) == randPoionTableY)
            {
                rectLength.X = randPoionTableX;
                rectLength.Y = randPoionTableY;

                randPoionTableX = rand.Next(6, 100) * randFood.Width;
                randPoionTableY = rand.Next(6, 55) * randFood.Height;
                WramLength++;
                for (int i = 1; i < 10; i++)
                {
                    listWarmLength.Add(rectLength);
                }
                score += 10;
                label5.Text = sB.getScoreBoardScore();
                this.pictureBox1.Invalidate();

            }
        }
        private void MoveTail(char m)
        {
        switch (m)
                {
                    case 'u':
                        {
                            if (switchCase == true)
                            {
                                rectLength.Y = rect.Y;
                                rectLength.X = rect.X;
                                switchCase = false;
                            }
                            
                            rectLength.Y--;
                            break;
                        }
                    case 'd':
                        {
                            if (switchCase == true)
                            {
                                rectLength.Y = rect.Y;
                                rectLength.X = rect.X;
                                switchCase = false;
                            }
                            rectLength.Y++;
                            break;
                        }
                    case 'l':
                        {
                            if (switchCase == true)
                            {
                                rectLength.Y = rect.Y;
                                rectLength.X = rect.X;
                                switchCase = false;
                            }
                            rectLength.X--;
                            break;
                        }
                    case 'r':
                        {
                            if (switchCase == true)
                            {
                                rectLength.Y = rect.Y;
                                rectLength.X = rect.X;
                                switchCase = false;
                            }
                            rectLength.X++;
                            break;
                        }
                }
        }
        private void CorrectDirection()
        {
            if (pxX <= 5)
            {
                if (move == 'l')
                {
                    rX += pxX;
                }
                else if (move == 'r')
                    rX -= pxX;
            }
            else if (pxX > 5)
            {
                if (move == 'l')
                {
                    rX += (pxX - 10);
                }
                else if (move == 'r')
                    rX += (10 - pxX);
            }

            if (pxY <= 5)
            {
                if (move == 'u')
                {
                    rY += pxY;
                }
                else if (move == 'd')
                    rY -= pxY;
            }
            else if (pxY > 5)
            {
                if (move == 'u')
                {
                    rY += (pxY - 10);
                }
                else if (move == 'd')
                    rY += (10 - pxY);
            }

            pxY = 0;
            pxX = 0;
        }
       
        private void ESCPause(KeyEventArgs e)
        {
            form = new Pause();
            if (e.KeyCode == Keys.Escape)
            {
                timer1.Stop();
                form.Show();
            }
            
        }
        private void DrawMap(PaintEventArgs e)
        {
            foreach (Rectangle rec in listRec)
            {
                e.Graphics.DrawRectangle(p.setPenColor(Color.Red), rec);
                e.Graphics.FillRectangle(brush.fillWithMyColor(Color.Black), rec);
            }
        }
        private void DrawWarmTail(PaintEventArgs e)
        {
            foreach (Rectangle rec in listWarmLength)
            {
                e.Graphics.DrawRectangle(p.setPenColor(Color.LightCoral), rec);
                e.Graphics.FillRectangle(brush.fillWithMyColor(Color.DarkSalmon), rec);
            }
        }
        private void DrawWarmHead(PaintEventArgs e)
        {
            foreach (Rectangle rec in listWarmLength)
            {      
                e.Graphics.DrawRectangle(p.setPenColor(Color.LightCoral), rec);
                e.Graphics.FillRectangle(brush.fillWithMyColor(Color.DarkSalmon), rec);
            }
        }
        public void NewGame()
        {

            bool margin;
            rect.Size = new Size(10, 10);
            for (int x = 5; x <= 100; x++)
            {
                rect.X = x * rect.Width;
                for (int y = 5; y <= 55; y++)
                {
                    margin = (x == 5 || y == 5 || x == 100 || y == 55);
                    rect.Y = y * rect.Height;
                    if (margin)
                        this.listRec.Add(rect);

                }
            }

        }
        public void OnCreate(PaintEventArgs e)
        {
            

            rX = rand.Next(5, 100) * rect.Width;
            rY = rand.Next(5, 55) * rect.Height;
            rect.X = rX;
            rect.Y = rY;
            listMove.Add(rect);
            e.Graphics.DrawRectangle(p.setPenColor(Color.Red), rect);
            e.Graphics.FillRectangle(brush.fillWithMyColor(Color.DarkSalmon), rect);
            randPoionTableX = rand.Next(6, 100) * randFood.Width;
            randPoionTableY = rand.Next(6, 55) * randFood.Height;
        }
        private void OnKeyMessageBox()
        {
            if ((rX / rect.Width) == 5 || (rY / rect.Height) == 5 || (rX / rect.Width) == 100 || (rY / rect.Height) == 55)
            {
                timer1.Stop();
                if (MessageBox.Show("GAME OVER \n Continue?", "Stats", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    nullAll();
                    CountOfClicks = 1;
                    NewGame();
                    this.pictureBox1.Invalidate();
                }
                else
                {
                    this.Dispose(); this.Close();
                }

            }
        }

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            CorrectDirection();

            switch (e.KeyCode)
            {
                    
                case Keys.Down:
                    {
                        if (move == 'u')
                        { 
                            break;
                        }
                        move = 'd';
                        break;
                    }
                case Keys.Up:
                    {
                        if (move == 'd')
                        {
                            break;
                        }
                        move = 'u';
                        break;
                    }
                case Keys.Left:
                    {
                        if (move == 'r')
                        {
                            break;
                        }
                        move = 'l';
                        break;
                    }
                case Keys.Right:
                    {
                        if (move == 'l')
                        {
                            break;
                        }
                        move = 'r';
                        break;
                    }
                    
            }
            switchCase = true;
            timer1.Start();
            ESCPause(e);
        }
        
        
        
        public void timer1_Tick(object sender, EventArgs e)
        {
            tick++;
            if (tick % 10 == 0)
            {
                label4.Text = sB.getScoreBoardTime();
            }
           SwitchMove(move);
            FOOD();
            MoveTail(move);

            if (WramLength >= 1)
            listWarmLength.Add(rectLength);
            this.pictureBox1.Invalidate();

            if (listWarmLength.Count() > WramLength + 1)
            {
                listWarmLength.RemoveAt(0);
                listMove.RemoveAt(0);
            }
                
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            CountOfClicks = 1;
            listWarmLength.Clear();
            listRec.Clear();
            NewGame();
            this.pictureBox1.Invalidate();
        }

        

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            DrawMap(e);
            DrawWarmTail(e);
            DrawWarmHead(e);
            
            if (CountOfClicks == 1)
            {
                
               OnCreate(e);
            }
            CountOfClicks++;
       
         if (move == 'd' || move == 'u' || move == 'r' || move == 'l')
            {
                randFood.X = randPoionTableX;
                randFood.Y = randPoionTableY;
                e.Graphics.DrawRectangle(p.setPenColor(Color.LightCoral), randFood);
                e.Graphics.FillRectangle(brush.fillWithMyColor(Color.Green), randFood);

                e.Graphics.DrawRectangle(p.setPenColor(Color.LightCoral), rect);
                e.Graphics.FillRectangle(brush.fillWithMyColor(Color.DarkSalmon), rect);
                OnKeyMessageBox();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 10;
            timer1.Tick += timer1_Tick;
            label6.Text = sB.getScoreBoardLevel();      
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            form = new Form2();
            form.Close();
            form.Dispose();
            this.Dispose();
        }

        private void theme1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("../Images/Terrain/6801535-lovely-ground-wallpaper.jpg");

        }

        private void theme2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("../Images/Terrain/6806344-pretty-ground-wallpaper.jpg");
        }

        private void theme3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("../Images/Terrain/6829991-ground-wallpaper.jpg");
        }

        private void noThemeFASTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.BackColor = SystemColors.Control;
            pictureBox1.Image = null;
        }

        


       

       


       
        
    }
}
