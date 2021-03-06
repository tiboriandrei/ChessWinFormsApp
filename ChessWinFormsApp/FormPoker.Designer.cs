﻿namespace ChessWinFormsApp
{
    partial class FormPoker
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonAddPlayer = new System.Windows.Forms.Button();
            this.buttonBet = new System.Windows.Forms.Button();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.buttonFold = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.labelMin = new System.Windows.Forms.Label();
            this.labelMax = new System.Windows.Forms.Label();
            this.textBoxPlayerName = new System.Windows.Forms.TextBox();
            this.textBoxChips = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.labelPlayer2 = new System.Windows.Forms.Label();
            this.labelPot = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(115, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(552, 432);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // buttonAddPlayer
            // 
            this.buttonAddPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddPlayer.Location = new System.Drawing.Point(591, 495);
            this.buttonAddPlayer.Name = "buttonAddPlayer";
            this.buttonAddPlayer.Size = new System.Drawing.Size(100, 51);
            this.buttonAddPlayer.TabIndex = 1;
            this.buttonAddPlayer.Text = "Add Player to Table";
            this.buttonAddPlayer.UseVisualStyleBackColor = true;
            this.buttonAddPlayer.Click += new System.EventHandler(this.buttonAddPlayer_Click);
            // 
            // buttonBet
            // 
            this.buttonBet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBet.Location = new System.Drawing.Point(343, 495);
            this.buttonBet.Name = "buttonBet";
            this.buttonBet.Size = new System.Drawing.Size(70, 51);
            this.buttonBet.TabIndex = 2;
            this.buttonBet.Text = "BET";
            this.buttonBet.UseVisualStyleBackColor = true;
            this.buttonBet.Click += new System.EventHandler(this.buttonBet_Click);
            // 
            // buttonCheck
            // 
            this.buttonCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCheck.Location = new System.Drawing.Point(419, 495);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(69, 51);
            this.buttonCheck.TabIndex = 3;
            this.buttonCheck.Text = "CHECK";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // buttonFold
            // 
            this.buttonFold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFold.Location = new System.Drawing.Point(494, 495);
            this.buttonFold.Name = "buttonFold";
            this.buttonFold.Size = new System.Drawing.Size(73, 51);
            this.buttonFold.TabIndex = 4;
            this.buttonFold.Text = "FOLD";
            this.buttonFold.UseVisualStyleBackColor = true;
            this.buttonFold.Click += new System.EventHandler(this.buttonFold_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.Location = new System.Drawing.Point(128, 495);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(197, 45);
            this.trackBar1.TabIndex = 5;
            // 
            // labelMin
            // 
            this.labelMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMin.AutoSize = true;
            this.labelMin.Location = new System.Drawing.Point(125, 543);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(24, 13);
            this.labelMin.TabIndex = 6;
            this.labelMin.Text = "Min";
            // 
            // labelMax
            // 
            this.labelMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMax.AutoSize = true;
            this.labelMax.Location = new System.Drawing.Point(298, 543);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(27, 13);
            this.labelMax.TabIndex = 7;
            this.labelMax.Text = "Max";
            // 
            // textBoxPlayerName
            // 
            this.textBoxPlayerName.Location = new System.Drawing.Point(697, 495);
            this.textBoxPlayerName.Name = "textBoxPlayerName";
            this.textBoxPlayerName.Size = new System.Drawing.Size(100, 20);
            this.textBoxPlayerName.TabIndex = 8;
            this.textBoxPlayerName.Text = "Tom";
            // 
            // textBoxChips
            // 
            this.textBoxChips.Location = new System.Drawing.Point(697, 526);
            this.textBoxChips.Name = "textBoxChips";
            this.textBoxChips.Size = new System.Drawing.Size(100, 20);
            this.textBoxChips.TabIndex = 9;
            this.textBoxChips.Text = "1000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(697, 408);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Time";
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(697, 38);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(125, 51);
            this.buttonStart.TabIndex = 11;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPause.Location = new System.Drawing.Point(697, 95);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(125, 51);
            this.buttonPause.TabIndex = 12;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Location = new System.Drawing.Point(212, 176);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(55, 13);
            this.labelPlayer1.TabIndex = 13;
            this.labelPlayer1.Text = "PLAYER1";
            // 
            // labelPlayer2
            // 
            this.labelPlayer2.AutoSize = true;
            this.labelPlayer2.Location = new System.Drawing.Point(396, 158);
            this.labelPlayer2.Name = "labelPlayer2";
            this.labelPlayer2.Size = new System.Drawing.Size(55, 13);
            this.labelPlayer2.TabIndex = 14;
            this.labelPlayer2.Text = "PLAYER2";
            // 
            // labelPot
            // 
            this.labelPot.AutoSize = true;
            this.labelPot.Location = new System.Drawing.Point(491, 190);
            this.labelPot.Name = "labelPot";
            this.labelPot.Size = new System.Drawing.Size(13, 13);
            this.labelPot.TabIndex = 15;
            this.labelPot.Text = "0";
            // 
            // FormPoker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 571);
            this.Controls.Add(this.labelPot);
            this.Controls.Add(this.labelPlayer2);
            this.Controls.Add(this.labelPlayer1);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxChips);
            this.Controls.Add(this.textBoxPlayerName);
            this.Controls.Add(this.labelMax);
            this.Controls.Add(this.labelMin);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.buttonFold);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.buttonBet);
            this.Controls.Add(this.buttonAddPlayer);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormPoker";
            this.Text = "FormPoker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormPoker_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonAddPlayer;
        private System.Windows.Forms.Button buttonBet;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.Button buttonFold;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.TextBox textBoxPlayerName;
        private System.Windows.Forms.TextBox textBoxChips;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.Label labelPlayer2;
        private System.Windows.Forms.Label labelPot;
    }
}