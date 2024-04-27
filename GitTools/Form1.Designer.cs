namespace CreateIssueAuto
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
            btnForm3 = new Button();
            btnForm2 = new Button();
            SuspendLayout();
            // 
            // btnForm3
            // 
            btnForm3.Location = new Point(12, 79);
            btnForm3.Name = "btnForm3";
            btnForm3.Size = new Size(120, 61);
            btnForm3.TabIndex = 0;
            btnForm3.Text = "Search Commits Pendent";
            btnForm3.UseVisualStyleBackColor = true;
            btnForm3.Click += btnForm3_Click;
            // 
            // btnForm2
            // 
            btnForm2.Location = new Point(12, 12);
            btnForm2.Name = "btnForm2";
            btnForm2.Size = new Size(120, 61);
            btnForm2.TabIndex = 1;
            btnForm2.Text = "Create Issues";
            btnForm2.UseVisualStyleBackColor = true;
            btnForm2.Click += btnForm2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(144, 154);
            Controls.Add(btnForm2);
            Controls.Add(btnForm3);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Git Tools";
            ResumeLayout(false);
        }

        #endregion

        private Button btnForm3;
        private Button btnForm2;
    }
}