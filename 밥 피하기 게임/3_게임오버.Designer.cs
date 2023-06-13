namespace 진지밥_권여진김수지
{
    partial class _3_게임오버
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_3_게임오버));
            this.다시하기 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // 다시하기
            // 
            this.다시하기.Font = new System.Drawing.Font("굴림", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.다시하기.Location = new System.Drawing.Point(768, 31);
            this.다시하기.Name = "다시하기";
            this.다시하기.Size = new System.Drawing.Size(237, 97);
            this.다시하기.TabIndex = 2;
            this.다시하기.Text = "다시하기";
            this.다시하기.UseVisualStyleBackColor = true;
            this.다시하기.Click += new System.EventHandler(this.다시하기_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("굴림", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(12, 567);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 74);
            this.button1.TabIndex = 4;
            this.button1.Text = "게임설명";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-7, -8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1046, 668);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // _3_게임오버
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 653);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.다시하기);
            this.Controls.Add(this.pictureBox1);
            this.MaximumSize = new System.Drawing.Size(1050, 700);
            this.MinimumSize = new System.Drawing.Size(1050, 700);
            this.Name = "_3_게임오버";
            this.Text = "진지밥";
            this.Load += new System.EventHandler(this._3_게임오버_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button 다시하기;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}