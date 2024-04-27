namespace CreateIssueAuto
{
    partial class Form2
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            folderBrowserDialog1 = new FolderBrowserDialog();
            btnFolder = new Button();
            txtFolder = new TextBox();
            label4 = new Label();
            groupBox1 = new GroupBox();
            txtNrIssuesMin = new TextBox();
            btnSave = new Button();
            label3 = new Label();
            txtNrIssuesMax = new TextBox();
            label2 = new Label();
            txtBody = new TextBox();
            label1 = new Label();
            txtTitle = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnFolder
            // 
            btnFolder.Location = new Point(206, 12);
            btnFolder.Name = "btnFolder";
            btnFolder.Size = new Size(99, 23);
            btnFolder.TabIndex = 0;
            btnFolder.Text = "Search Folder";
            btnFolder.UseVisualStyleBackColor = true;
            btnFolder.Click += btnFolder_Click;
            // 
            // txtFolder
            // 
            txtFolder.Enabled = false;
            txtFolder.Location = new Point(11, 12);
            txtFolder.Name = "txtFolder";
            txtFolder.Size = new Size(189, 23);
            txtFolder.TabIndex = 1;
            txtFolder.TextChanged += txtFolder_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9F);
            label4.Location = new Point(-10, 44);
            label4.Name = "label4";
            label4.Size = new Size(335, 15);
            label4.TabIndex = 9;
            label4.Text = "----------------------------------------------------------------------------------";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtNrIssuesMin);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtNrIssuesMax);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtBody);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtTitle);
            groupBox1.Enabled = false;
            groupBox1.Location = new Point(11, 62);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(294, 150);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            // 
            // txtNrIssuesMin
            // 
            txtNrIssuesMin.Location = new Point(143, 79);
            txtNrIssuesMin.Name = "txtNrIssuesMin";
            txtNrIssuesMin.Size = new Size(59, 23);
            txtNrIssuesMin.TabIndex = 18;
            txtNrIssuesMin.Text = "0";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 12F);
            btnSave.Location = new Point(7, 113);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(281, 32);
            btnSave.TabIndex = 17;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(8, 81);
            label3.Name = "label3";
            label3.Size = new Size(121, 21);
            label3.TabIndex = 16;
            label3.Text = "Number Issues?";
            // 
            // txtNrIssuesMax
            // 
            txtNrIssuesMax.Location = new Point(228, 79);
            txtNrIssuesMax.Name = "txtNrIssuesMax";
            txtNrIssuesMax.Size = new Size(59, 23);
            txtNrIssuesMax.TabIndex = 15;
            txtNrIssuesMax.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(8, 50);
            label2.Name = "label2";
            label2.Size = new Size(45, 21);
            label2.TabIndex = 14;
            label2.Text = "Body";
            // 
            // txtBody
            // 
            txtBody.Location = new Point(59, 48);
            txtBody.Name = "txtBody";
            txtBody.Size = new Size(228, 23);
            txtBody.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(15, 21);
            label1.Name = "label1";
            label1.Size = new Size(39, 21);
            label1.TabIndex = 12;
            label1.Text = "Title";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(59, 19);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(228, 23);
            txtTitle.TabIndex = 11;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(311, 223);
            Controls.Add(groupBox1);
            Controls.Add(label4);
            Controls.Add(txtFolder);
            Controls.Add(btnFolder);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form2";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Create issues auto";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FolderBrowserDialog folderBrowserDialog1;
        private Button btnFolder;
        private TextBox txtFolder;
        private Label label4;
        private GroupBox groupBox1;
        private TextBox txtNrIssuesMin;
        private Button btnSave;
        private Label label3;
        private TextBox txtNrIssuesMax;
        private Label label2;
        private TextBox txtBody;
        private Label label1;
        private TextBox txtTitle;
    }
}
