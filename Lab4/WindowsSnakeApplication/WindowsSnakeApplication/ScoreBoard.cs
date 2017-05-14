using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class ScoreBoard
    {
        private static string l1;
        private static string l2;
        private static string l3;

        public ScoreBoard()
        {
            setScoreBoardTime();
            setScoreBoardScore();
            setScoreBoardLevel();
        }

        private void setScoreBoardTime()
        {
            int tick = Form1.tick / 100;
            l1 = tick.ToString();
        }

        private void setScoreBoardScore()
        {
            l2 = Form1.score.ToString();
        }

        private void setScoreBoardLevel()
        {
            l3 = Form1.level.ToString();
        }

        public string getScoreBoardTime()
        {
            setScoreBoardTime();
            return l1;
        }
        public string getScoreBoardScore()
        {
            setScoreBoardScore();
            return l2;
        }
        public string getScoreBoardLevel()
        {
            setScoreBoardLevel();
            return l3;
        }

    }
}
