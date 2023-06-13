using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using 진지밥_권여진김수지;

namespace BOB_진지밥_권여진김수지
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new _1_시작화면()); // start form
            //Application.Run(new _2_시작오프닝());
            //Application.Run(new _3_game_동생모으기());
            //Application.Run(new _3_게임오버());
            //Application.Run(new _4_스토리());
            //Application.Run(new _5_game_벽피하기());
            //Application.Run(new _5_게임오버());
            //Application.Run(new _6_스토리());
            //Application.Run(new _7_game_과일먹기());
            //Application.Run(new _7_게임오버());
            //Application.Run(new _8_엔딩());
            //Application.Run(new 랭킹());
        }
    }

    public class Player // 플레이어 게임 기록
    {
        public string Name { get; set; } // 사용자 이름
        public TimeSpan game1 { get; set; } // 쌀알먹기 기록
        public int game2 { get; set; } // 벽피하기 기록
        public int game3 { get; set;} // 과일모으기 기록
    }

    public static class FormOpen // 폼 오픈
    {
        public static T OpenForm<T>(Form parentForm) where T : Form, new() // 그냥 오픈
        {
            parentForm.Hide();
            T formopen = new T();
            formopen.StartPosition = FormStartPosition.Manual;
            formopen.Location = parentForm.Location;
            formopen.Show(parentForm);
            return formopen;
        }
        public static T OpenForm<T>(Form parentForm, Player player) where T : Form
        {
            parentForm.Hide();
            T formopen = (T)Activator.CreateInstance(typeof(T), player);
            formopen.StartPosition = FormStartPosition.Manual;
            formopen.Location = parentForm.Location;
            formopen.Show(parentForm);
            return formopen;
        }

        public static T MidOpenForm<T>(Form parentForm) where T : Form, new() // diaglog 중간 오픈
        {
            T formopen = new T();
            formopen.StartPosition = FormStartPosition.Manual;
            int x = parentForm.Location.X + (parentForm.Width - formopen.Width) / 2;
            int y = parentForm.Location.Y + (parentForm.Height - formopen.Height) / 2;
            formopen.Location = new Point(x, y);
            formopen.ShowDialog(parentForm);
            return formopen;
        }
    }

    public class KeyboardInput // 키 이벤트
    {
        private bool goLeft, goRight, goUp, goDown;
        public bool GoLeft { get { return goLeft; } }
        public bool GoRight { get { return goRight; } }
        public bool GoUp { get { return goUp; } }
        public bool GoDown { get { return goDown; } }

        public void KeyIsDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                goLeft = true;
            if (e.KeyCode == Keys.Right)
                goRight = true;
            if (e.KeyCode == Keys.Up)
                goUp = true;
            if (e.KeyCode == Keys.Down)
                goDown = true;
        }

        public void KeyIsUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                goLeft = false;
            if (e.KeyCode == Keys.Right)
                goRight = false;
            if (e.KeyCode == Keys.Up)
                goUp = false;
            if (e.KeyCode == Keys.Down)
                goDown = false;
        }
    }
}
