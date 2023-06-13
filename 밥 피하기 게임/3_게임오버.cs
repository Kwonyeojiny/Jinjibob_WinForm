using BOB_진지밥_권여진김수지;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 진지밥_권여진김수지
{
    public partial class _3_게임오버 : Form
    {
        private Player currentPlayer;
        public _3_게임오버(Player player)
        {
            InitializeComponent();
            currentPlayer = player;
        }

        private void 다시하기_Click(object sender, EventArgs e)
        {
            _3_game_동생모으기 form = FormOpen.OpenForm<_3_game_동생모으기>(this, currentPlayer);
        }

        private void button1_Click(object sender, EventArgs e) // 게임 설명
        {
            _3_게임설명 explain = FormOpen.MidOpenForm<_3_게임설명>(this);
        }

        private void _3_게임오버_Load(object sender, EventArgs e)
        {

        }
    }
}
