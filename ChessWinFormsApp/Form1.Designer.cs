namespace ChessWinFormsApp
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelMouseLocation = new System.Windows.Forms.Label();
            this.labelSelectedPiece = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelBlackTime = new System.Windows.Forms.Label();
            this.labelWhiteTime = new System.Windows.Forms.Label();
            this.buttonClock = new System.Windows.Forms.Button();
            this.buttonStopClock = new System.Windows.Forms.Button();
            this.labelWinner = new System.Windows.Forms.Label();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(836, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.startToolStripMenuItem.Text = "Options";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.newGameToolStripMenuItem.Text = "New game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(84, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(480, 480);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // labelMouseLocation
            // 
            this.labelMouseLocation.AutoSize = true;
            this.labelMouseLocation.Location = new System.Drawing.Point(621, 47);
            this.labelMouseLocation.Name = "labelMouseLocation";
            this.labelMouseLocation.Size = new System.Drawing.Size(54, 13);
            this.labelMouseLocation.TabIndex = 2;
            this.labelMouseLocation.Text = "Mouse at:";
            // 
            // labelSelectedPiece
            // 
            this.labelSelectedPiece.AutoSize = true;
            this.labelSelectedPiece.Location = new System.Drawing.Point(621, 64);
            this.labelSelectedPiece.Name = "labelSelectedPiece";
            this.labelSelectedPiece.Size = new System.Drawing.Size(81, 13);
            this.labelSelectedPiece.TabIndex = 3;
            this.labelSelectedPiece.Text = "Selected piece:";
            // 
            // labelBlackTime
            // 
            this.labelBlackTime.AutoSize = true;
            this.labelBlackTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBlackTime.Location = new System.Drawing.Point(618, 92);
            this.labelBlackTime.Name = "labelBlackTime";
            this.labelBlackTime.Size = new System.Drawing.Size(126, 31);
            this.labelBlackTime.TabIndex = 4;
            this.labelBlackTime.Text = "Time left:";
            // 
            // labelWhiteTime
            // 
            this.labelWhiteTime.AutoSize = true;
            this.labelWhiteTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWhiteTime.Location = new System.Drawing.Point(618, 436);
            this.labelWhiteTime.Name = "labelWhiteTime";
            this.labelWhiteTime.Size = new System.Drawing.Size(126, 31);
            this.labelWhiteTime.TabIndex = 5;
            this.labelWhiteTime.Text = "Time left:";
            // 
            // buttonClock
            // 
            this.buttonClock.Location = new System.Drawing.Point(749, 490);
            this.buttonClock.Name = "buttonClock";
            this.buttonClock.Size = new System.Drawing.Size(75, 23);
            this.buttonClock.TabIndex = 6;
            this.buttonClock.Text = "Clock";
            this.buttonClock.UseVisualStyleBackColor = true;
            this.buttonClock.Click += new System.EventHandler(this.buttonClock_Click);
            // 
            // buttonStopClock
            // 
            this.buttonStopClock.Location = new System.Drawing.Point(749, 519);
            this.buttonStopClock.Name = "buttonStopClock";
            this.buttonStopClock.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonStopClock.Size = new System.Drawing.Size(75, 23);
            this.buttonStopClock.TabIndex = 7;
            this.buttonStopClock.Text = "Stop Clock";
            this.buttonStopClock.UseVisualStyleBackColor = true;
            this.buttonStopClock.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelWinner
            // 
            this.labelWinner.AutoSize = true;
            this.labelWinner.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWinner.Location = new System.Drawing.Point(602, 252);
            this.labelWinner.Name = "labelWinner";
            this.labelWinner.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelWinner.Size = new System.Drawing.Size(0, 31);
            this.labelWinner.TabIndex = 8;
            // 
            // buttonUndo
            // 
            this.buttonUndo.Location = new System.Drawing.Point(84, 528);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(43, 23);
            this.buttonUndo.TabIndex = 9;
            this.buttonUndo.Text = "Undo";
            this.buttonUndo.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 554);
            this.Controls.Add(this.buttonUndo);
            this.Controls.Add(this.labelWinner);
            this.Controls.Add(this.buttonStopClock);
            this.Controls.Add(this.buttonClock);
            this.Controls.Add(this.labelWhiteTime);
            this.Controls.Add(this.labelBlackTime);
            this.Controls.Add(this.labelSelectedPiece);
            this.Controls.Add(this.labelMouseLocation);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelMouseLocation;
        private System.Windows.Forms.Label labelSelectedPiece;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelBlackTime;
        private System.Windows.Forms.Label labelWhiteTime;
        private System.Windows.Forms.Button buttonClock;
        private System.Windows.Forms.Button buttonStopClock;
        private System.Windows.Forms.Label labelWinner;
        private System.Windows.Forms.Button buttonUndo;
    }
}

