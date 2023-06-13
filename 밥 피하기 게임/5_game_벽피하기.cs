using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 진지밥_권여진김수지;

namespace BOB_진지밥_권여진김수지
{
    public partial class _5_game_벽피하기 : Form
    {
        private Player currentPlayer;

        int pipeSpeed = 15;
        int gravity = 15;
        int score = 0;

        bool space;
        bool startgame2 = false; // 키 누른거 확인용
        bool scorecheck = false; // 점수 체크



        private void _5_game_벽피하기_Load(object sender, EventArgs e)
        {
            gameTimer.Enabled = true;
        }

        public _5_game_벽피하기(Player player)
        {
            InitializeComponent();
            currentPlayer = player;
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            if(space == true)
                startgame2 = true;

            if (startgame2 == true)
            {

                BoB.Top += gravity;
                pipeBottom.Left -= pipeSpeed;
                pipeTop.Left -= pipeSpeed;
                scoreText.Text = "점수: " + score;

                if (pipeBottom.Left < -150)
                {
                    pipeBottom.Left = 800;
                    score++;
                }
                if (pipeTop.Left < -180)
                {
                    pipeTop.Left = 950;
                    score++;
                }

                if (BoB.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                    BoB.Bounds.IntersectsWith(pipeTop.Bounds) ||
                    BoB.Bounds.IntersectsWith(ground.Bounds) || BoB.Top < -25)
                {
                    if (score >= 5)  // 5점 이하면 다시하기
                    {
                        gameTimer.Enabled = false;

                        currentPlayer.game2 = score;

 
                        _6_스토리 form = FormOpen.OpenForm<_6_스토리>(this, currentPlayer);
                    }
                    else
                    {
                        gameTimer.Enabled = false;

                        _5_게임오버 form = FormOpen.OpenForm<_5_게임오버>(this, currentPlayer);
                    }
                }

                //일정점수 증가마다 속도 증가
                if (0 == (score % 5) && !scorecheck)
                {
                    pipeSpeed += 6;
                    scorecheck = true;
                }
                if (score % 5 != 0)
                    scorecheck = false; 
            }       
        }


        // 키 이벤트
        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                space = true;
                gravity = -15;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                space = false;
                gravity = 15;
            }
        }
    }
}


