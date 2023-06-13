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
    public partial class _2_시작오프닝 : Form
    {
        private Player currentPlayer;

        int speed = 12;
        bool talkk = true;
        KeyboardInput keyboardInput = new KeyboardInput();

        public _2_시작오프닝(Player player)
        {
            InitializeComponent();
            currentPlayer = player;

            this.KeyDown += KeyIsDown;
            this.KeyUp += KeyIsUp;
        }

        private void _2_시작오프닝_Load(object sender, EventArgs e)
        {
            Storytimer.Enabled = true;
        }

        private void StoryGameTimer_2(object sender, EventArgs e)
        {
            if (keyboardInput.GoLeft == true || keyboardInput.GoRight == true || keyboardInput.GoUp == true || keyboardInput.GoDown == true)
                talkk = false;

            if (talkk == false)
                talk.Visible = false;

            // 방향키 코드
            if (keyboardInput.GoLeft == true)
            {
                int moveX = player.Location.X - speed;

                if (moveX < 0)
                    moveX = 0;
                else
                    player.Left -= speed;
            }
            if (keyboardInput.GoRight == true)
            {
                int moveX = player.Location.X + speed;
                if (moveX > this.ClientSize.Width - player.Width)
                    moveX = this.ClientSize.Width - player.Width;
                else
                    player.Left += speed;
            }
            if (keyboardInput.GoUp == true)
            {
                int moveY = player.Location.Y - speed;

                if (moveY < 300)
                    moveY = 300;
                else
                    player.Top -= speed;
            }
            if (keyboardInput.GoDown == true)
            {
                int moveY = player.Location.Y + speed;
                if (moveY > this.ClientSize.Height - player.Height)
                    moveY = this.ClientSize.Height - player.Height;
                else
                    player.Top += speed;
            }

            if (player.Bounds.IntersectsWith(door.Bounds)) // 문에 캐릭터가 닿으면 다음 폼 
            {
                Storytimer.Enabled = false;

                _3_game_동생모으기 form = FormOpen.OpenForm<_3_game_동생모으기>(this, currentPlayer);

                _3_게임설명 explain = FormOpen.MidOpenForm<_3_게임설명>(this);
                
            }
        }

        // 키 이벤트
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            keyboardInput.KeyIsDown(e);
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            keyboardInput.KeyIsUp(e);
        }
    }
}
