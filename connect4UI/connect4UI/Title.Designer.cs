using System;

namespace connect4UI
{
    partial class Title
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
            this.RulesBtn = new System.Windows.Forms.Button();
            this.StartBtn = new System.Windows.Forms.Button();
            this.CreditsBtn = new System.Windows.Forms.Button();
            this.lblLoadingRules = new System.Windows.Forms.Label();
            this.lblLoadingGame = new System.Windows.Forms.Label();
            this.lblCredits = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // RulesBtn
            // 
            this.RulesBtn.BackColor = System.Drawing.Color.Black;
            this.RulesBtn.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RulesBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.RulesBtn.Location = new System.Drawing.Point(349, 746);
            this.RulesBtn.Name = "RulesBtn";
            this.RulesBtn.Size = new System.Drawing.Size(295, 69);
            this.RulesBtn.TabIndex = 2;
            this.RulesBtn.Text = "RULES";
            this.RulesBtn.UseVisualStyleBackColor = false;
            this.RulesBtn.Click += new System.EventHandler(this.RulesBtn_Click);
            // 
            // StartBtn
            // 
            this.StartBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.StartBtn.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartBtn.ForeColor = System.Drawing.SystemColors.Desktop;
            this.StartBtn.Location = new System.Drawing.Point(713, 746);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(295, 69);
            this.StartBtn.TabIndex = 3;
            this.StartBtn.Text = "START";
            this.StartBtn.UseVisualStyleBackColor = false;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // CreditsBtn
            // 
            this.CreditsBtn.BackColor = System.Drawing.Color.Black;
            this.CreditsBtn.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreditsBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.CreditsBtn.Location = new System.Drawing.Point(1074, 746);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.Size = new System.Drawing.Size(295, 69);
            this.CreditsBtn.TabIndex = 4;
            this.CreditsBtn.Text = "CREDITS";
            this.CreditsBtn.UseVisualStyleBackColor = false;
            this.CreditsBtn.VisibleChanged += new System.EventHandler(this.LblCredits);
            this.CreditsBtn.Click += new System.EventHandler(this.CreditsBtn_Click);
            // 
            // lblLoadingRules
            // 
            this.lblLoadingRules.AutoSize = true;
            this.lblLoadingRules.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadingRules.ForeColor = System.Drawing.SystemColors.Window;
            this.lblLoadingRules.Location = new System.Drawing.Point(445, 898);
            this.lblLoadingRules.Name = "lblLoadingRules";
            this.lblLoadingRules.Size = new System.Drawing.Size(199, 30);
            this.lblLoadingRules.TabIndex = 5;
            this.lblLoadingRules.Text = "Loading Rules...";
            this.lblLoadingRules.Visible = false;
            // 
            // lblLoadingGame
            // 
            this.lblLoadingGame.AutoSize = true;
            this.lblLoadingGame.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadingGame.ForeColor = System.Drawing.SystemColors.Window;
            this.lblLoadingGame.Location = new System.Drawing.Point(794, 898);
            this.lblLoadingGame.Name = "lblLoadingGame";
            this.lblLoadingGame.Size = new System.Drawing.Size(214, 30);
            this.lblLoadingGame.TabIndex = 6;
            this.lblLoadingGame.Text = "Loading Game...";
            this.lblLoadingGame.Visible = false;
            this.lblLoadingGame.Click += new System.EventHandler(this.lblLoadingGame_Click);
            // 
            // lblCredits
            // 
            this.lblCredits.AutoSize = true;
            this.lblCredits.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredits.ForeColor = System.Drawing.SystemColors.Window;
            this.lblCredits.Location = new System.Drawing.Point(1165, 898);
            this.lblCredits.Name = "lblCredits";
            this.lblCredits.Size = new System.Drawing.Size(204, 30);
            this.lblCredits.TabIndex = 7;
            this.lblCredits.Text = "Team DevOOPS";
            this.lblCredits.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            // 
            // Title
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Navy;
            this.BackgroundImage = global::connect4UI.Properties.Resources.connect4titlebanner;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1707, 1158);
            this.Controls.Add(this.lblCredits);
            this.Controls.Add(this.lblLoadingGame);
            this.Controls.Add(this.lblLoadingRules);
            this.Controls.Add(this.CreditsBtn);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.RulesBtn);
            this.DoubleBuffered = true;
            this.MinimizeBox = false;
            this.Name = "Title";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect 4 Title Screen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2);
            this.Click += new System.EventHandler(this.StartBtn_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.Button RulesBtn;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Button CreditsBtn;
        private System.Windows.Forms.Label lblLoadingRules;
        private System.Windows.Forms.Label lblLoadingGame;
        private System.Windows.Forms.Label lblCredits;
        private System.Windows.Forms.Timer timer1;
    }
}

