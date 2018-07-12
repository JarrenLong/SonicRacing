namespace SonicRacing
{
    partial class BettingForm
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
            this.m_okButton = new System.Windows.Forms.Button();
            this.m_cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_player1OddsLabel = new System.Windows.Forms.Label();
            this.m_player1NameLabel = new System.Windows.Forms.Label();
            this.m_player2OddsLabel = new System.Windows.Forms.Label();
            this.m_player2NameLabel = new System.Windows.Forms.Label();
            this.m_player3OddsLabel = new System.Windows.Forms.Label();
            this.m_player3NameLabel = new System.Windows.Forms.Label();
            this.m_player1WagerTextBox = new System.Windows.Forms.TextBox();
            this.m_player2WagerTextBox = new System.Windows.Forms.TextBox();
            this.m_player3WagerTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.m_okButton.Location = new System.Drawing.Point(42, 106);
            this.m_okButton.Name = "okButton";
            this.m_okButton.Size = new System.Drawing.Size(75, 23);
            this.m_okButton.TabIndex = 0;
            this.m_okButton.Text = "OK";
            this.m_okButton.UseVisualStyleBackColor = true;
            this.m_okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.m_cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cancelButton.Location = new System.Drawing.Point(123, 106);
            this.m_cancelButton.Name = "cancelButton";
            this.m_cancelButton.Size = new System.Drawing.Size(75, 23);
            this.m_cancelButton.TabIndex = 1;
            this.m_cancelButton.Text = "Cancel";
            this.m_cancelButton.UseVisualStyleBackColor = true;
            this.m_cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Player Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Odds (%)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Wager";
            // 
            // player1OddsLabel
            // 
            this.m_player1OddsLabel.AutoSize = true;
            this.m_player1OddsLabel.Location = new System.Drawing.Point(92, 29);
            this.m_player1OddsLabel.Name = "player1OddsLabel";
            this.m_player1OddsLabel.Size = new System.Drawing.Size(33, 13);
            this.m_player1OddsLabel.TabIndex = 6;
            this.m_player1OddsLabel.Text = "100%";
            // 
            // player1NameLabel
            // 
            this.m_player1NameLabel.AutoSize = true;
            this.m_player1NameLabel.Location = new System.Drawing.Point(28, 29);
            this.m_player1NameLabel.Name = "player1NameLabel";
            this.m_player1NameLabel.Size = new System.Drawing.Size(34, 13);
            this.m_player1NameLabel.TabIndex = 5;
            this.m_player1NameLabel.Text = "Sonic";
            // 
            // player2OddsLabel
            // 
            this.m_player2OddsLabel.AutoSize = true;
            this.m_player2OddsLabel.Location = new System.Drawing.Point(92, 56);
            this.m_player2OddsLabel.Name = "player2OddsLabel";
            this.m_player2OddsLabel.Size = new System.Drawing.Size(33, 13);
            this.m_player2OddsLabel.TabIndex = 9;
            this.m_player2OddsLabel.Text = "100%";
            // 
            // player2NameLabel
            // 
            this.m_player2NameLabel.AutoSize = true;
            this.m_player2NameLabel.Location = new System.Drawing.Point(28, 56);
            this.m_player2NameLabel.Name = "player2NameLabel";
            this.m_player2NameLabel.Size = new System.Drawing.Size(29, 13);
            this.m_player2NameLabel.TabIndex = 8;
            this.m_player2NameLabel.Text = "Tails";
            // 
            // player3OddsLabel
            // 
            this.m_player3OddsLabel.AutoSize = true;
            this.m_player3OddsLabel.Location = new System.Drawing.Point(92, 83);
            this.m_player3OddsLabel.Name = "player3OddsLabel";
            this.m_player3OddsLabel.Size = new System.Drawing.Size(33, 13);
            this.m_player3OddsLabel.TabIndex = 12;
            this.m_player3OddsLabel.Text = "100%";
            // 
            // player3NameLabel
            // 
            this.m_player3NameLabel.AutoSize = true;
            this.m_player3NameLabel.Location = new System.Drawing.Point(28, 83);
            this.m_player3NameLabel.Name = "player3NameLabel";
            this.m_player3NameLabel.Size = new System.Drawing.Size(51, 13);
            this.m_player3NameLabel.TabIndex = 11;
            this.m_player3NameLabel.Text = "Knuckles";
            // 
            // player1WagerTextBox
            // 
            this.m_player1WagerTextBox.Location = new System.Drawing.Point(129, 26);
            this.m_player1WagerTextBox.Name = "player1WagerTextBox";
            this.m_player1WagerTextBox.Size = new System.Drawing.Size(100, 20);
            this.m_player1WagerTextBox.TabIndex = 13;
            // 
            // player2WagerTextBox
            // 
            this.m_player2WagerTextBox.Location = new System.Drawing.Point(129, 53);
            this.m_player2WagerTextBox.Name = "player2WagerTextBox";
            this.m_player2WagerTextBox.Size = new System.Drawing.Size(100, 20);
            this.m_player2WagerTextBox.TabIndex = 14;
            // 
            // player3WagerTextBox
            // 
            this.m_player3WagerTextBox.Location = new System.Drawing.Point(129, 80);
            this.m_player3WagerTextBox.Name = "player3WagerTextBox";
            this.m_player3WagerTextBox.Size = new System.Drawing.Size(100, 20);
            this.m_player3WagerTextBox.TabIndex = 15;
            // 
            // BettingForm
            // 
            this.AcceptButton = this.m_okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_cancelButton;
            this.ClientSize = new System.Drawing.Size(240, 138);
            this.Controls.Add(this.m_player3WagerTextBox);
            this.Controls.Add(this.m_player2WagerTextBox);
            this.Controls.Add(this.m_player1WagerTextBox);
            this.Controls.Add(this.m_player3OddsLabel);
            this.Controls.Add(this.m_player3NameLabel);
            this.Controls.Add(this.m_player2OddsLabel);
            this.Controls.Add(this.m_player2NameLabel);
            this.Controls.Add(this.m_player1OddsLabel);
            this.Controls.Add(this.m_player1NameLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_cancelButton);
            this.Controls.Add(this.m_okButton);
            this.Name = "BettingForm";
            this.Text = "Place Your Bets!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_okButton;
        private System.Windows.Forms.Button m_cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label m_player1OddsLabel;
        private System.Windows.Forms.Label m_player1NameLabel;
        private System.Windows.Forms.Label m_player2OddsLabel;
        private System.Windows.Forms.Label m_player2NameLabel;
        private System.Windows.Forms.Label m_player3OddsLabel;
        private System.Windows.Forms.Label m_player3NameLabel;
        private System.Windows.Forms.TextBox m_player1WagerTextBox;
        private System.Windows.Forms.TextBox m_player2WagerTextBox;
        private System.Windows.Forms.TextBox m_player3WagerTextBox;
    }
}