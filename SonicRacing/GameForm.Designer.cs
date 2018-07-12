namespace SonicRacing
{
    partial class GameForm
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
            SonicRacing.RaceObject raceObject1 = new SonicRacing.RaceObject();
            SonicRacing.RaceObject raceObject2 = new SonicRacing.RaceObject();
            SonicRacing.RaceObject raceObject3 = new SonicRacing.RaceObject();
            this.m_goButton = new System.Windows.Forms.Button();
            this.m_betButton = new System.Windows.Forms.Button();
            this.m_keyForwardButton = new System.Windows.Forms.Button();
            this.m_p3RaceControl = new SonicRacing.RaceControl();
            this.m_p2RaceControl = new SonicRacing.RaceControl();
            this.m_p1RaceControl = new SonicRacing.RaceControl();
            this.m_resetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_goButton
            // 
            this.m_goButton.Location = new System.Drawing.Point(94, 419);
            this.m_goButton.Name = "m_goButton";
            this.m_goButton.Size = new System.Drawing.Size(75, 23);
            this.m_goButton.TabIndex = 5;
            this.m_goButton.Text = "Go!";
            this.m_goButton.UseVisualStyleBackColor = true;
            this.m_goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // m_betButton
            // 
            this.m_betButton.Location = new System.Drawing.Point(13, 419);
            this.m_betButton.Name = "m_betButton";
            this.m_betButton.Size = new System.Drawing.Size(75, 23);
            this.m_betButton.TabIndex = 4;
            this.m_betButton.Text = "Place Bets";
            this.m_betButton.UseVisualStyleBackColor = true;
            this.m_betButton.Click += new System.EventHandler(this.betButton_Click);
            // 
            // m_keyForwardButton
            // 
            this.m_keyForwardButton.BackColor = System.Drawing.Color.Transparent;
            this.m_keyForwardButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.m_keyForwardButton.Location = new System.Drawing.Point(13, 13);
            this.m_keyForwardButton.Name = "m_keyForwardButton";
            this.m_keyForwardButton.Size = new System.Drawing.Size(0, 0);
            this.m_keyForwardButton.TabIndex = 0;
            this.m_keyForwardButton.UseVisualStyleBackColor = false;
            this.m_keyForwardButton.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyForwardButton_KeyUp);
            this.m_keyForwardButton.Leave += new System.EventHandler(this.keyForwardButton_Leave);
            // 
            // m_p3RaceControl
            // 
            this.m_p3RaceControl.Autorun = true;
            this.m_p3RaceControl.BackColor = System.Drawing.Color.Transparent;
            this.m_p3RaceControl.Location = new System.Drawing.Point(0, 288);
            this.m_p3RaceControl.Margin = new System.Windows.Forms.Padding(0);
            this.m_p3RaceControl.Name = "m_p3RaceControl";
            raceObject1.ActiveAnimation = 0;
            raceObject1.Bet = 0;
            raceObject1.Money = 100F;
            raceObject1.MoveKey = System.Windows.Forms.Keys.None;
            raceObject1.Name = "";
            this.m_p3RaceControl.PlayerData = raceObject1;
            this.m_p3RaceControl.Size = new System.Drawing.Size(768, 128);
            this.m_p3RaceControl.TabIndex = 3;
            // 
            // m_p2RaceControl
            // 
            this.m_p2RaceControl.Autorun = true;
            this.m_p2RaceControl.BackColor = System.Drawing.Color.Transparent;
            this.m_p2RaceControl.Location = new System.Drawing.Point(0, 160);
            this.m_p2RaceControl.Margin = new System.Windows.Forms.Padding(0);
            this.m_p2RaceControl.Name = "m_p2RaceControl";
            raceObject2.ActiveAnimation = 0;
            raceObject2.Bet = 0;
            raceObject2.Money = 100F;
            raceObject2.MoveKey = System.Windows.Forms.Keys.None;
            raceObject2.Name = "";
            this.m_p2RaceControl.PlayerData = raceObject2;
            this.m_p2RaceControl.Size = new System.Drawing.Size(768, 128);
            this.m_p2RaceControl.TabIndex = 2;
            // 
            // m_p1RaceControl
            // 
            this.m_p1RaceControl.Autorun = true;
            this.m_p1RaceControl.BackColor = System.Drawing.Color.Transparent;
            this.m_p1RaceControl.Location = new System.Drawing.Point(0, 32);
            this.m_p1RaceControl.Margin = new System.Windows.Forms.Padding(0);
            this.m_p1RaceControl.Name = "m_p1RaceControl";
            raceObject3.ActiveAnimation = 0;
            raceObject3.Bet = 0;
            raceObject3.Money = 100F;
            raceObject3.MoveKey = System.Windows.Forms.Keys.None;
            raceObject3.Name = "";
            this.m_p1RaceControl.PlayerData = raceObject3;
            this.m_p1RaceControl.Size = new System.Drawing.Size(768, 128);
            this.m_p1RaceControl.TabIndex = 1;
            // 
            // m_resetButton
            // 
            this.m_resetButton.Location = new System.Drawing.Point(176, 419);
            this.m_resetButton.Name = "m_resetButton";
            this.m_resetButton.Size = new System.Drawing.Size(75, 23);
            this.m_resetButton.TabIndex = 6;
            this.m_resetButton.Text = "Reset";
            this.m_resetButton.UseVisualStyleBackColor = true;
            this.m_resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SonicRacing.Properties.Resources.track;
            this.ClientSize = new System.Drawing.Size(796, 450);
            this.Controls.Add(this.m_resetButton);
            this.Controls.Add(this.m_keyForwardButton);
            this.Controls.Add(this.m_betButton);
            this.Controls.Add(this.m_goButton);
            this.Controls.Add(this.m_p3RaceControl);
            this.Controls.Add(this.m_p2RaceControl);
            this.Controls.Add(this.m_p1RaceControl);
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sonic(tm) Racing";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Shown += new System.EventHandler(this.RaceForm_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private RaceControl m_p1RaceControl;
        private RaceControl m_p2RaceControl;
        private RaceControl m_p3RaceControl;
        private System.Windows.Forms.Button m_goButton;
        private System.Windows.Forms.Button m_betButton;
        private System.Windows.Forms.Button m_keyForwardButton;
        private System.Windows.Forms.Button m_resetButton;
    }
}

