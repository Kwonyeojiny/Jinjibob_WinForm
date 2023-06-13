namespace BOB_진지밥_권여진김수지
{
    partial class _4_스토리
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_4_스토리));
            this.player = new System.Windows.Forms.PictureBox();
            this.door = new System.Windows.Forms.PictureBox();
            this.Storytimer = new System.Windows.Forms.Timer(this.components);
            this.talk = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.door)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.talk)).BeginInit();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.Image = ((System.Drawing.Image)(resources.GetObject("player.Image")));
            this.player.Location = new System.Drawing.Point(434, 405);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(170, 170);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player.TabIndex = 5;
            this.player.TabStop = false;
            // 
            // door
            // 
            this.door.BackColor = System.Drawing.Color.Transparent;
            this.door.Location = new System.Drawing.Point(952, 433);
            this.door.Name = "door";
            this.door.Size = new System.Drawing.Size(50, 125);
            this.door.TabIndex = 9;
            this.door.TabStop = false;
            // 
            // Storytimer
            // 
            this.Storytimer.Interval = 20;
            this.Storytimer.Tick += new System.EventHandler(this.StoryGameTimer_4);
            // 
            // talk
            // 
            this.talk.BackColor = System.Drawing.Color.Transparent;
            this.talk.Image = ((System.Drawing.Image)(resources.GetObject("talk.Image")));
            this.talk.Location = new System.Drawing.Point(587, 190);
            this.talk.Name = "talk";
            this.talk.Size = new System.Drawing.Size(256, 209);
            this.talk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.talk.TabIndex = 10;
            this.talk.TabStop = false;
            this.talk.Tag = "talk";
            // 
            // _4_스토리
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1032, 653);
            this.Controls.Add(this.talk);
            this.Controls.Add(this.door);
            this.Controls.Add(this.player);
            this.MaximumSize = new System.Drawing.Size(1050, 700);
            this.MinimumSize = new System.Drawing.Size(1050, 700);
            this.Name = "_4_스토리";
            this.Text = "진지밥";
            this.Load += new System.EventHandler(this._4_스토리_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.door)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.talk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.PictureBox door;
        private System.Windows.Forms.Timer Storytimer;
        private System.Windows.Forms.PictureBox talk;
    }
}