using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 진지밥_권여진김수지;

namespace BOB_진지밥_권여진김수지
{
    public partial class _8_엔딩 : Form
    {
        private Player currentPlayer;

        public _8_엔딩(Player player)
        {
            InitializeComponent();
            currentPlayer = player;

            score.Text = string.Format("플레이어 : {0}", currentPlayer.Name);
            label1.Text = string.Format("밥알 모으기 : {0:00}분 {1:00}초",
                currentPlayer.game1.Minutes, currentPlayer.game1.Seconds.ToString());
            label3.Text = string.Format("선인장 피하기 : {0}점", currentPlayer.game2);
            label4.Text = string.Format("과일 모으기 : {0}점", currentPlayer.game3);
        }

        private void _8_엔딩_Load(object sender, EventArgs e)
        {

        }

        private void 처음_Click(object sender, EventArgs e) // 홈화면으로 돌아감
        {
            _1_시작화면 form = FormOpen.OpenForm<_1_시작화면>(this);
        }
    }
}
