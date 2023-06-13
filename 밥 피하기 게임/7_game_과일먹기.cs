using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 진지밥_권여진김수지;

namespace BOB_진지밥_권여진김수지
{
    public partial class _7_game_과일먹기 : Form
    {
        private Player currentPlayer;

        bool goLeft, goRight;
        int speed = 10;
        int fruitspeed = 11;
        int dorianspeed = 13;
        int score = 0;
        int dorian = 0; // 두리안 먹은 갯수 (3개 먹으면 게임오버)
        bool startgame3 = false; // 키 누른거 확인용
        bool scorecheck = false;

        Random XX = new Random(); // 과일 x좌표 랜덤
        Random YY = new Random(); // - 쪽에서 랜덤 생성
        Random random = new Random();
        
        PictureBox fruit = new PictureBox(); // 과일 생성

        public _7_game_과일먹기(Player player)
        {
            InitializeComponent();
            currentPlayer = player;
        }

        private void _7_game_과일먹기_Load(object sender, EventArgs e)
        {
            gameTimer.Enabled = true;
        }

        private void FruitGameTimer(object sender, EventArgs e)
        {
            txtScore.Text = "모인과일: " + score ;

            if(goLeft == true || goRight == true)
                startgame3 = true;

            if(startgame3 == true)  
            {
                // 캐릭터 이동 코드
                if (goLeft == true)
                {
                    int moveX = player.Location.X - speed;

                    if (moveX < 0)
                        moveX = 0;
                    else
                        player.Left -= speed;
                }
                if (goRight == true)
                {
                    int moveX = player.Location.X + speed;
                    if (moveX > this.ClientSize.Width - player.Width)
                        moveX = this.ClientSize.Width - player.Width;
                    else
                        player.Left += speed;
                }

                fruitspeed = random.Next(9, 16);
                dorianspeed = random.Next(9, 20);
                // 과일 떨어지고 점수먹는 코드
                foreach (Control X in this.Controls)
                {
                    // 과일 떨어지는 코드
                    if ((string)X.Tag == "fruits")
                    {
                        if (player.Bounds.IntersectsWith(X.Bounds) && X.Visible == true)
                        {
                            X.Visible = false;
                            score++;
                        }

                        X.Top += fruitspeed;

                        if (X.Top + X.Height > this.ClientSize.Height)  // 위로 올려보낸 다음 보이게 하기
                        {
                            fruit.Location = X.Location;
                            X.Top = YY.Next(60, 300) * -1;
                            X.Left = XX.Next(5, this.ClientSize.Width - X.Width);
                            X.Visible = true;
                        }
                    }

                    // 두리안 떨어지는 코드
                    if ((string)X.Tag == "doriann")
                    {
                        if (player.Bounds.IntersectsWith(X.Bounds) && X.Visible == true) // 두리안 닿이면 하트 깎임
                        {
                            X.Visible = false;
                            dorian++;

                            // 하트 까기
                            if (dorian == 1)
                            {
                                heart3.Visible = false;
                            }
                            else if (dorian == 2)
                            {
                                heart2.Visible = false;
                            }
                            else
                                heart1.Visible = false;

                            if (dorian >= 3) // 목숨 다까이면 게임오버
                            {
                                if (score >= 5)
                                {
                                    gameTimer.Enabled = false;
                                    currentPlayer.game3 = score;

                                    _8_엔딩 form = FormOpen.OpenForm<_8_엔딩>(this, currentPlayer);
                                }
                                else
                                {
                                    gameTimer.Enabled = false;
                                    _7_게임오버 form = FormOpen.OpenForm<_7_게임오버>(this, currentPlayer);
                                }
                            }
                        }

                        X.Top += dorianspeed;

                        if (X.Top + X.Height > this.ClientSize.Height)  // 위로 올려보낸 다음 보이게 하기
                        {
                            fruit.Location = X.Location;
                            X.Top = YY.Next(50, 300) * -1;
                            X.Left = XX.Next(5, this.ClientSize.Width - X.Width);
                            X.Visible = true;
                        }
                    }
                }

                //일정점수 증가마다 속도 증가
                if (0 == (score % 12) && !scorecheck)
                {
                    fruitspeed += 3;
                    dorianspeed += 5;
                    scorecheck = true;
                }
                if(score % 12 != 0)
                {
                    scorecheck = false;
                }
            }
            
        }

        // 키 이벤트
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
        }

       
    }
}
