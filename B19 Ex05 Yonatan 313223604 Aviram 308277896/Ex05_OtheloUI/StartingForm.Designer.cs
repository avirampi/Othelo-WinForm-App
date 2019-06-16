namespace Ex05_OtheloUI
{
    partial class FormGameSetting
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
            this.buttonPvC = new System.Windows.Forms.Button();
            this.buttonPvP = new System.Windows.Forms.Button();
            this.buttonBoardSize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonPvC
            // 
            this.buttonPvC.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonPvC.Location = new System.Drawing.Point(12, 175);
            this.buttonPvC.Name = "buttonPvC";
            this.buttonPvC.Size = new System.Drawing.Size(361, 97);
            this.buttonPvC.TabIndex = 0;
            this.buttonPvC.Text = "Play Against The Computer";
            this.buttonPvC.UseVisualStyleBackColor = true;
            this.buttonPvC.Click += new System.EventHandler(this.buttonPvC_Click);
            // 
            // buttonPvP
            // 
            this.buttonPvP.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonPvP.Location = new System.Drawing.Point(427, 175);
            this.buttonPvP.Name = "buttonPvP";
            this.buttonPvP.Size = new System.Drawing.Size(361, 97);
            this.buttonPvP.TabIndex = 1;
            this.buttonPvP.Text = "Play Against Your Friend";
            this.buttonPvP.UseVisualStyleBackColor = true;
            this.buttonPvP.Click += new System.EventHandler(this.buttonPvP_Click);
            // 
            // buttonBoardSize
            // 
            this.buttonBoardSize.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonBoardSize.Location = new System.Drawing.Point(12, 48);
            this.buttonBoardSize.Name = "buttonBoardSize";
            this.buttonBoardSize.Size = new System.Drawing.Size(776, 97);
            this.buttonBoardSize.TabIndex = 2;
            this.buttonBoardSize.Text = "Board Size 6x6 (click to change)";
            this.buttonBoardSize.UseVisualStyleBackColor = true;
            this.buttonBoardSize.Click += new System.EventHandler(this.buttonBoardSize_Click);
            // 
            // FormGameSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 295);
            this.Controls.Add(this.buttonBoardSize);
            this.Controls.Add(this.buttonPvP);
            this.Controls.Add(this.buttonPvC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormGameSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Othello - Game Setting";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPvC;
        private System.Windows.Forms.Button buttonPvP;
        private System.Windows.Forms.Button buttonBoardSize;
    }
}

