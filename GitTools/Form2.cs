using System.Data;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace CreateIssueAuto
{
    public partial class Form2 : Form
    {
        private bool _GenerateIssue = true;
        private bool _GenerateBranchFromIssue = false;

        public Form2()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OnValidations();
            btnSave.Enabled = false;

            string text = string.Empty;

            string Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            Dictionary<string, string> output = new Dictionary<string, string>();

            for (int i = Convert.ToInt32(txtNrIssuesMin.Text); i <= Convert.ToInt32(txtNrIssuesMax.Text); i++)
            {
                try
                {
                    using (Process process = new Process())
                    {
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.RedirectStandardInput = true;
                        process.StartInfo.RedirectStandardOutput = true;
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.Start();
                        process.StandardInput.WriteLine($"cd \"{txtFolder.Text}\"");
                        if (_GenerateIssue)
                        {
                            process.StandardInput.WriteLine($"gh issue create -a \"@me\" -t \"{txtTitle.Text} {i}\" -b \"{txtBody.Text} {i}\"");
                        }
                        if (_GenerateBranchFromIssue)
                        {
                            process.StandardInput.WriteLine($"gh issue develop {i}");
                        }
                        process.StandardInput.WriteLine("exit");
                        while (!process.StandardOutput.EndOfStream)
                            text += "\t" + process.StandardOutput.ReadLine() + "\n";
                        output.Add($"{txtFolder.Text}_{i}", text);
                        process.WaitForExit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (output.Count > 0)
            {
                foreach (var item in output)
                {
                    using (StreamWriter sw = new StreamWriter(Path.Combine(Desktop, "create-issues.md"), true))
                    {
                        sw.WriteLine($"# {item.Key}");
                        sw.WriteLine($"{item.Value}");
                        sw.Close();
                    }
                }
            }

            btnSave.Enabled = true;

            MessageBox.Show("Finalizado com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            ClearFields();
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();

            string project = folderBrowserDialog1.SelectedPath;

            List<string> lstFoldersInProject = Directory.GetDirectories(project).ToList();

            foreach (var folder in lstFoldersInProject)
            {
                if (folder.Contains(".git"))
                {
                    txtFolder.Text = project;

                    //VerifyIssue();
                }
            }
        }

        private void txtFolder_TextChanged(object sender, EventArgs e)
        {
            if (txtFolder.Text.Length > 0)
            {
                groupBox1.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
            }
        }
        private void chkCreateIssue_CheckedChanged(object sender, EventArgs e)
        {
            txtTitle.Enabled = chkCreateIssue.Checked;
            txtBody.Enabled = chkCreateIssue.Checked;
            _GenerateIssue = chkCreateIssue.Checked;
        }

        private void chkCreateBranchFromIssue_CheckedChanged(object sender, EventArgs e)
        {
            _GenerateBranchFromIssue = chkCreateBranchFromIssue.Checked;
        }

        private void VerifyIssue()
        {
            string text = string.Empty;

            using (Process process = new Process())
            {
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
                process.StandardInput.WriteLine($"cd \"{txtFolder.Text}\"");
                process.StandardInput.WriteLine($"gh issue list");
                process.StandardInput.WriteLine("exit");
                while (!process.StandardOutput.EndOfStream)
                    text += "\t" + process.StandardOutput.ReadLine() + "\n";
                process.WaitForExit();
            }

            string issues = text.Substring(text.IndexOf("gh issue list")+14);

            string exit = text.Substring(text.IndexOf("\t1\t")+39);

            issues = issues.Replace(exit, "");

            string[] issuesArr = issues.Split("\t");

            issuesArr = issuesArr.Where(x=> !string.IsNullOrEmpty(x)).ToArray();

            for (int i = 0; i < issuesArr.Length; i++)
            {
                string id = issuesArr[i]; 
                string title = issuesArr[i + 1]; 
                string labels = issuesArr[i + 2];
                string updated = issuesArr[i + 3];

                string branch = "";

                string text_branch = string.Empty;

                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardInput = true;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process.Start();
                    process.StandardInput.WriteLine($"cd \"{txtFolder.Text}\"");
                    process.StandardInput.WriteLine($"gh issue develop {id} --list");
                    process.StandardInput.WriteLine("exit");
                    while (!process.StandardOutput.EndOfStream)
                        text_branch += "\t" + process.StandardOutput.ReadLine() + "\n";
                    process.WaitForExit();
                }

                string issues_branch = text_branch.Substring(text_branch.IndexOf($"gh issue develop {id} --list") + 29);

                string exit_branch = text_branch.Substring(text_branch.IndexOf($"-{id}\t") + 39);

                issues_branch = issues_branch.Replace(exit_branch, "");

                string[] issues_branchArr = issues_branch.Split("\t");

                issues_branchArr = issues_branchArr.Where(x => !string.IsNullOrEmpty(x)).ToArray();

                if (issues_branchArr.Contains($"{txtFolder.Text}>exit\n"))
                {
                    branch = "";
                }
                else
                {
                    branch = issues_branchArr[0];
                }

                GridIssues.Rows.Add(new string[] { id, title, branch, labels, updated, "TESTE" });
                i += 3;
            }
        }

        private void ClearFields()
        {
            txtNrIssuesMin.Text = "0";
            txtNrIssuesMax.Text = "0";
            txtFolder.Text = "";
            txtTitle.Text = "";
            txtBody.Text = "";
        }

        private void OnValidations()
        {
            if (!double.TryParse(txtNrIssuesMin.Text, out _))
            {
                MessageBox.Show("Minimo não é número");
                return;
            }
            if (!double.TryParse(txtNrIssuesMax.Text, out _))
            {
                MessageBox.Show("Maximo não é número");
                return;
            }

            if (chkCreateIssue.Checked)
            {
                if (txtTitle.Text.Length == 0)
                {
                    MessageBox.Show("Sem Titulo");
                    return;
                }

                if (txtBody.Text.Length == 0)
                {
                    MessageBox.Show("Sem corpo");
                    return;
                }
            }

            if (Convert.ToInt32(txtNrIssuesMin.Text) > Convert.ToInt32(txtNrIssuesMax.Text))
            {
                MessageBox.Show("Minimo maior que maximo");
                return;
            }
            else
            {
                if (Convert.ToInt32(txtNrIssuesMin.Text) == 0)
                {
                    MessageBox.Show("Minimo não pode ser zero");
                    return;
                }
            }
        }
    }
}
