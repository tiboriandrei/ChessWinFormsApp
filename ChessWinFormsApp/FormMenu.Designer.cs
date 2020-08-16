namespace ChessWinFormsApp
{
    partial class FormMenu
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
            this.buttonPoker = new System.Windows.Forms.Button();
            this.buttonStartChess = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonPoker
            // 
            this.buttonPoker.Location = new System.Drawing.Point(322, 130);
            this.buttonPoker.Name = "buttonPoker";
            this.buttonPoker.Size = new System.Drawing.Size(159, 57);
            this.buttonPoker.TabIndex = 0;
            this.buttonPoker.Text = "Poker";
            this.buttonPoker.UseVisualStyleBackColor = true;
            this.buttonPoker.Click += new System.EventHandler(this.buttonPoker_Click);
            // 
            // buttonStartChess
            // 
            this.buttonStartChess.Location = new System.Drawing.Point(322, 215);
            this.buttonStartChess.Name = "buttonStartChess";
            this.buttonStartChess.Size = new System.Drawing.Size(159, 57);
            this.buttonStartChess.TabIndex = 1;
            this.buttonStartChess.Text = "Chess";
            this.buttonStartChess.UseVisualStyleBackColor = true;
            this.buttonStartChess.Click += new System.EventHandler(this.buttonStartChess_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonStartChess);
            this.Controls.Add(this.buttonPoker);
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPoker;
        private System.Windows.Forms.Button buttonStartChess;
    }
}