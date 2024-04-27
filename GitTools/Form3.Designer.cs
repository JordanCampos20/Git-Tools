namespace CreateIssueAuto
{
    partial class Form3
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
            groupBox1 = new GroupBox();
            btnSearch = new Button();
            label4 = new Label();
            txtFolder = new TextBox();
            btnFolder = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Enabled = false;
            groupBox1.Location = new Point(12, 62);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(294, 67);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 12F);
            btnSearch.Location = new Point(7, 22);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(281, 32);
            btnSearch.TabIndex = 17;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9F);
            label4.Location = new Point(-9, 44);
            label4.Name = "label4";
            label4.Size = new Size(335, 15);
            label4.TabIndex = 14;
            label4.Text = "----------------------------------------------------------------------------------";
            // 
            // txtFolder
            // 
            txtFolder.Enabled = false;
            txtFolder.Location = new Point(12, 12);
            txtFolder.Name = "txtFolder";
            txtFolder.Size = new Size(189, 23);
            txtFolder.TabIndex = 13;
            // 
            // btnFolder
            // 
            btnFolder.Location = new Point(207, 12);
            btnFolder.Name = "btnFolder";
            btnFolder.Size = new Size(99, 23);
            btnFolder.TabIndex = 12;
            btnFolder.Text = "Search Folder";
            btnFolder.UseVisualStyleBackColor = true;
            btnFolder.Click += btnFolder_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(318, 141);
            Controls.Add(groupBox1);
            Controls.Add(label4);
            Controls.Add(txtFolder);
            Controls.Add(btnFolder);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form3";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Search projects not commited";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnSearch;
        private Label label4;
        private TextBox txtFolder;
        private Button btnFolder;
        private FolderBrowserDialog folderBrowserDialog1;
    }
}