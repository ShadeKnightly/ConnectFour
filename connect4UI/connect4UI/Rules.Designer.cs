namespace connect4UI
{
    partial class Rules
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rules));
            this.RulesTitle = new System.Windows.Forms.Label();
            this.RulesTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // RulesTitle
            // 
            this.RulesTitle.AutoSize = true;
            this.RulesTitle.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RulesTitle.Location = new System.Drawing.Point(394, 65);
            this.RulesTitle.Name = "RulesTitle";
            this.RulesTitle.Size = new System.Drawing.Size(145, 56);
            this.RulesTitle.TabIndex = 0;
            this.RulesTitle.Text = "Rules";
            this.RulesTitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // RulesTextBox
            // 
            this.RulesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RulesTextBox.BackColor = System.Drawing.Color.Black;
            this.RulesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RulesTextBox.ForeColor = System.Drawing.Color.White;
            this.RulesTextBox.Location = new System.Drawing.Point(222, 201);
            this.RulesTextBox.Name = "RulesTextBox";
            this.RulesTextBox.Size = new System.Drawing.Size(525, 602);
            this.RulesTextBox.TabIndex = 1;
            this.RulesTextBox.Text = resources.GetString("RulesTextBox.Text");
            this.RulesTextBox.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // Rules
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(947, 919);
            this.Controls.Add(this.RulesTextBox);
            this.Controls.Add(this.RulesTitle);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Name = "Rules";
            this.ShowIcon = false;
            this.Text = "Rules";
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.Rules_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RulesTitle;
        private System.Windows.Forms.RichTextBox RulesTextBox;
    }
}