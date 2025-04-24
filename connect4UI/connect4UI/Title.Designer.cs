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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Title));
            this.RulesBtn = new System.Windows.Forms.Button();
            this.PvPStartBtn = new System.Windows.Forms.Button();
            this.CreditsBtn = new System.Windows.Forms.Button();
            this.lblCredits = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.HardAiStartBtn = new System.Windows.Forms.Button();
            this.EasyAiStartBtn = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RulesBtn
            // 
            this.RulesBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.RulesBtn.AutoSize = true;
            this.RulesBtn.BackColor = System.Drawing.Color.Black;
            this.RulesBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RulesBtn.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RulesBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.RulesBtn.Location = new System.Drawing.Point(708, 123);
            this.RulesBtn.Margin = new System.Windows.Forms.Padding(0);
            this.RulesBtn.Name = "RulesBtn";
            this.RulesBtn.Size = new System.Drawing.Size(290, 63);
            this.RulesBtn.TabIndex = 2;
            this.RulesBtn.Text = "RULES";
            this.RulesBtn.UseVisualStyleBackColor = false;
            this.RulesBtn.Click += new System.EventHandler(this.RulesBtn_Click);
            // 
            // PvPStartBtn
            // 
            this.PvPStartBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PvPStartBtn.AutoSize = true;
            this.PvPStartBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.PvPStartBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PvPStartBtn.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PvPStartBtn.ForeColor = System.Drawing.SystemColors.Desktop;
            this.PvPStartBtn.Location = new System.Drawing.Point(0, 13);
            this.PvPStartBtn.Margin = new System.Windows.Forms.Padding(0);
            this.PvPStartBtn.Name = "PvPStartBtn";
            this.PvPStartBtn.Size = new System.Drawing.Size(358, 77);
            this.PvPStartBtn.TabIndex = 3;
            this.PvPStartBtn.Text = "2 Players";
            this.PvPStartBtn.UseVisualStyleBackColor = false;
            this.PvPStartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // CreditsBtn
            // 
            this.CreditsBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CreditsBtn.AutoSize = true;
            this.CreditsBtn.BackColor = System.Drawing.Color.Black;
            this.CreditsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CreditsBtn.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreditsBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.CreditsBtn.Location = new System.Drawing.Point(708, 221);
            this.CreditsBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.Size = new System.Drawing.Size(290, 65);
            this.CreditsBtn.TabIndex = 4;
            this.CreditsBtn.Text = "CREDITS";
            this.CreditsBtn.UseVisualStyleBackColor = false;
            this.CreditsBtn.VisibleChanged += new System.EventHandler(this.LblCredits);
            this.CreditsBtn.Click += new System.EventHandler(this.CreditsBtn_Click);
            // 
            // lblCredits
            // 
            this.lblCredits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCredits.AutoSize = true;
            this.lblCredits.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCredits.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredits.ForeColor = System.Drawing.SystemColors.Window;
            this.lblCredits.Location = new System.Drawing.Point(30, 20);
            this.lblCredits.Margin = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.lblCredits.Name = "lblCredits";
            this.lblCredits.Padding = new System.Windows.Forms.Padding(60, 0, 60, 0);
            this.lblCredits.Size = new System.Drawing.Size(1103, 43);
            this.lblCredits.TabIndex = 7;
            this.lblCredits.Text = "Team DevOOPS: Andrei Laqui and Heather-may Howse";
            this.lblCredits.Visible = false;
            this.lblCredits.Click += new System.EventHandler(this.lblCredits_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.lblCredits);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(328, 19);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(100, 10, 190, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1242, 172);
            this.flowLayoutPanel1.TabIndex = 8;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint_1);
            // 
            // HardAiStartBtn
            // 
            this.HardAiStartBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.HardAiStartBtn.AutoSize = true;
            this.HardAiStartBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(2)))), ((int)(((byte)(35)))));
            this.HardAiStartBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HardAiStartBtn.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HardAiStartBtn.ForeColor = System.Drawing.SystemColors.Desktop;
            this.HardAiStartBtn.Location = new System.Drawing.Point(0, 214);
            this.HardAiStartBtn.Margin = new System.Windows.Forms.Padding(0);
            this.HardAiStartBtn.Name = "HardAiStartBtn";
            this.HardAiStartBtn.Size = new System.Drawing.Size(358, 80);
            this.HardAiStartBtn.TabIndex = 8;
            this.HardAiStartBtn.Text = "Hard AI";
            this.HardAiStartBtn.UseVisualStyleBackColor = false;
            this.HardAiStartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // EasyAiStartBtn
            // 
            this.EasyAiStartBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EasyAiStartBtn.AutoSize = true;
            this.EasyAiStartBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.EasyAiStartBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EasyAiStartBtn.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EasyAiStartBtn.ForeColor = System.Drawing.SystemColors.Desktop;
            this.EasyAiStartBtn.Location = new System.Drawing.Point(0, 113);
            this.EasyAiStartBtn.Margin = new System.Windows.Forms.Padding(0);
            this.EasyAiStartBtn.Name = "EasyAiStartBtn";
            this.EasyAiStartBtn.Size = new System.Drawing.Size(358, 83);
            this.EasyAiStartBtn.TabIndex = 9;
            this.EasyAiStartBtn.Text = "Easy AI";
            this.EasyAiStartBtn.UseVisualStyleBackColor = false;
            this.EasyAiStartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel2.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.CreditsBtn, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.RulesBtn, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.PvPStartBtn, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.EasyAiStartBtn, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.HardAiStartBtn, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(446, 673);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(10, 10, 10, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(998, 302);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // Title
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Navy;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1898, 1024);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.DoubleBuffered = true;
            this.MinimizeBox = false;
            this.Name = "Title";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect 4 Title Screen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2);
            this.Click += new System.EventHandler(this.StartBtn_Click);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void lblCredits_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


        #endregion
        private System.Windows.Forms.Button RulesBtn;
        private System.Windows.Forms.Button PvPStartBtn;
        private System.Windows.Forms.Button CreditsBtn;
        private System.Windows.Forms.Label lblCredits;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button HardAiStartBtn;
        private System.Windows.Forms.Button EasyAiStartBtn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

