namespace SonicRacing
{
    partial class RaceControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.m_moveTimer = new System.Windows.Forms.Timer(this.components);
            this.m_pictureBox = new System.Windows.Forms.PictureBox();
            this.m_animationTimer = new System.Windows.Forms.Timer(this.components);
            this.m_toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // m_moveTimer
            // 
            this.m_moveTimer.Interval = 5;
            this.m_moveTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.m_pictureBox.Image = global::SonicRacing.Properties.Resources.sonic_map;
            this.m_pictureBox.Location = new System.Drawing.Point(0, 0);
            this.m_pictureBox.Name = "pictureBox1";
            this.m_pictureBox.Size = new System.Drawing.Size(128, 128);
            this.m_pictureBox.TabIndex = 0;
            this.m_pictureBox.TabStop = false;
            // 
            // m_animationTimer
            // 
            this.m_animationTimer.Interval = 33;
            this.m_animationTimer.Tick += new System.EventHandler(this.animationTimer_Tick);
            // 
            // RaceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.m_pictureBox);
            this.Name = "RaceControl";
            this.Size = new System.Drawing.Size(768, 128);
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox m_pictureBox;
        private System.Windows.Forms.Timer m_moveTimer;
        private System.Windows.Forms.Timer m_animationTimer;
        private System.Windows.Forms.ToolTip m_toolTip;
    }
}
