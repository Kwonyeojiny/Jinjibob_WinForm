using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 진지밥_권여진김수지;

namespace BOB_진지밥_권여진김수지
{
   
    public partial class _1_시작화면 : Form
    {
        public Player currentPlayer;

        private PlaceholderTextBox nameBox;

        public _1_시작화면()
        {
            InitializeComponent();
            currentPlayer = new Player();

            nameBox = new PlaceholderTextBox(); // placeholder 텍스트박스
            nameBox.PlaceholderText = "이름 or 닉네임";
            nameBox.Location = new Point(330, 380);
            nameBox.Size = new Size(225, 40);
            nameBox.Font = new Font("맑은 고딕", 10.8f);
            nameBox.Margin = new Padding(3);
            nameBox.TextAlign = HorizontalAlignment.Center;
            Controls.Add(nameBox);
            nameBox.BringToFront();
        }


        private void _1_시작화면_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // 게임시작 버튼
        {
            
            if (!string.IsNullOrEmpty(nameBox.Text)) // 이름 텍스트 박스가 비어있지 않을 때 폼 오픈
            {
                Player currentPlayer = new Player();
                currentPlayer.Name = nameBox.Text;

                _2_시작오프닝 form = FormOpen.OpenForm<_2_시작오프닝>(this, currentPlayer);
            }
            else
                MessageBox.Show("사용할 이름을 입력해주세요");
        }

        private void button3_Click(object sender, EventArgs e) // 나가기 버튼
        {
            MessageBox.Show("다음엔 플레이해주실거죠?");
            this.Close();        
        }

        private void button2_Click(object sender, EventArgs e) // 진지밥 소개 버튼
        {
            진지밥소개 form = FormOpen.MidOpenForm<진지밥소개>(this);
        }
    }

    public class PlaceholderTextBox : TextBox // placeholder textbox 생성 class
    {
        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        private string placeholderText;

        public string PlaceholderText
        {
            get { return placeholderText; }
            set
            {
                placeholderText = value;
                UpdatePlaceholder();
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            UpdatePlaceholder();
        }

        private void UpdatePlaceholder()
        {
            if (IsHandleCreated && placeholderText != null)
            {
                SendMessage(Handle, EM_SETCUEBANNER, 0, placeholderText);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                SendMessage(Handle, EM_SETCUEBANNER, 0, string.Empty); // Placeholder 제거
            }
            base.Dispose(disposing);
        }
    }
}
