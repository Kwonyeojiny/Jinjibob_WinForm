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
    public partial class _3_game_동생모으기 : Form
    {
        private Player currentPlayer;

        bool goLeft, goRight, jumping;
        bool startgame1 = false; // 키 누른거 확인용

        int jumpSpeed;
        int force;
        int score = 0;
        int playerSpeed = 7;

        int horizontalSpeed = 5;
        int verticalSpeed = 3;

        int enemyOneSpeed = 5;
        int enemyTwoSpeed = 3;

        public _3_game_동생모으기(Player player)
        {
            InitializeComponent();
            currentPlayer = player;

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);

            clearTimer = new Stopwatch();
            displayTimer = new Timer();
        }

        private Stopwatch clearTimer; // 클리어 시간 측정
        private Timer displayTimer; // 클리어 시간 표시

        private void _3_game_동생모으기_Load(object sender, EventArgs e)
        {
            gameTimer.Enabled = true;
        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = "모인쌀알: " + score + "/ 27"; // 점수판

            if (goLeft == true || goRight == true || jumping == true)
                startgame1 = true;

            if(startgame1 == true)
            {
                clearTimer.Start(); // 키 눌렀을 때 타이머 시작
                displayTimer.Start();

                displayTimer.Interval = 10; // 0.01초마다 업데이트
                displayTimer.Tick += DisplayTimer_Tick;

                if (clearTimer == null)
                {
                    clearTimer = new Stopwatch(); // 클리어 시간을 측정하기 위해 Stopwatch 초기화
                    clearTimer.Start(); // 클리어 시간 측정 시작
                }


                    // 캐릭터 컨트롤 코드
                player.Top += jumpSpeed;

                if (goLeft == true)
                    player.Left -= playerSpeed;

                if (goRight == true)
                    player.Left += playerSpeed;

                if (jumping == true && force < 0)
                    jumping = false;

                if (jumping == true)
                {
                    jumpSpeed = -8;
                    force -= 1;
                }
                else
                    jumpSpeed = 10;

                

                // 쌀알 및 장애물 등등 코드
                foreach (Control x in this.Controls)
                {
                    if ((string)x.Tag == "platform")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            force = 8;
                            player.Top = x.Top - player.Height;

                            if ((string)x.Name == "horizontalPlatform" && goLeft == false || (string)x.Name == "horizontalPlatform" && goRight == false)
                            {
                                player.Left -= horizontalSpeed;
                            }
                        }

                        x.BringToFront();
                    }
                    if ((string)x.Tag == "rice")
                    {
                        //x.Visible = true로 안해놓으면 코인 점수 시간마다 증가함
                        if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            x.Visible = false;
                            score++;
                        }
                    }

                    if ((string)x.Tag == "enemy") // 적에 닿았을 때
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameTimer.Enabled = false;
                            _3_게임오버 form = FormOpen.OpenForm<_3_게임오버>(this, currentPlayer);
                        }
                    }
                }

                // 움직이는 벽돌
                horizontalPlatform.Left -= horizontalSpeed;

                if (horizontalPlatform.Left < 0 || horizontalPlatform.Left + horizontalPlatform.Width > this.ClientSize.Width)
                    horizontalSpeed = -horizontalSpeed;

                verticalPlatform.Top += verticalSpeed;

                if (verticalPlatform.Top < 160 || verticalPlatform.Top > 500)
                    verticalSpeed = -verticalSpeed;

                enemyOne.Left -= enemyOneSpeed;

                if (enemyOne.Left < pictureBox5.Left || enemyOne.Left + enemyOne.Width > pictureBox5.Left + pictureBox5.Width)
                    enemyOneSpeed = -enemyOneSpeed;

                enemyTwo.Left += enemyTwoSpeed;

                if (enemyTwo.Left < pictureBox2.Left || enemyTwo.Left + enemyTwo.Width > pictureBox2.Left + pictureBox2.Width)
                    enemyTwoSpeed = -enemyTwoSpeed;


                //땅이 아닌 곳에 떨어졌을 때
                if (player.Top + player.Height > this.ClientSize.Height + 50)
                {
                    gameTimer.Enabled = false;
                    _3_게임오버 form = FormOpen.OpenForm<_3_게임오버>(this, currentPlayer);
                }

                if (player.Bounds.IntersectsWith(door.Bounds) && score == 27) // 쌀알 다먹고 문에 닿았을 때
                {
                    gameTimer.Enabled = false;
                    clearTimer.Stop();
                    TimeSpan clearTime = clearTimer.Elapsed;

                    currentPlayer.game1 = clearTime;

                    _4_스토리 form = FormOpen.OpenForm<_4_스토리>(this, currentPlayer);
                }
            }
        }

        private void DisplayTimer_Tick(object sender, EventArgs e) // 타이머
        {
            TimeSpan clearTime = clearTimer.Elapsed;
            labelClearTime.Text = string.Format("시간 - {0:00}:{1:00}.{2:00}",
            clearTime.Minutes, clearTime.Seconds, clearTime.Milliseconds / 10);
        }

        // 키 이벤트
        private void KeyIsDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Left)
                goLeft = true;

            if (e.KeyCode == Keys.Right)
                goRight = true;

            if (e.KeyCode == Keys.Space && jumping == false)
                jumping = true;

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        { 
            if (e.KeyCode == Keys.Left)
                goLeft = false;

            if (e.KeyCode == Keys.Right)
                goRight = false;

            if (jumping == true)
                jumping = false;
        }
    }
}
