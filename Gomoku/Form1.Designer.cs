namespace Gomoku
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.Field = new System.Windows.Forms.Panel();
            this.lTitle = new System.Windows.Forms.Label();
            this.lBlack = new System.Windows.Forms.Label();
            this.lWhite = new System.Windows.Forms.Label();
            this.lBlackScore = new System.Windows.Forms.Label();
            this.lWhiteScore = new System.Windows.Forms.Label();
            this.lTurn = new System.Windows.Forms.Label();
            this.bRestart = new System.Windows.Forms.Button();
            this.Field.SuspendLayout();
            this.SuspendLayout();
            // 
            // Field
            // 
            this.Field.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(51)))));
            this.Field.Controls.Add(this.bRestart);
            this.Field.Controls.Add(this.lTurn);
            this.Field.Controls.Add(this.lWhiteScore);
            this.Field.Controls.Add(this.lBlackScore);
            this.Field.Controls.Add(this.lWhite);
            this.Field.Controls.Add(this.lBlack);
            this.Field.Controls.Add(this.lTitle);
            this.Field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Field.Location = new System.Drawing.Point(0, 0);
            this.Field.Name = "Field";
            this.Field.Size = new System.Drawing.Size(734, 621);
            this.Field.TabIndex = 0;
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lTitle.Location = new System.Drawing.Point(610, 40);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(89, 22);
            this.lTitle.TabIndex = 0;
            this.lTitle.Text = "Gomoku";
            // 
            // lBlack
            // 
            this.lBlack.AutoSize = true;
            this.lBlack.Location = new System.Drawing.Point(622, 104);
            this.lBlack.Name = "lBlack";
            this.lBlack.Size = new System.Drawing.Size(36, 12);
            this.lBlack.TabIndex = 1;
            this.lBlack.Text = "Black";
            // 
            // lWhite
            // 
            this.lWhite.AutoSize = true;
            this.lWhite.Location = new System.Drawing.Point(622, 135);
            this.lWhite.Name = "lWhite";
            this.lWhite.Size = new System.Drawing.Size(35, 12);
            this.lWhite.TabIndex = 2;
            this.lWhite.Text = "White";
            // 
            // lBlackScore
            // 
            this.lBlackScore.AutoSize = true;
            this.lBlackScore.Location = new System.Drawing.Point(674, 104);
            this.lBlackScore.Name = "lBlackScore";
            this.lBlackScore.Size = new System.Drawing.Size(11, 12);
            this.lBlackScore.TabIndex = 3;
            this.lBlackScore.Text = "0";
            // 
            // lWhiteScore
            // 
            this.lWhiteScore.AutoSize = true;
            this.lWhiteScore.Location = new System.Drawing.Point(674, 135);
            this.lWhiteScore.Name = "lWhiteScore";
            this.lWhiteScore.Size = new System.Drawing.Size(11, 12);
            this.lWhiteScore.TabIndex = 4;
            this.lWhiteScore.Text = "0";
            // 
            // lTurn
            // 
            this.lTurn.AutoSize = true;
            this.lTurn.Location = new System.Drawing.Point(612, 73);
            this.lTurn.Name = "lTurn";
            this.lTurn.Size = new System.Drawing.Size(0, 12);
            this.lTurn.TabIndex = 5;
            // 
            // bRestart
            // 
            this.bRestart.Location = new System.Drawing.Point(614, 174);
            this.bRestart.Name = "bRestart";
            this.bRestart.Size = new System.Drawing.Size(85, 23);
            this.bRestart.TabIndex = 6;
            this.bRestart.Text = "Reset";
            this.bRestart.UseVisualStyleBackColor = true;
            this.bRestart.Click += new System.EventHandler(this.bRestart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 621);
            this.Controls.Add(this.Field);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Gomoku";
            this.Field.ResumeLayout(false);
            this.Field.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Field;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Label lWhite;
        private System.Windows.Forms.Label lBlack;
        private System.Windows.Forms.Label lTurn;
        private System.Windows.Forms.Label lWhiteScore;
        private System.Windows.Forms.Label lBlackScore;
        private System.Windows.Forms.Button bRestart;
    }
}

