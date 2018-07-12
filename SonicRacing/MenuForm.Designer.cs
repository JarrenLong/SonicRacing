namespace SonicRacing
{
    partial class MenuForm
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
            this.m_autoLabel = new System.Windows.Forms.Label();
            this.m_p1Label = new System.Windows.Forms.Label();
            this.m_p2Label = new System.Windows.Forms.Label();
            this.m_aboutLabel = new System.Windows.Forms.Label();
            this.m_quitLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // autoLabel
            // 
            this.m_autoLabel.AutoSize = true;
            this.m_autoLabel.BackColor = System.Drawing.Color.Black;
            this.m_autoLabel.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_autoLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.m_autoLabel.Location = new System.Drawing.Point(194, 239);
            this.m_autoLabel.Name = "autoLabel";
            this.m_autoLabel.Size = new System.Drawing.Size(92, 22);
            this.m_autoLabel.TabIndex = 0;
            this.m_autoLabel.Text = "Autopilot";
            // 
            // p1Label
            // 
            this.m_p1Label.AutoSize = true;
            this.m_p1Label.BackColor = System.Drawing.Color.Black;
            this.m_p1Label.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_p1Label.ForeColor = System.Drawing.Color.White;
            this.m_p1Label.Location = new System.Drawing.Point(202, 261);
            this.m_p1Label.Name = "p1Label";
            this.m_p1Label.Size = new System.Drawing.Size(77, 22);
            this.m_p1Label.TabIndex = 1;
            this.m_p1Label.Text = "1 Player";
            // 
            // p2Label
            // 
            this.m_p2Label.AutoSize = true;
            this.m_p2Label.BackColor = System.Drawing.Color.Black;
            this.m_p2Label.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_p2Label.ForeColor = System.Drawing.Color.White;
            this.m_p2Label.Location = new System.Drawing.Point(202, 283);
            this.m_p2Label.Name = "p2Label";
            this.m_p2Label.Size = new System.Drawing.Size(77, 22);
            this.m_p2Label.TabIndex = 2;
            this.m_p2Label.Text = "2 Player";
            // 
            // aboutLabel
            // 
            this.m_aboutLabel.AutoSize = true;
            this.m_aboutLabel.BackColor = System.Drawing.Color.Black;
            this.m_aboutLabel.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_aboutLabel.ForeColor = System.Drawing.Color.White;
            this.m_aboutLabel.Location = new System.Drawing.Point(211, 305);
            this.m_aboutLabel.Name = "aboutLabel";
            this.m_aboutLabel.Size = new System.Drawing.Size(59, 22);
            this.m_aboutLabel.TabIndex = 3;
            this.m_aboutLabel.Text = "About";
            // 
            // quitLabel
            // 
            this.m_quitLabel.AutoSize = true;
            this.m_quitLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_quitLabel.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_quitLabel.ForeColor = System.Drawing.Color.White;
            this.m_quitLabel.Location = new System.Drawing.Point(193, 327);
            this.m_quitLabel.Name = "quitLabel";
            this.m_quitLabel.Size = new System.Drawing.Size(94, 22);
            this.m_quitLabel.TabIndex = 4;
            this.m_quitLabel.Text = "Quit Game";
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SonicRacing.Properties.Resources.menu;
            this.ClientSize = new System.Drawing.Size(480, 358);
            this.Controls.Add(this.m_quitLabel);
            this.Controls.Add(this.m_aboutLabel);
            this.Controls.Add(this.m_p2Label);
            this.Controls.Add(this.m_p1Label);
            this.Controls.Add(this.m_autoLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MenuForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sonic(tm) Racing";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MenuForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_autoLabel;
        private System.Windows.Forms.Label m_p1Label;
        private System.Windows.Forms.Label m_p2Label;
        private System.Windows.Forms.Label m_aboutLabel;
        private System.Windows.Forms.Label m_quitLabel;
    }
}